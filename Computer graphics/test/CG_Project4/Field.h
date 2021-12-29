#ifndef FieldH
#define FieldH

#include "Drawable.hpp"
#include "VertexTypes.h"
#include <vector>

class Field : public Drawable
{
	const float Width = 80, Height = 60, Depth = 300;
	const int MidLines = 10;

public:

	Field(Game& Game) :
		Drawable(Game)
	{}

	float XMax() const { return Width / 2; }
	float XMin() const { return -Width / 2; }
	float YMax() const { return Height / 2; }
	float YMin() const { return -Height / 2; }
	float ZMax() const { return 0; }
	float ZMin() const { return -Depth; }

	virtual void CreateVAO()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		// Create a Vertex Buffer Object
		FillVertices(Width, Height, Depth, MidLines);

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

		glm::mat4 model;
		model = glm::scale(model, glm::vec3(1.0f, 1.0f, -1.0f));
		shader.setMat4("model", model);
		shader.setVec3("color", glm::vec3(0, 1, 0));

		glDrawArrays(GL_LINES, 0, m_verts.size());
		glBindVertexArray(0);
	}

private:

	std::vector<XYZVertex> m_verts;

	void FillVertices(float w, float h, float d, int midLines)
	{
		// x: -w/2 to w/2
		// y: -h/2 to h/2
		// z: 0 to d

		m_verts.clear();

		float zStep = d / midLines;
		float zPlane = d;
		while (zPlane >= 0)
		{
			m_verts.push_back(XYZVertex(-w / 2, -h / 2, zPlane));
			m_verts.push_back(XYZVertex(-w / 2, h / 2, zPlane));
			m_verts.push_back(XYZVertex(-w / 2, h / 2, zPlane));
			m_verts.push_back(XYZVertex(w / 2, h / 2, zPlane));
			m_verts.push_back(XYZVertex(w / 2, h / 2, zPlane));
			m_verts.push_back(XYZVertex(w / 2, -h / 2, zPlane));
			m_verts.push_back(XYZVertex(w / 2, -h / 2, zPlane));
			m_verts.push_back(XYZVertex(-w / 2, -h / 2, zPlane));

			zPlane -= zStep;
		}

		float xStep = w / midLines, yStep = h / midLines;
		float xPos = -w / 2;
		while (xPos <= w / 2)
		{
			m_verts.push_back(XYZVertex(xPos, -h / 2, 0));
			m_verts.push_back(XYZVertex(xPos, -h / 2, d));
			m_verts.push_back(XYZVertex(xPos, h / 2, 0));
			m_verts.push_back(XYZVertex(xPos, h / 2, d));

			xPos += xStep;
		}

		float yPos = -h / 2;
		while (yPos <= h / 2)
		{
			m_verts.push_back(XYZVertex(-w / 2, yPos, 0));
			m_verts.push_back(XYZVertex(-w / 2, yPos, d));
			m_verts.push_back(XYZVertex(w / 2, yPos, 0));
			m_verts.push_back(XYZVertex(w / 2, yPos, d));

			yPos += yStep;
		}
	}
};

#endif
