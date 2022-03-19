#include <iostream>
#include <memory>

#pragma comment(lib, "glfw3.lib")

// GLAD
#include <glad/glad.h>

// GLFW
#include <GLFW/glfw3.h>

// GLM
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

#include "ShaderProgram.hpp"

//  Sean Barrett
#define STB_IMAGE_IMPLEMENTATION
#include "stb_image.h"

//arrays
#include<vector>

// sound
//#include <irrklang/irrKlang.h>
//using namespace irrklang;

using namespace std;
using namespace glm;

void key_callback(GLFWwindow* window, int key, int scancode, int action, int mode);
vec3 ControlBird(GLFWwindow* window);
vec3 ChimneyMove(GLFWwindow* window);
void WindowSettings(GLFWwindow*& window);
void on_error(int code, const char* text);

#include "ShaderProgram.hpp"

// Vertex buffer object to draw
//use same
struct Vertex
{
	float x, y, z;
	float r, g, b;
	float s, t;
	Vertex(float x, float y, float z, float r, float g, float b, float s, float t)
		:x(x), y(y), z(z), r(r), g(g), b(b), s(s), t(t) {}
}; 
//use same
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
	//virtual void Draw(ShaderProgram& shader) = 0;
}; 
//delete
class BackGround : public Drawable {
public:
	vector<Vertex> backVertices;
	vec3 backPosition;

public:
	BackGround(vec3 backPosition) : Drawable(), backPosition(backPosition)
	{
		// positions    // colors         // texture coords
		backVertices.push_back(Vertex(-1.f, -1.f, -1.0f, .00f, .50f, .20f, 0.0f, 0.f)); // top right
		backVertices.push_back(Vertex(1.f, -1.f, -1.0f, .00f, .50f, .20f, 1.0f, 0.f)); // bottom right
		backVertices.push_back(Vertex(-1.f, 1.f, -1.0f, .00f, .50f, .20f, 0.0f, 1.f)); // bottom left
		backVertices.push_back(Vertex(1.f, 1.f, -1.0f, .00f, .50f, .20f, 1.0f, 1.f)); // top left 		
	};

	virtual void CreateVAO()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		unsigned int vbo;
		glGenBuffers(1, &vbo);
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBufferData(GL_ARRAY_BUFFER, backVertices.size() * sizeof(Vertex), backVertices.data(), GL_STATIC_DRAW);

		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), NULL);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, r));
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, s));
		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);
		glEnableVertexAttribArray(2);
		{
			int width, height, nrChannels;
			shared_ptr<unsigned char> data = shared_ptr<unsigned char>(stbi_load("Resources/background.jpg", &width, &height, &nrChannels, 0), stbi_image_free);
			if (!data)
				throw exception("Failed to load texture");

			unsigned texture;
			glGenTextures(1, &texture);
			glActiveTexture(GL_TEXTURE2);
			glBindTexture(GL_TEXTURE_2D, texture);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width, height, 0, GL_RGBA, GL_UNSIGNED_BYTE, data.get());
			glGenerateMipmap(GL_TEXTURE_2D);
		}
	}

	virtual void CreateVAOPunk()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		unsigned int vbo;
		glGenBuffers(1, &vbo);
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBufferData(GL_ARRAY_BUFFER, backVertices.size() * sizeof(Vertex), backVertices.data(), GL_STATIC_DRAW);

		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), NULL);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, r));
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, s));
		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);
		glEnableVertexAttribArray(2);
		{
			int width, height, nrChannels;
			shared_ptr<unsigned char> data = shared_ptr<unsigned char>(stbi_load("Resources/background1.jpg", &width, &height, &nrChannels, 0), stbi_image_free);
			if (!data)
				throw exception("Failed to load texture");

			unsigned texture;
			glGenTextures(1, &texture);
			glActiveTexture(GL_TEXTURE2);
			glBindTexture(GL_TEXTURE_2D, texture);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width, height, 0, GL_RGBA, GL_UNSIGNED_BYTE, data.get());
			glGenerateMipmap(GL_TEXTURE_2D);
		}
	}

	virtual void Draw(ShaderProgram& shader)
	{
		mat4 model = mat4(1.0f);
		glUniform1i(glGetUniformLocation(shader.ID, "ourTexture"), 2);
		glBindVertexArray(m_vao);
		model = translate(model, backPosition);

		model = scale(model, vec3(2.95, 1.65, 1));

		glUniformMatrix4fv(glGetUniformLocation(shader.ID, "model"), 1, GL_FALSE, value_ptr(model));
		glDrawArrays(GL_TRIANGLE_STRIP, 0, backVertices.size());
		glBindVertexArray(0);
	}
};
//delete
class Start : public Drawable {
public:
	vector<Vertex> startVertices;
	vec3 startDirection;
	vec3 startPosition;

public:
	Start(vec3 chimneyPosition) : Drawable(), startPosition(chimneyPosition)
	{
		// positions    // colors         // texture coords
		startVertices.push_back(Vertex(-0.6f, -0.2f, -1.0f, .00f, .50f, .20f, 0.0f, 0.f)); // top right
		startVertices.push_back(Vertex(0.6f, -0.2f, -1.0f, .00f, .50f, .20f, 1.0f, 0.f)); // bottom right
		startVertices.push_back(Vertex(-0.6f, 0.2f, -1.0f, .00f, .50f, .20f, 0.0f, 1.f)); // bottom left
		startVertices.push_back(Vertex(0.6f, 0.2f, -1.0f, .00f, .50f, .20f, 1.0f, 1.f)); // top left 		
	};

