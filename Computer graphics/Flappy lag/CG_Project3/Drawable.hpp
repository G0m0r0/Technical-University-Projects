#ifndef DrawableH
#define	DrawableH

#include "ShaderProgram.hpp"

class Drawable
{
protected:

	unsigned m_vao;

public:

	Drawable()
	{
		m_vao = 0;
	}

	~Drawable()
	{
		glDeleteVertexArrays(1, &m_vao);
	}

	// Override to create the VAO. Save it to m_vao.
	virtual void CreateVAO() = 0;

	virtual void Animate(float timeDelta) {}
	virtual void Draw(ShaderProgram& shader) = 0;
};

#endif
