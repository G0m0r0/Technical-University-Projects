#include <iostream>
#include <memory>

#pragma comment(lib, "glfw3.lib")

// GLAD
#include <glad/glad.h>

// GLFW
#include <GLFW/glfw3.h>

// GLM
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

#include "ShaderProgram.hpp"

//  Sean Barrett
#define STB_IMAGE_IMPLEMENTATION
#include "stb_image.h"

using namespace std;
using namespace glm;

void key_callback(GLFWwindow* window, int key, int scancode, int action, int mode);
void on_error(int code, const char* text);

const GLuint WIDTH = 1280, HEIGHT = 720;

int main()
{
	cout << "Starting GLFW context, OpenGL 3.3" << endl;
	// Init GLFW
	glfwInit();

	try
	{
		stbi_set_flip_vertically_on_load(true);// Tell stb to filp images so that 0.0 is at the bottom of the y-axis

		glfwSetErrorCallback(on_error);

		glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
		glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
		glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
		glfwWindowHint(GLFW_RESIZABLE, GL_FALSE);

		GLFWwindow* window = glfwCreateWindow(WIDTH, HEIGHT, "OpenGL Window", NULL, NULL);
		glfwMakeContextCurrent(window);
		if (window == NULL)
			throw exception("Failed to create GLFW window");

		glfwSetKeyCallback(window, key_callback);

		if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
			throw exception("Failed to initialize OpenGL context");

		// Define the viewport dimensions
		glViewport(0, 0, WIDTH, HEIGHT);

		// Vertex buffer object to draw
		struct Vertex
		{
			float x, y, z;
			float r, g, b;
			float s, t;
			Vertex(float x, float y, float z, float r, float g, float b, float s, float t)
				:x(x), y(y), z(z), r(r), g(g), b(b), s(s), t(t) {}
		};
		// Coordinates are in NDC (Normalized Device Coordinates) from -1 to 1
		Vertex vertices[] = {
			// positions          // colors           // texture coords
			Vertex(-0.09f, -0.09f, 0.0f, .00f, .50f, .20f, 0.0f, 0.f ), // top right
			Vertex( 0.09f, -0.09f, 0.0f, .00f, .50f, .20f, 1.0f, 0.f ), // bottom right
			Vertex(-0.09f,  0.09f, 0.0f, .00f, .50f, .20f, 0.0f, 1.f), // bottom left
			Vertex( 0.09f,  0.09f, 0.0f, .00f, .50f, .20f, 1.0f, 1.f ), // top left 
		};

		// A Vertex Array Object will store OpenGL's state 
		unsigned vao;
		glGenVertexArrays(1, &vao);
		glBindVertexArray(vao);

		// Create a Vertex Buffer Object
		unsigned int vbo;
		glGenBuffers(1, &vbo);
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);

#define PERSPECTIVE
#ifndef PERSPECTIVE
		ShaderProgram shader("Shaders/vertex.vert", "Shaders/multitextures.frag");
#else
		ShaderProgram shader("Shaders/mvp.vert", "Shaders/multitextures.frag");
#endif
		shader.use();

		// Map the vertex attributes
		glVertexAttribPointer(0 /*location=0*/, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), NULL);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, r));
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, s));
		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);
		glEnableVertexAttribArray(2);

		// Load the textures
		{
			// bird
			int width, height, nrChannels;
			shared_ptr<unsigned char> pBackTex = shared_ptr<unsigned char>(stbi_load("Resources/back.jpg", &width, &height, &nrChannels, 0), stbi_image_free);
			int width2, height2, nrChannels2;
			shared_ptr<unsigned char> pBirdTex = shared_ptr<unsigned char>(stbi_load("Resources/bird.png", &width2, &height2, &nrChannels2, 0), stbi_image_free);
		
			if (!pBackTex || !pBirdTex)
				throw exception("Failed to load texture");

			// Generate texture objects
			unsigned textures[2];
			glGenTextures(2, textures);

			// Activate Texture unit
			//back
			glActiveTexture(GL_TEXTURE0);
			glBindTexture(GL_TEXTURE_2D, textures[0]);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR); //foggy
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			// We can set a border color and use it with GL_CLAMP_TO_BORDER for GL_TEXTURE_WRAP_S
			//float borderColor[] = { 1.0f, 1.0f, 0.0f, 1.0f };
			//glTexParameterfv(GL_TEXTURE_2D, GL_TEXTURE_BORDER_COLOR, borderColor);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width, height, 0, GL_RGBA, GL_UNSIGNED_BYTE, pBackTex.get());
			glGenerateMipmap(GL_TEXTURE_2D);

			//bird
			glActiveTexture(GL_TEXTURE1 /*GL_TEXTURE0 + 1*/);
			glBindTexture(GL_TEXTURE_2D, textures[1]);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width2, height2, 0, GL_RGBA, GL_UNSIGNED_BYTE, pBirdTex.get());
			glGenerateMipmap(GL_TEXTURE_2D);

			// Assign textures to texture samplers in the fragment shader
			glUniform1i(glGetUniformLocation(shader.ID, "texture1"), 0);
			glUniform1i(glGetUniformLocation(shader.ID, "texture2"), 1);

			/*unsigned int texture;
			glGenTextures(1, &texture);
			glBindTexture(GL_TEXTURE_2D, texture);
			// set the texture wrapping/filtering options (on the currently bound texture object)
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
			// load and generate the texture
			int width3, height3, nrChannels3;
			unsigned char* data = stbi_load("chimney1.jpg", &width3, &height3, &nrChannels3, 0);
			if (data)
			{
				glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width3, height3, 0, GL_RGB, GL_UNSIGNED_BYTE, data);
				glGenerateMipmap(GL_TEXTURE_2D);
			}
			else
			{
				cout << "Failed to load texture" << endl;
			}
			stbi_image_free(data); */
		}		

		float upDown = 0;
		float boost = -0.95f;
		while (!glfwWindowShouldClose(window))
		{
			glfwPollEvents();

			// Render
			// Clear the colorbuffer
			glClearColor(0, 0.9f, 1, 1.0f);
			glClear(GL_COLOR_BUFFER_BIT);

#ifndef PERSPECTIVE
			mat4 trans = mat4(1.0f);
			//trans = translate(trans, vec3(0.5f, -0.5f, 0.f));
			//trans = rotate(trans, radians(45.f), vec3(0.f, 0.f, 1.f));
			//trans = scale(trans, vec3(0.5, 0.5, 1.));

			glUniformMatrix4fv(glGetUniformLocation(shader.ID, "transform"), 1, GL_FALSE, value_ptr(trans));
#else // LATER //CAMERA

			// Model
			mat4 model;
			//model = rotate(model, radians(-55.0f), vec3(1.0f, 0.0f, 0.0f));
			model = translate(model, vec3(boost, upDown, 0.f));

			// View
			mat4 view;
			// note that we're translating the scene in the reverse direction of where we want to move
			 view = translate(view, vec3(0.0f, 0.0f, -1.5f));

			// Projection
			mat4 projection;
			projection = perspective(radians(45.0f), (float)WIDTH / HEIGHT, 0.1f, 100.0f);

			//model = translate(model, vec3(0.5f, -0.5f, 0.f));
			//model = rotate(model, 0.5f, vec3(0.f, 0.f, 0.2f));
			//model = scale(model, vec3(0.5, 0.5, 1.));

			if (glfwGetKey(window, GLFW_KEY_W) == GLFW_PRESS)
			{
				upDown += 0.02;				
				boost += 0.005;
				model = rotate(model, 0.5f, vec3(0.f, 0.f, 0.2f));
			}
			else if (glfwGetKey(window, GLFW_KEY_B) == GLFW_PRESS) //make game harder
			{
				boost += 0.02;				
			}
			else if (glfwGetKey(window, GLFW_KEY_A) == GLFW_PRESS) //make game harder
			{
				boost -= 0.01;				
			}
			else
			{
				upDown -= 0.005;				
				model = rotate(model, -0.3f, vec3(0.f, 0.f, 0.2f));
				//TODO: dying when falls below
			}

			if (upDown >= 0.5) {
				upDown = 0.5;
			}else if (upDown <= -0.5) {
				upDown = -0.5;
			}

			if (boost >= 0.5) {
				boost = 0.5;
			}else if (boost <= -1) {
				boost = -1;
			}
			
			glUniformMatrix4fv(glGetUniformLocation(shader.ID, "model"), 1, GL_FALSE, value_ptr(model));
			glUniformMatrix4fv(glGetUniformLocation(shader.ID, "view"), 1, GL_FALSE, value_ptr(view));
			glUniformMatrix4fv(glGetUniformLocation(shader.ID, "projection"), 1, GL_FALSE, value_ptr(projection));
#endif

			GLenum mode = GL_TRIANGLE_STRIP; // GL_TRIANGLES GL_POINTS GL_LINE_STRIP GL_LINE_LOOP
			glDrawArrays(mode, 0 /*start index in the vbo*/, sizeof(vertices) / sizeof(vertices[0]) /*number of vertices*/);

			// Swap the screen buffers
			glfwSwapBuffers(window);
		}
	}
	catch (exception& e)
	{
		cout << "Unexpected error: " << e.what() << endl;
		cin.get();
	}

	// Terminates GLFW, clearing any resources allocated by GLFW.
	glfwTerminate();

	return 0;
}

void key_callback(GLFWwindow* window, int key, int scancode, int action, int mode)
{
	cout << key << endl;
	if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
		glfwSetWindowShouldClose(window, GL_TRUE);
}

void on_error(int code, const char* text)
{
	cout << "Error code: " << code << " Error text: " << text << endl;
}