	virtual void CreateVAO()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		unsigned int vbo;
		glGenBuffers(1, &vbo);
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBufferData(GL_ARRAY_BUFFER, startVertices.size() * sizeof(Vertex), startVertices.data(), GL_STATIC_DRAW);

		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), NULL);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, r));
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, s));
		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);
		glEnableVertexAttribArray(2);
		{
			int width, height, nrChannels;
			shared_ptr<unsigned char> data = shared_ptr<unsigned char>(stbi_load("Resources/start.jpg", &width, &height, &nrChannels, 0), stbi_image_free);
			if (!data)
				throw exception("Failed to load texture");

			unsigned texture;
			glGenTextures(1, &texture);
			glActiveTexture(GL_TEXTURE3);
			glBindTexture(GL_TEXTURE_2D, texture);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width, height, 0, GL_RGBA, GL_UNSIGNED_BYTE, data.get());
			glGenerateMipmap(GL_TEXTURE_2D);
		}
	}

	void Animate() {
		startPosition += startDirection;
	}

	void Move(GLFWwindow* window) {
		startDirection = ChimneyMove(window);
	}

	virtual void Draw(ShaderProgram& shader)
	{
		mat4 model = mat4(1.0f);
		glUniform1i(glGetUniformLocation(shader.ID, "ourTexture"), 3);
		glBindVertexArray(m_vao);

		model = translate(model, startPosition);

		glUniformMatrix4fv(glGetUniformLocation(shader.ID, "model"), 1, GL_FALSE, value_ptr(model));
		glDrawArrays(GL_TRIANGLE_STRIP, 0, startVertices.size());
		glBindVertexArray(0);
	}
};
//change your object
class Chimney : public Drawable {
public:
	vector<Vertex> chimneyVertices;
	vec3 chimneyPosition;
	vec3 chimneyDirection;

public:
	Chimney(vec3 chimneyPosition) : Drawable(), chimneyPosition(chimneyPosition)
	{
											// positions    // colors         // texture coords
		chimneyVertices.push_back(Vertex(-0.2f, -0.1f, 0.0f, .00f, .50f, .20f, 0.0f, 0.f)); // top right
		chimneyVertices.push_back(Vertex(0.2f, -0.1f, 0.0f, .00f, .50f, .20f, 1.0f, 0.f)); // bottom right
		chimneyVertices.push_back(Vertex(-0.2f, 0.1f, 0.0f, .00f, .50f, .20f, 0.0f, 1.f)); // bottom left
		chimneyVertices.push_back(Vertex(0.2f, 0.1f, 0.0f, .00f, .50f, .20f, 1.0f, 1.f)); // top left 		
	};

	void Animate() {
		chimneyPosition += chimneyDirection;
	}

	void Move(GLFWwindow* window) {
		chimneyDirection = ChimneyMove(window);
	}

