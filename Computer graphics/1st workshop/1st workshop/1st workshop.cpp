// 1st workshop.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <glad/glad.h>
#include <GLFW/glfw3.h>

#pragma comment(lib,"glfw3.lib")

const int WIDTH = 800;
const int HEIGHT = 600;

void framebuffer_size_callback(GLFWwindow* window, int width, int height)
{
    glViewport(0, 0, width, height);
}

void processInput(GLFWwindow* window)
{
    if (glfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
        glfwSetWindowShouldClose(window, true);
}

int main()
{
    //with opengl
    //library glfw
    //library glaf
    std::cout << "Hello World!\n";

    //main function where we will instantiate the GLFW window
    if (glfwInit() == GLFW_FALSE) 
    {
        std::cout << "glfwInit FAILD" << std::endl;
        return -1;
    }

    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

    //window object
    GLFWwindow* window = glfwCreateWindow(WIDTH,HEIGHT,"GLFW windows",nullptr,nullptr);

    if (window == nullptr) {
        std::cout << "flfCreateWindows FAILED" << std::endl;
        glfwTerminate();
        return -1;
    }
    //for c++ NULL is equal to 0 
    //null from c# is nullptr

    glfwMakeContextCurrent(window);

    //manages function pointers for OpenGL so we want to initialize GLAD before we call any OpenGL function
    if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
        std::cout << "Failed to initialize GLAD" << std::endl;
        return -1;
    }

    glViewport(0, 0, WIDTH, HEIGHT);

    //callback function on the window that gets called each time the window is resized
    glfwSetFramebufferSizeCallback(window, framebuffer_size_callback);

    float green = 0;
    while (!glfwWindowShouldClose(window))
    {
        //input commands
        processInput(window);

        // rendering commands
        glClearColor(0, green ,0 ,1);
        green+=0.001;
        glClear(GL_COLOR_BUFFER_BIT);

        // check and call events and swap the buffers
        glfwSwapBuffers(window);  //swaps immediatly back with front buffer and grame is displayed instantly
        glfwPollEvents();
    }

    //std::cin.get();
    glfwTerminate();
    return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
