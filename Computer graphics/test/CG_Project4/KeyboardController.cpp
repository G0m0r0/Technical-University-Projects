#include "KeyboardController.h"

#include <GLFW/glfw3.h>

glm::vec3&& KeyboardController::MoveDirection()
{
	glm::vec3 result;

	if (glfwGetKey(m_pWindow, m_leftKey) == GLFW_PRESS)
		result.x += -1;
	if (glfwGetKey(m_pWindow, m_rightKey) == GLFW_PRESS)
		result.x += 1;
	if (glfwGetKey(m_pWindow, m_upKey) == GLFW_PRESS)
		result.y += 1;
	if (glfwGetKey(m_pWindow, m_downKey) == GLFW_PRESS)
		result.y += -1;

	if(glm::length(result) > 1e-6)
		result = glm::normalize(result);

	return std::move(result);
}