	virtual void CreateVAO()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		unsigned int vbo;
		glGenBuffers(1, &vbo);
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBufferData(GL_ARRAY_BUFFER, chimneyVertices.size() * sizeof(Vertex), chimneyVertices.data(), GL_STATIC_DRAW);

		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), NULL);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, r));
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, s));
		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);
		glEnableVertexAttribArray(2);
		{
			int width, height, nrChannels;
			shared_ptr<unsigned char> data = shared_ptr<unsigned char>(stbi_load("Resources/chimney.jpg", &width, &height, &nrChannels, 0), stbi_image_free);
			if (!data)
				throw exception("Failed to load texture");

			unsigned texture;
			glGenTextures(1, &texture);
			glActiveTexture(GL_TEXTURE1);
			glBindTexture(GL_TEXTURE_2D, texture);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, data.get());
			glGenerateMipmap(GL_TEXTURE_2D);
		}
	}

	virtual void CreateVAOPunk()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		unsigned int vbo;
		glGenBuffers(1, &vbo);
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBufferData(GL_ARRAY_BUFFER, chimneyVertices.size() * sizeof(Vertex), chimneyVertices.data(), GL_STATIC_DRAW);

		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), NULL);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, r));
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, s));
		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);
		glEnableVertexAttribArray(2);
		{
			int width, height, nrChannels;
			shared_ptr<unsigned char> data = shared_ptr<unsigned char>(stbi_load("Resources/chimney2.jpg", &width, &height, &nrChannels, 0), stbi_image_free);
			if (!data)
				throw exception("Failed to load texture");

			unsigned texture;
			glGenTextures(1, &texture);
			glActiveTexture(GL_TEXTURE1);
			glBindTexture(GL_TEXTURE_2D, texture);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, data.get());
			glGenerateMipmap(GL_TEXTURE_2D);
		}
	}

	float otherScaleY = 0;
	virtual void Draw(ShaderProgram& shader, float rotation, float scaleY)
	{
		mat4 model = mat4(1.0f);
		glUniform1i(glGetUniformLocation(shader.ID, "ourTexture"), 1);
		glBindVertexArray(m_vao);
		model = translate(model, chimneyPosition);
		model = rotate(model, rotation, vec3(0.f, 0.f, 1.f));

		model = scale(model, vec3(1, scaleY, 1));
		otherScaleY = scaleY;

		glUniformMatrix4fv(glGetUniformLocation(shader.ID, "model"), 1, GL_FALSE, value_ptr(model));
		glDrawArrays(GL_TRIANGLE_STRIP, 0, chimneyVertices.size());
		glBindVertexArray(0);
	}

	vec3& Position() { return chimneyPosition; }

	float xMax() const { return chimneyPosition.x + 0.2f; }
	float xMin() const { return chimneyPosition.x - 0.2; }
	float yMax() const { return chimneyPosition.y + 0.1 * otherScaleY; }
	float yMin() const { return chimneyPosition.y - 0.1 * otherScaleY; }
};
//change your object
class Bird : public Drawable {
public:
	vector<Vertex> birdVertices;
	vec3 birdPosition;
	vec3 birdDirection;

public:
	Bird(vec3 birdPosition) : Drawable(), birdPosition(birdPosition)
	{
										// positions    // colors         // texture coords
		birdVertices.push_back(Vertex(-0.13f, -0.13f, 0.0f, .00f, .50f, .20f, 0.0f, 0.f)); // top right
		birdVertices.push_back(Vertex(0.13f, -0.13f, 0.0f, .00f, .50f, .20f, 1.0f, 0.f)); // bottom right
		birdVertices.push_back(Vertex(-0.13f, 0.13f, 0.0f, .00f, .50f, .20f, 0.0f, 1.f)); // bottom left
		birdVertices.push_back(Vertex(0.13f, 0.13f, 0.0f, .00f, .50f, .20f, 1.0f, 1.f)); // top left 		
	};

	void Animate() {
		birdPosition += birdDirection * 1.4f;

		BirdBorders();
	}

	void Move(GLFWwindow* window) {
		birdDirection = ControlBird(window);
	}

