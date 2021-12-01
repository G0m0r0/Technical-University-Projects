#include <iostream>
#include <memory>

#pragma comment(lib, "glfw3.lib")

// GLAD
#include <glad/glad.h>

// GLFW
#include <GLFW/glfw3.h>

#include "ShaderProgram.hpp"

#define STB_IMAGE_IMPLEMENTATION
#include "stb_image.h"


void key_callback(GLFWwindow* window, int key, int scancode, int action, int mode);

const GLuint WIDTH = 800, HEIGHT = 600;

int main()
{
	std::cout << "Starting GLFW context, OpenGL 3.3" << std::endl;
	// Init GLFW
	glfwInit();

	try
	{
		stbi_set_flip_vertically_on_load(true);// Tell stb to filp images so that 0.0 is at the bottom of the y-axis

		glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
		glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
		glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
		glfwWindowHint(GLFW_RESIZABLE, GL_FALSE);

		GLFWwindow* window = glfwCreateWindow(WIDTH, HEIGHT, "OpenGL Window", NULL, NULL);
		glfwMakeContextCurrent(window);
		if (window == NULL)
			throw std::exception("Failed to create GLFW window");

		glfwSetKeyCallback(window, key_callback);

		if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
			throw std::exception("Failed to initialize OpenGL context");

		// Define the viewport dimensions
		glViewport(0, 0, WIDTH, HEIGHT);

		// vertext buffer object to draw
		struct Vertext
		{
			float x, y, z;
			float r, g, b;
			float s, t;
			Vertext(float x, float y, float z, float r, float g, float b, float s, float t)
				:x(x), y(y), z(z), r(r), g(g), b(b), s(s), t(t) {}
		};
		// Coordinates are in NDC (Normalized Device Coordinates) from -1 to 1
		Vertext vertices[] = {
			Vertext(-0.5f, -0.5f, 0.0f, .00f, .50f, .20f, 0.0f, 0.f ),
			Vertext( 0.5f, -0.5f, 0.0f, .00f, .50f, .20f, 1.0f, 0.f ),
			Vertext(-0.5f,  0.5f, 0.0f, .00f, .50f, .20f, 0.0f, 1.f),
			Vertext( 0.5f,  0.5f, 0.0f, .00f, .50f, .20f, 1.0f, 1.f )
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

//#define MULTITEXTURES
#ifndef MULTITEXTURES
		ShaderProgram shader("Shaders/vertex.vert", "Shaders/fragment.frag");
#else
// LATER 1 START
		ShaderProgram shader("Shaders/vertex.vert", "Shaders/multitextures.frag");
// LATER 1 END
#endif
		shader.use();

		// Map the vertex attributes
		glVertexAttribPointer(0 /*location=0*/, 3, GL_FLOAT, GL_FALSE, sizeof(Vertext), NULL);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertext), (void*)offsetof(Vertext, r));
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(Vertext), (void*)offsetof(Vertext, s));
		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);
		glEnableVertexAttribArray(2);

#ifndef MULTITEXTURES
		// Load the texture data from file
		int width, height, nrChannels;
		{
			std::shared_ptr<unsigned char> pData = std::shared_ptr<unsigned char>(stbi_load("Resources/wall.jpg", &width, &height, &nrChannels, 0), stbi_image_free);
			if (!pData)
				throw std::exception("Failed to load texture");

			// Generate a texture object
			unsigned texture;
			glGenTextures(1, &texture);
			glActiveTexture(GL_TEXTURE0);
			glBindTexture(GL_TEXTURE_2D, texture);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			// We can set a border color and use it with GL_CLAMP_TO_BORDER for GL_TEXTURE_WRAP_S
			//float borderColor[] = { 1.0f, 1.0f, 0.0f, 1.0f };
			//glTexParameterfv(GL_TEXTURE_2D, GL_TEXTURE_BORDER_COLOR, borderColor);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, pData.get());
			glGenerateMipmap(GL_TEXTURE_2D);
		}		
#else
		// LATER 1 START
		{
			int width, height, nrChannels;
			std::shared_ptr<unsigned char> pContainerTex = std::shared_ptr<unsigned char>(stbi_load("Resources/container.jpg", &width, &height, &nrChannels, 0), stbi_image_free);
			int width2, height2, nrChannels2;
			std::shared_ptr<unsigned char> pFaceTex = std::shared_ptr<unsigned char>(stbi_load("Resources/awesomeface.png", &width2, &height2, &nrChannels2, 0), stbi_image_free);
		
			if (!pContainerTex || !pFaceTex)
				throw std::exception("Failed to load texture");

			// Generate texture objects
			unsigned textures[2];
			glGenTextures(2, textures);

			// Activate Texture unit
			glActiveTexture(GL_TEXTURE0);
			glBindTexture(GL_TEXTURE_2D, textures[0]);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			// We can set a border color and use it with GL_CLAMP_TO_BORDER for GL_TEXTURE_WRAP_S
			//float borderColor[] = { 1.0f, 1.0f, 0.0f, 1.0f };
			//glTexParameterfv(GL_TEXTURE_2D, GL_TEXTURE_BORDER_COLOR, borderColor);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, pContainerTex.get());
			glGenerateMipmap(GL_TEXTURE_2D);

			glActiveTexture(GL_TEXTURE1 /*GL_TEXTURE0 + 1*/);
			glBindTexture(GL_TEXTURE_2D, textures[1]);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width2, height2, 0, GL_RGBA, GL_UNSIGNED_BYTE, pFaceTex.get());
			glGenerateMipmap(GL_TEXTURE_2D);

			// Assign textures to texture samplers in the fragment shader
			glUniform1i(glGetUniformLocation(shader.ID, "texture1"), 0);
			glUniform1i(glGetUniformLocation(shader.ID, "texture2"), 1);
		}		
		// LATER 1 END
#endif


		while (!glfwWindowShouldClose(window))
		{
			glfwPollEvents();

			// Render
			// Clear the colorbuffer
			glClearColor(0.1f, 0.1f, 0.1f, 1.0f);
			glClear(GL_COLOR_BUFFER_BIT);

			GLenum mode = GL_TRIANGLE_STRIP; // GL_TRIANGLES GL_POINTS GL_LINE_STRIP GL_LINE_LOOP
			glDrawArrays(mode, 0 /*start index in the vbo*/, sizeof(vertices) / sizeof(vertices[0]) /*number of vertices*/);

			// Swap the screen buffers
			glfwSwapBuffers(window);
		}
	}
	catch (std::exception& e)
	{
		std::cout << "Unexpected error: " << e.what() << std::endl;
		std::cin.get();
	}

	// Terminates GLFW, clearing any resources allocated by GLFW.
	glfwTerminate();

	return 0;
}

void key_callback(GLFWwindow* window, int key, int scancode, int action, int mode)
{
	std::cout << key << std::endl;
	if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
		glfwSetWindowShouldClose(window, GL_TRUE);
}
