#ifndef AiControllerH
#define AiControllerH

#include "IController.h"

class Paddle;

class AiController : public IController
{
	Paddle& m_paddle;

public:
	AiController(Paddle& paddle) : m_paddle(paddle)
	{}

	virtual glm::vec3&& MoveDirection();
};

#endif