	virtual void CreateVAO()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		unsigned int vbo;
		glGenBuffers(1, &vbo);
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBufferData(GL_ARRAY_BUFFER, birdVertices.size() * sizeof(Vertex), birdVertices.data(), GL_STATIC_DRAW);

		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), NULL);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, r));
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, s));
		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);
		glEnableVertexAttribArray(2);
		{
			int width, height, nrChannels;
			shared_ptr<unsigned char> data = shared_ptr<unsigned char>(stbi_load("Resources/bird.png", &width, &height, &nrChannels, 0), stbi_image_free);
			if (!data)
				throw exception("Failed to load texture");

			unsigned texture;
			glGenTextures(1, &texture);
			glActiveTexture(GL_TEXTURE0);
			glBindTexture(GL_TEXTURE_2D, texture);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width, height, 0, GL_RGBA, GL_UNSIGNED_BYTE, data.get());
			glGenerateMipmap(GL_TEXTURE_2D);
		}
	}

	virtual void CreateVAOPunk()
	{
		glGenVertexArrays(1, &m_vao);
		glBindVertexArray(m_vao);

		unsigned int vbo;
		glGenBuffers(1, &vbo);
		glBindBuffer(GL_ARRAY_BUFFER, vbo);
		glBufferData(GL_ARRAY_BUFFER, birdVertices.size() * sizeof(Vertex), birdVertices.data(), GL_STATIC_DRAW);

		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), NULL);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, r));
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, s));
		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);
		glEnableVertexAttribArray(2);
		{
			int width, height, nrChannels;
			shared_ptr<unsigned char> data = shared_ptr<unsigned char>(stbi_load("Resources/bird1.png", &width, &height, &nrChannels, 0), stbi_image_free);
			if (!data)
				throw exception("Failed to load texture");

			unsigned texture;
			glGenTextures(1, &texture);
			glActiveTexture(GL_TEXTURE0);
			glBindTexture(GL_TEXTURE_2D, texture);

			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
			glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

			glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width, height, 0, GL_RGBA, GL_UNSIGNED_BYTE, data.get());
			glGenerateMipmap(GL_TEXTURE_2D);
		}
	}

	virtual void Draw(ShaderProgram& shader)
	{
		glUniform1i(glGetUniformLocation(shader.ID, "ourTexture"), 0);
		glBindVertexArray(m_vao);
		mat4 model = mat4(1.0f);
		model = translate(model, birdPosition);

		RotateBird(model);

		glUniformMatrix4fv(glGetUniformLocation(shader.ID, "model"), 1, GL_FALSE, value_ptr(model));
		glDrawArrays(GL_TRIANGLE_STRIP, 0, birdVertices.size());
		glBindVertexArray(0);
	}

	vec3& Position() { return birdPosition; }

	float xMax() const { return birdPosition.x + 0.13f; }
	float xMin() const { return birdPosition.x - 0.13; }
	float yMax() const { return birdPosition.y + 0.13; }
	float yMin() const { return birdPosition.y - 0.13; }

private:
	float birdPostionOldY = birdPosition.y;
	void RotateBird(mat4& model)
	{
		if (birdPosition.y < birdPostionOldY) {
			model = rotate(model, -0.5f, vec3(0.f, 0.f, 1.f));
		}
		else if (birdPosition.y > birdPostionOldY) {
			model = rotate(model, 0.5f, vec3(0.f, 0.f, 1.f));
		}

		birdPostionOldY = birdPosition.y;
	}

	void BirdBorders()
	{
		if (birdPosition.x < -2) {
			birdPosition.x = -2;
		}
		else if (birdPosition.x > 0.6) {
			birdPosition.x = 0.6f;
		}

		if (birdPosition.y < -1) {
			birdPosition.y = -1;
			//TODO: dying when falls below
		}
		else if (birdPosition.y > 1) {
			birdPosition.y = 1;
		}
	}
};
//delete inside methods and change with your logic
class Game
{
private:
	bool punkMod = false;

public:
	Bird bird = Bird(vec3(-2, 0, 0.0f));
	BackGround background = BackGround(vec3(0, 0, 0));
	Start start = Start(vec3(-1.5f, 1.f, 0));
	vector<unique_ptr<Chimney>> chimneys;

