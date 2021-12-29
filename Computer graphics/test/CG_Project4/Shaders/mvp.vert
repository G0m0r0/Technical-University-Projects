#version 330 core
layout (location = 0) in vec3 aPos;

uniform vec3 color;
out vec3 ourColor;

uniform mat4 model, view, projection;

void main()
{
	gl_Position = projection * view * model * vec4(aPos, 1.0);
	ourColor = color;
}
