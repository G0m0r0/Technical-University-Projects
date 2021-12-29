#ifndef BallH
#define BallH

#include "Drawable.hpp"
#include "VertexTypes.h"
#include <vector>
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>
#include <glm/gtc/constants.hpp>
#include <cmath>
#include "Field.h"
#include "Paddle.h"

class Ball : public Drawable
{
	const float Radius = 5.0f;

	glm::vec3 m_position;
	glm::vec3 m_linearV;
	float m_spinX, m_spinY;
	float m_angleX, m_angleY;
	float m_speedCoef; // movement factor per 1ms

public:

	glm::vec3 Color;

	Ball(Game& Game) :
		Drawable(Game)
	{
		Reset();
	}

	void Reset()
	{
		m_position = glm::vec3(0.0f, 0.0f, -80.0f);
		m_linearV = glm::vec3(.0f, 0.0f, 3.0f);
		m_spinX = m_spinY = m_angleX = m_angleY = 0;
		m_spinY = 1;
		m_spinX = 0.6f;
		m_speedCoef = 20;
		Color = glm::vec3(1, 1, 1);
	}

	const glm::vec3& Position() const { return m_position; }

	float XMax() const { return m_position.x + Radius; }
	float XMin() const { return m_position.x - Radius; }
	float YMax() const { return m_position.y + Radius; }
	float YMin() const { return m_position.y - Radius; }
	float ZMax() const { return m_position.z + Radius; }
	float ZMin() const { return m_position.z - Radius; }

	glm::vec3 CalculatePositionDiff(float timeDelta)
	{
		return timeDelta * m_speedCoef * (m_linearV + glm::vec3(m_speedCoef*timeDelta*m_spinY, m_speedCoef*timeDelta*m_spinX, 0));
	}

	virtual void Animate(float timeDelta)
	{
		m_position += CalculatePositionDiff(timeDelta);

		m_angleX += timeDelta * m_spinX;
		m_angleY += timeDelta * m_spinY;
		if(m_angleX > 2 * glm::pi<float>())
			m_angleX = glm::mod(m_angleX, 2 * glm::pi<float>());
		if (m_angleY > 2 * glm::pi<float>())
			m_angleY = glm::mod(m_angleY, 2 * glm::pi<float>());

	}

	void Bounce(const glm::vec3& normal, const glm::vec3& spin)
	{
		auto reflection = m_linearV - 2 * glm::dot(m_linearV, normal)*normal;
		m_linearV = reflection;

		m_spinX /= 2.f;
		m_spinY /= 2.f;
		m_spinX += spin.y;
		m_spinY += spin.x;

		m_linearV.x -= m_spinY;
		m_linearV.y -= m_spinX;
	}

	void CheckCollisions(float timeDelta);
	bool CheckPaddleCollision(Paddle& paddle, float zPaddleFace, float timeDelta);

	virtual void CreateVAO()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		// Create a Vertex Buffer Object
		FillVertices(20);

		unsigned int vbo;
		glGenBuffers(1, &vbo);
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBufferData(GL_ARRAY_BUFFER, m_verts.size() * sizeof(XYZVertex), m_verts.data(), GL_STATIC_DRAW);

		// Map the vertex attributes
		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(XYZVertex), 0);
		glEnableVertexAttribArray(0);

		glBindVertexArray(0);
	}

	virtual void Draw(ShaderProgram& shader)
	{
		glBindVertexArray(m_vao);

		glm::mat4 model = glm::mat4(1.0f);
		model = glm::translate(model, m_position);
		model = glm::scale(model, glm::vec3(Radius, Radius, Radius));
		model = glm::rotate(model, m_angleX, glm::vec3(1.0f, 0.0f, 0.0f));
		model = glm::rotate(model, m_angleY, glm::vec3(0.0f, 1.0f, 0.0f));
		shader.setMat4("model", model);
		shader.setVec3("color", Color);

		glDrawArrays(GL_LINE_STRIP, 0, m_verts.size());
		glBindVertexArray(0);
	}

private:
	std::vector<XYZVertex> m_verts;

	void FillVertices(int detail)
	{
		// Creates a unit sphere at (0, 0, 0)
		m_verts.reserve(detail*detail);

		float phiStep = glm::pi<float>() / detail;
		float betaStep = 2 * glm::pi<float>() / detail;
		//for (float phi = -glm::pi<float>() / 2; phi <= phiStep * 5 + -glm::pi<float>() / 2; phi += phiStep)
		for (float phi = -glm::pi<float>() / 2; phi <= glm::pi<float>() / 2; phi += phiStep)
		{
			for (float beta = -glm::pi<float>(); beta <= glm::pi<float>(); beta += betaStep)
				m_verts.push_back(XYZVertex(
					glm::cos(phi) * glm::sin(beta),
					glm::cos(phi) * glm::cos(beta),
					glm::sin(phi)
				));
		}

		
	}
};

#endif