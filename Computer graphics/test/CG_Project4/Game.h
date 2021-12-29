#ifndef GameH
#define GameH

#include "Ball.h"
#include "Field.h"
#include "Paddle.h"

class Game
{
	std::unique_ptr<ShaderProgram> shader;

public:

	Ball Ball;
	Field Field;
	Paddle PaddleNear;
	Paddle PaddleFar;

	Game();

	void Score(int winnerPaddle);
	void Reset();

	void CreateVAOs();
	void Animate(float timeDelta);
	void Draw();

	void SetView(const glm::mat4& view) { glUniformMatrix4fv(glGetUniformLocation(shader->ID, "view"), 1, GL_FALSE, glm::value_ptr(view)); }
	void SetProjection(const glm::mat4& proj) { glUniformMatrix4fv(glGetUniformLocation(shader->ID, "projection"), 1, GL_FALSE, glm::value_ptr(proj)); }

	~Game();

private:

	int m_paddleScores[2];
	double m_freezeFor;

	void ClampPaddleToField(Paddle& p);
};

#endif