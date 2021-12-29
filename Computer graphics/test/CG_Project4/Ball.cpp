#include "Ball.h"

#include "Game.h"

void Ball::CheckCollisions(float timeDelta)
{
	Field& field = GetGame().Field;
	Paddle& PaddleNear = GetGame().PaddleNear;
	Paddle& PaddleFar = GetGame().PaddleFar;

	if (XMax() > field.XMax() || XMin() < field.XMin())
	{
		float xFace = XMax() > field.XMax() ? field.XMax() : field.XMin();
		glm::vec3 facePoint(xFace, m_position.y, m_position.z);

		// Project the ball back to the surface of the paddle
		auto trueDirection = glm::normalize(CalculatePositionDiff(timeDelta));
		auto eps = (glm::distance(facePoint, m_position) - Radius) / glm::abs(trueDirection.x);
		auto hitPosition = m_position + eps * trueDirection;

		// Recalculate the collision point
		facePoint = glm::vec3(xFace, hitPosition.y, hitPosition.z);
		m_position = hitPosition;

		Bounce(glm::normalize(m_position - facePoint), glm::vec3());
	}

	if (YMax() > field.YMax() || YMin() < field.YMin())
	{
		float yFace = YMax() > field.YMax() ? field.YMax() : field.YMin();
		glm::vec3 facePoint(m_position.x, yFace, m_position.z);

		// Project the ball back to the surface of the paddle
		auto trueDirection = glm::normalize(CalculatePositionDiff(timeDelta));
		auto eps = (glm::distance(facePoint, m_position) - Radius) / glm::abs(trueDirection.y);
		auto hitPosition = m_position + eps * trueDirection;

		// Recalculate the collision point
		facePoint = glm::vec3(hitPosition.x, yFace, hitPosition.z);
		m_position = hitPosition;

		Bounce(glm::normalize(m_position - facePoint), glm::vec3());
	}


	if (ZMax() > PaddleNear.ZMin())
		CheckPaddleCollision(PaddleNear, PaddleNear.ZMin(), timeDelta);

	if (ZMin() < PaddleFar.ZMax())
		CheckPaddleCollision(PaddleFar, PaddleFar.ZMax(), timeDelta);
	
	if (ZMax() > field.ZMax())
		GetGame().Score(1);

	if (ZMin() < field.ZMin())
		GetGame().Score(0);
}

bool Ball::CheckPaddleCollision(Paddle& paddle, float zPaddleFace, float timeDelta)
{
	if (XMax() >= paddle.XMin() && XMin() <= paddle.XMax()
		&& YMax() >= paddle.YMin() && YMin() <= paddle.YMax())
	{
		// possible collsion with the paddle
		glm::vec3 paddlePoint(m_position.x, m_position.y, zPaddleFace);

		paddlePoint.x = glm::max(glm::min(m_position.x, paddle.XMax()), paddle.XMin());
		paddlePoint.y = glm::max(glm::min(m_position.y, paddle.YMax()), paddle.YMin());

		if (glm::distance(paddlePoint, m_position) <= Radius)
		{
			auto trueDirection = glm::normalize(CalculatePositionDiff(timeDelta));

			// Project the ball back to the surface of the paddle
			auto eps = (glm::distance(paddlePoint, m_position)-Radius) / glm::abs(trueDirection.z);
			auto hitPosition = m_position + eps * trueDirection;

			// Recalculate the collision point
			paddlePoint = glm::vec3(hitPosition.x, hitPosition.y, zPaddleFace);
			paddlePoint.x = glm::max(glm::min(hitPosition.x, paddle.XMax()), paddle.XMin());
			paddlePoint.y = glm::max(glm::min(hitPosition.y, paddle.YMax()), paddle.YMin());

			m_position = hitPosition;

			Bounce(glm::normalize(m_position - paddlePoint), paddle.Direction());
			return true;
		}
	}

	return false;
}