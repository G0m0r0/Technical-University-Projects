#ifndef DrawableH
#define	DrawableH

#include "ShaderProgram.hpp"

class Game;

class Drawable
{
protected:

	unsigned m_vao;
	Game& m_game;

public:

	Drawable(Game& Game)
		:
		m_game(Game)
	{
		m_vao = 0;
	}

	~Drawable()
	{
		glDeleteVertexArrays(1, &m_vao);
	}

	Game& GetGame() { return m_game; }

	// Override to create the VAO. Save it to m_vao.
	virtual void CreateVAO() = 0;

	virtual void Animate(float timeDelta) {}
	virtual void Draw(ShaderProgram& shader) = 0;
};

#endif
