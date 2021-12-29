#ifndef IControllerH
#define IControllerH

#include <glm/matrix.hpp>

class IController
{
public:

	virtual glm::vec3&& MoveDirection() = 0;

	virtual ~IController() {}
};

#endif