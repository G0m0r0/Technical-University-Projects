#include <iostream>
#include "Matrix.cpp"

int main()
{
	cout << "Enter size of the Matrix: ";
	int size=0;
	cin >> size;
	Matrix matrix= Matrix(size);

	matrix.FillMatrix();

	matrix.PrintA();
	matrix.Sum();

	matrix.SumByRows();
	matrix.PrintB();
	matrix.MaxB();
	matrix.MinB();

	matrix.SaveToFile();
	matrix.LoadFromFile();
}