	void GenerateChimney() {
		for (size_t i = 0; i < 30; i++)
		{
			int indX = i + 1;
			chimneys.push_back(make_unique<Chimney>(vec3(indX, -1.05, 0.f)));
			chimneys.push_back(make_unique<Chimney>(vec3(indX, 1.05, 0.f)));
		}

		GenerateChimneySizes();
	}

	unique_ptr<ShaderProgram> shader;

	void SetView(const mat4& view)
	{
		glUniformMatrix4fv(glGetUniformLocation(shader->ID, "view"), 1, GL_FALSE, value_ptr(view));
	}

	void SetProjection(const mat4& proj)
	{
		glUniformMatrix4fv(glGetUniformLocation(shader->ID, "projection"), 1, GL_FALSE, value_ptr(proj));
	}

private:
	int lengthChimney[60];
	void GenerateChimneySizes() {
		for (size_t i = 0; i < 30; i++)
		{
			int rnd = rand() % 11 + 2; //generets size from 2 to 12 

			lengthChimney[i] = rnd;
			lengthChimney[59 - i] = 12 - rnd + 2; //2 for starting size 12 for eding size
		}
	}
	int indexChimneyNotToDisplayBack = 0;

public:
	void Animate(GLFWwindow* window)
	{
		bird.Move(window);
		bird.Animate();

		if (start.startPosition.x > -5) {
			start.Move(window);
			start.Animate();
		}

		bool isup = false;
		bool isdown = false;
		for (size_t i = indexChimneyNotToDisplayBack; i < chimneys.size(); i++) //TODO: dont draw all
		{
			if (chimneys.at(i)->xMin() < -3) {
				indexChimneyNotToDisplayBack = i;
			}

			chimneys.at(i)->Move(window);
			chimneys.at(i)->Animate();

			CollisionWithChimney(i, isdown, isup);
		}

		if (isup)
		{
			cout << "You hit upper chimney!" << endl;
			exit(1);
		}

		if (isdown)
		{
			cout << "You hit down chimney!" << endl;
			exit(1);
		}
	}

	void CollisionWithChimney(const size_t& i, bool& isdown, bool& isup)
	{
		if (i % 2 == 0) {
			if (bird.xMax() > chimneys.at(i)->xMin()
				&& bird.yMin() < chimneys.at(i)->yMax()
				&& bird.xMin() < chimneys.at(i)->xMax()) {
				isdown = true;
			}
		}
		else
		{
			if (bird.xMax() > chimneys.at(i)->xMin()
				&& bird.yMax() > chimneys.at(i)->yMin()
				&& bird.xMin() < chimneys.at(i)->xMax()) {
				isup = true;
			}
		}
	}
private:
	int scoreMax = 0;

public:
	void Score()
	{
		for (size_t i = 0; i < chimneys.size(); i++)
		{
			//if (chimneys.at(i)->xMin() < -3) {
			//	indexChimneyNotToDisplayBack = i;
			//}

			if (chimneys.at(i)->xMax() > 3) {
				break;
			}
			if (i % 2 != 0)
				if (scoreMax < i + 1 && bird.xMax()>chimneys.at(i)->xMax()) {
					scoreMax++;
					cout << "Score: " << scoreMax << " points." << endl;
					break;
				}
		}
	}

	int arrSize = sizeof(lengthChimney) / sizeof(lengthChimney[0]);

	void Draw()
	{
		background.Draw(*shader);
		bird.Draw(*shader);

		if (start.startPosition.x > -5)
			start.Draw(*shader);

		for (size_t i = 0; i < chimneys.size(); i++)
		{
			if (chimneys.at(i)->xMin() < -3) {
				indexChimneyNotToDisplayBack = i;
			}

			if (chimneys.at(i)->xMax() > 3) {
				break;
			}

			if (indexChimneyNotToDisplayBack == 10 && punkMod == 0) {
				punkMod = true;
				cout << "Punk mode is active!";
				bird.CreateVAOPunk();
				background.CreateVAOPunk();

				for (size_t i = 0; i < chimneys.size(); i++)
				{
					chimneys.at(i)->CreateVAOPunk();
				}
			}

			if (chimneys.at(i)->xMin() > -3)
				if (i % 2 == 0)
					chimneys.at(i)->Draw(*shader, 0, lengthChimney[i]);
				else
					chimneys.at(i)->Draw(*shader, -3.145f, lengthChimney[arrSize - i]);
		}
	}

