#include "Game.h"

#include <GLFW/glfw3.h>
#include <iostream>

Game::Game()
	:
	Field(*this),
	Ball(*this),
	PaddleNear(*this, glm::vec3(0.0f, 0.0f, Field.ZMax())),
	PaddleFar(*this, glm::vec3(0.0f, 0.0f, Field.ZMin())),
	m_freezeFor(0)
{
	m_paddleScores[0] = 0;
	m_paddleScores[1] = 0;
}

void Game::Reset()
{
	Ball.Reset();
}

void Game::Animate(float timeDelta)
{
	if (m_freezeFor > 0)
	{
		m_freezeFor -= timeDelta;
		if (m_freezeFor <= 0 && m_freezeFor + timeDelta > 0)
		{
			m_freezeFor = 0;
			Reset();
		}
		else
			return;
	}

	if (timeDelta > 0.5) // < 2 FPS, skip frame
		return;

	// Set the direction of objects in the world
	PaddleNear.Move();
	PaddleFar.Move();

	// Move the objects in the world based on the timeDelta
	PaddleNear.Animate(timeDelta);
	PaddleFar.Animate(timeDelta);
	Ball.Animate(timeDelta);

	// Check for intersections
	ClampPaddleToField(PaddleFar);
	ClampPaddleToField(PaddleNear);

	Ball.CheckCollisions(timeDelta);
}

void Game::Score(int winnerPaddle)
{
	m_paddleScores[winnerPaddle]++;

	std::cout << "Score is " << m_paddleScores[0] << ":" << m_paddleScores[1] << std::endl;

	m_freezeFor = 3;
	Ball.Color = glm::vec3(1.0f, 0.0f, 0.0f);
}

void Game::ClampPaddleToField(Paddle& p)
{
	if (p.XMin() < Field.XMin())
	{
		auto clampDiff = Field.XMin() - p.XMin();
		if (glm::abs(clampDiff) > 1e-6 && p.Direction().x < 0)
			p.Direction().x = 0;
		p.Position().x += clampDiff;
	}
	if (p.YMin() < Field.YMin())
	{
		auto clampDiff = Field.YMin() - p.YMin();
		if (glm::abs(clampDiff) > 1e-6 && p.Direction().y < 0)
			p.Direction().y = 0;
		p.Position().y += clampDiff;
	}
	if (p.XMax() > Field.XMax())
	{
		auto clampDiff = Field.XMax() - p.XMax();
		if (glm::abs(clampDiff) > 1e-6 && p.Direction().x > 0)
			p.Direction().x = 0;
		p.Position().x += clampDiff;
	}
	if (p.YMax() > Field.YMax())
	{
		auto clampDiff = Field.YMax() - p.YMax();
		if (glm::abs(clampDiff) > 1e-6 && p.Direction().y > 0)
			p.Direction().y = 0;
		p.Position().y += clampDiff;
	}
}

void Game::Draw()
{
	shader->use();

	Field.Draw(*shader);
	Ball.Draw(*shader);
	PaddleNear.Draw(*shader);
	PaddleFar.Draw(*shader);
}

void Game::CreateVAOs()
{
	shader.reset(new ShaderProgram("Shaders/mvp.vert", "Shaders/fragment.frag"));
	shader->use();

	Field.CreateVAO();
	Ball.CreateVAO();
	PaddleFar.CreateVAO();
	PaddleNear.CreateVAO();
}

Game::~Game()
{
}
