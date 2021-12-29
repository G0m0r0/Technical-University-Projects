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

#define STB_IMAGE_IMPLEMENTATION
#include "stb_image.h"

#include "Game.h"
#include "Field.h"
#include "Ball.h"
#include "Paddle.h"
#include "AiController.h"
#include "KeyboardController.h"


int main();

void WindowSettings(GLFWwindow*& window);

void key_callback(GLFWwindow* window, int key, int scancode, int action, int mode);
void on_error(int code, const char* text);

const GLuint WIDTH = 1024, HEIGHT = 768;

int main()
{
	std::cout << "Starting GLFW context, OpenGL 3.3" << std::endl;
	// Init GLFW
	glfwInit();

	try
	{
		GLFWwindow* window;
		WindowSettings(window);

		Game Game;

		glfwSetWindowUserPointer(window, (void*)&Game);
		glfwSetKeyCallback(window, key_callback);

		Game.CreateVAOs();

		// View
		glm::mat4 view;
		view = glm::translate(view, glm::vec3(0.0f, 0.0f, -80.0f));
		//view = glm::translate(view, glm::vec3(0.0f, -100.0f, -180.0f));
		//view = glm::rotate(view, glm::radians(90.0f), glm::vec3(1.0f, 0.0f, 0.0f));

		// Projection
		glm::mat4 projection;
		projection = glm::perspective(glm::radians(45.0f), (float)WIDTH / HEIGHT, 1.0f, 1200.0f);

		Game.SetView(view);
		Game.SetProjection(projection);

		double frameStart = glfwGetTime();
		double lastFrameStart = glfwGetTime();

		// Standard game mode - player vs computer
		Game.PaddleNear.SetController(std::unique_ptr<IController>(new KeyboardController(window, GLFW_KEY_UP, GLFW_KEY_DOWN, GLFW_KEY_LEFT, GLFW_KEY_RIGHT)));
		Game.PaddleFar.SetController(std::unique_ptr<IController>(new AiController(Game.PaddleFar)));

		while (!glfwWindowShouldClose(window))
		{
			glfwPollEvents();

			// Render
			glClear(GL_DEPTH_BUFFER_BIT);
			// Clear the colorbuffer
			glClearColor(0.1f, 0.1f, 0.1f, 1.0f);
			glClear(GL_COLOR_BUFFER_BIT);

			frameStart = glfwGetTime();
			float timeDelta = (float)(frameStart - lastFrameStart);

			Game.Animate(timeDelta);
			Game.Draw();

			// Swap the screen buffers
			glfwSwapBuffers(window);

			lastFrameStart = frameStart;
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

void WindowSettings(GLFWwindow*& window)
{
	stbi_set_flip_vertically_on_load(true);// Tell stb to filp images so that 0.0 is at the bottom of the y-axis

	glfwSetErrorCallback(on_error);

	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
	glfwWindowHint(GLFW_RESIZABLE, GL_FALSE);

	window = glfwCreateWindow(WIDTH, HEIGHT, "OpenGL Window", NULL, NULL);
	glfwMakeContextCurrent(window);
	if (window == NULL)
		throw std::exception("Failed to create GLFW window");

	if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
		throw std::exception("Failed to initialize OpenGL context");

	// Define the viewport dimensions
	glViewport(0, 0, WIDTH, HEIGHT);
	glEnable(GL_DEPTH_TEST);
}

void key_callback(GLFWwindow* window, int key, int scancode, int action, int mode)
{
	if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
		glfwSetWindowShouldClose(window, GL_TRUE);

	Game* pGame = (Game*)glfwGetWindowUserPointer(window);

	switch (key)
	{
	case GLFW_KEY_1: // Player vs Computer
		pGame->PaddleNear.SetController(std::unique_ptr<IController>(new KeyboardController(window, GLFW_KEY_UP, GLFW_KEY_DOWN, GLFW_KEY_LEFT, GLFW_KEY_RIGHT)));
		pGame->PaddleFar.SetController(std::unique_ptr<IController>(new AiController(pGame->PaddleFar)));
		break;
	case GLFW_KEY_2: // Player vs Player
		pGame->PaddleNear.SetController(std::unique_ptr<IController>(new KeyboardController(window, GLFW_KEY_UP, GLFW_KEY_DOWN, GLFW_KEY_LEFT, GLFW_KEY_RIGHT)));
		pGame->PaddleFar.SetController(std::unique_ptr<IController>(new KeyboardController(window, GLFW_KEY_W, GLFW_KEY_S, GLFW_KEY_A, GLFW_KEY_D)));
		break;
	case GLFW_KEY_3: // Computer vs Computer
		pGame->PaddleNear.SetController(std::unique_ptr<IController>(new AiController(pGame->PaddleNear)));
		pGame->PaddleFar.SetController(std::unique_ptr<IController>(new AiController(pGame->PaddleFar)));
		break;
	case GLFW_KEY_4: // Computer vs Player
		pGame->PaddleFar.SetController(std::unique_ptr<IController>(new KeyboardController(window, GLFW_KEY_UP, GLFW_KEY_DOWN, GLFW_KEY_LEFT, GLFW_KEY_RIGHT)));
		pGame->PaddleNear.SetController(std::unique_ptr<IController>(new AiController(pGame->PaddleNear)));
		break;
	}
}

void on_error(int code, const char* text)
{
	std::cout << "Error code: " << code << " Error text: " << text << std::endl;
}
