#ifndef PaddleH
#define PaddleH

#include "Drawable.hpp"
#include "VertexTypes.h"
#include <vector>
#include <glm/gtc/matrix_transform.hpp>
#include "IController.h"

class IController;

class Paddle : public Drawable
{
	const float Width = 20, Height = 15, Depth = 5;

	glm::vec3 m_position;
	glm::vec3 m_direction;
	float m_speedCoef; // movement per 1ms

	std::unique_ptr<IController> m_pController;

public:

	Paddle(Game& Game, const glm::vec3& pos) :
		Drawable(Game),
		m_position(pos),
		m_direction(0.0f, 0.0f, 0.0f),
		m_speedCoef(20)
	{
	}

	const glm::vec3& Direction() const { return m_direction; }
	glm::vec3& Direction() { return m_direction; }

	const glm::vec3& Position() const { return m_position; }
	glm::vec3& Position() { return m_position; }

	float XMax() const { return m_position.x + Width/2; }
	float XMin() const { return m_position.x - Width/2; }
	float YMax() const { return m_position.y + Height/2; }
	float YMin() const { return m_position.y - Height/2; }
	float ZMax() const { return m_position.z + Depth/2; }
	float ZMin() const { return m_position.z - Depth/2; }

	void SetController(std::unique_ptr<IController> pController) { m_pController.reset(pController.release()); }

	virtual void Move()
	{
		if (m_pController)
			m_direction = m_pController->MoveDirection();
	}

	virtual void Animate(float timeDelta)
	{
		m_position += timeDelta * m_speedCoef * m_direction;
	}

	virtual void CreateVAO()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		// Create a Vertex Buffer Object
		FillVertices();

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
		shader.setMat4("model", model);
		shader.setVec3("color", glm::vec3(1, 1, 1));

		glDrawArrays(GL_LINES, 0, m_verts.size());
		glBindVertexArray(0);
	}

private:

	std::vector<XYZVertex> m_verts;

	void FillVertices()
	{
		// x: -w/2 to w/2
		// y: -h/2 to h/2
		// z: -d/2 to d/2

		m_verts.clear();
		m_verts.reserve(24);

		m_verts.push_back(XYZVertex(-Width / 2, -Height / 2, -Depth /2));
		m_verts.push_back(XYZVertex(-Width / 2, Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(-Width / 2, Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, -Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, -Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(-Width / 2, -Height / 2, -Depth / 2));

		m_verts.push_back(XYZVertex(-Width / 2, -Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(-Width / 2, Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(-Width / 2, Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, -Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, -Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(-Width / 2, -Height / 2, Depth / 2));

		m_verts.push_back(XYZVertex(-Width / 2, -Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(-Width / 2, -Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, -Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, -Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(-Width / 2, Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(-Width / 2, Height / 2, Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, Height / 2, -Depth / 2));
		m_verts.push_back(XYZVertex(Width / 2, Height / 2, Depth / 2));
	}
};

#endif
