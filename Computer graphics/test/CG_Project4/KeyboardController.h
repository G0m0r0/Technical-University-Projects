#ifndef KeyboardControllerH
#define KeyboardControllerH

#include "IController.h"
#include <GLFW/glfw3.h>

class KeyboardController : public IController
{
	GLFWwindow* m_pWindow;
	int m_upKey, m_downKey, m_leftKey, m_rightKey;

public:
	KeyboardController(GLFWwindow* pWindow, int upKey, int downKey, int leftKey, int rightKey) :
		m_pWindow(pWindow),
		m_upKey(upKey),
		m_downKey(downKey),
		m_leftKey(leftKey),
		m_rightKey(rightKey)
	{}

	virtual glm::vec3&& MoveDirection();
};

#endif

