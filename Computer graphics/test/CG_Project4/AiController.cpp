#include "AiController.h"

#include "Paddle.h"
#include "Game.h"

glm::vec3&& AiController::MoveDirection()
{
	glm::vec3 result;

	auto x = m_paddle.Position().x;
	auto y = m_paddle.Position().y;

	auto xBall = m_paddle.GetGame().Ball.Position().x;
	auto yBall = m_paddle.GetGame().Ball.Position().y;

	if (x > xBall)
		result.x = -1;
	else if (x < xBall)
		result.x = 1;
	if (y > yBall)
		result.y = -1;
	else if (y < yBall)
		result.y = 1;

	if(glm::length(result) > 1e-6)
		result = glm::normalize(result);

	return std::move(result);
}