	bool displayStart = true;

	void CreateVAOs()
	{
		shader.reset(new ShaderProgram("Shaders/mvp.vert", "Shaders/fragment.frag"));
		shader->use();

		if (displayStart)
		{
			displayStart = false;
		}
		background.CreateVAO();
		start.CreateVAO();

		GenerateChimney();

		bird.CreateVAO();
		for (size_t i = 0; i < chimneys.size(); i++)
		{
			chimneys.at(i)->CreateVAO();
		}
	}

	Game::~Game()
	{
	}
};

const GLuint WIDTH = 1280, HEIGHT = 720;

int main()
{
	cout << "Starting GLFW context, OpenGL 3.3" << endl;
	// Init GLFW
	glfwInit();

	try
	{
		GLFWwindow* window;
		WindowSettings(window);

		Game Game;

		glfwSetWindowUserPointer(window, (void*)&Game);
		glfwSetKeyCallback(window, key_callback);

		Game.CreateVAOs();

		// View
		mat4 view;
		view = translate(view, vec3(0.0f, 0.0f, -3.0f)); 
		//view = translate(view, vec3(0.0f, -100.0f, -180.0f));
		//view = rotate(view, radians(90.0f), vec3(1.0f, 0.0f, 0.0f));

		// Projection
		mat4 projection;
		projection = perspective(radians(45.0f), (float)WIDTH / HEIGHT, 1.0f, 1200.0f);

		Game.SetView(view);
		Game.SetProjection(projection);

		while (!glfwWindowShouldClose(window))
		{
			glfwPollEvents();

			// Render
			glClear(GL_DEPTH_BUFFER_BIT);
			// Clear the colorbuffer
			glClearColor(1, 0.f, 1, 1.0f);
			glClear(GL_COLOR_BUFFER_BIT);

			Game.Animate(window);
			Game.Draw();
			Game.Score();

			// Swap the screen buffers
			glfwSwapBuffers(window);
		}
	}
	catch (exception& e)
	{
		cout << "Unexpected error: " << e.what() << endl;
		cin.get();
	}

	// Terminates GLFW, clearing any resources allocated by GLFW.
	glfwTerminate();

	return 0;
}

void WindowSettings(GLFWwindow*& window)
{
	stbi_set_flip_vertically_on_load(true);// Tell stb to filp images so that 0.0 is at the bottom of the y-axis

	glfwSetErrorCallback(on_error);

	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
	glfwWindowHint(GLFW_RESIZABLE, GL_FALSE);

	window = glfwCreateWindow(WIDTH, HEIGHT, "OpenGL Window", NULL, NULL);
	glfwMakeContextCurrent(window);
	if (window == NULL)
		throw exception("Failed to create GLFW window");

	glfwSetKeyCallback(window, key_callback);

	if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
		throw exception("Failed to initialize OpenGL context");

	// Define the viewport dimensions
	glViewport(0, 0, WIDTH, HEIGHT);
}

vec3 ChimneyMove(GLFWwindow* window)
{
	vec3 result;

	result.x -= 0.01f;

	return result;
}

vec3 ControlBird(GLFWwindow* window)
{
	vec3 result;

	if (glfwGetKey(window, GLFW_KEY_W) == GLFW_PRESS)
	{
		result.y += 0.03f;
		result.x += 0.001f;
	}
	else if (glfwGetKey(window, GLFW_KEY_M) == GLFW_PRESS) //make game harder
	{
		result.x += 0.01f;
	}
	else if (glfwGetKey(window, GLFW_KEY_N) == GLFW_PRESS) //make game harder
	{
		result.x -= 0.01f;
		//TODO: game logic consume coins for going back
	}
	else
	{
		result.y -= 0.005f;
	}
	//GLFW_MOUSE_BUTTON_LEFT

	return result;
}

void key_callback(GLFWwindow* window, int key, int scancode, int action, int mode)
{
	//cout << key << endl;
	if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
		glfwSetWindowShouldClose(window, GL_TRUE);
}

void on_error(int code, const char* text)
{
	cout << "Error code: " << code << " Error text: " << text << endl;
}
