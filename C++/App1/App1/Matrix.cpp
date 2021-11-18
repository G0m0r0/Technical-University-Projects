#include <iostream>
#include <fstream>
#include <string>
#include <sstream>

using namespace std;
class Matrix
{
public:
	int size;
	int** A;
	int* B;

	Matrix(int s)
	{
		size = s;
		A = new int* [size];
		B = new int[size];
	}

    void FillMatrix()
	{
		for (auto i = 0; i < size; i++)
		{
			A[i] = new int[size];
			for (auto j = 0; j < size; j++)
			{
				cout << "[" << i << "]" << "[" << j << "]= ";
				cin >> A[i][j];
			}
		}
		cout << endl;
	}

	void PrintA()
	{
		cout << "Matrix A:" << endl;
		for (auto i = 0; i < size; i++)
		{
			for (auto j = 0; j < size; j++)
			{
				cout << A[i][j] << " ";
			}
			cout << endl;
		}
	}

	void PrintB() {
		cout << "Array B: ";
		for (auto i = 0; i < size; i++)
		{
			cout << B[i] << " ";
		}
		cout << endl;
	}

	void SaveToFile()
	{
		ofstream myfile;
		myfile.open("Matrix.txt");
		myfile << size << endl;

		for (auto i = 0; i < size; i++)
		{
			for (auto j = 0; j < size; j++)
			{
				myfile << A[i][j] << " ";
			}
			myfile << endl;
		}

		myfile.close();
		cout << "Successfully saved to file!" << endl;
	}

	void LoadFromFile()
	{
		ifstream myfile;
		myfile.open("Matrix.txt");
		myfile >> size;

		for (auto i = 0; i < size; i++)
		{
			A[i] = new int[size];
			for (auto j = 0; j < size; j++)
			{
				myfile >> A[i][j];
			}
		}

		myfile.close();
		cout << "Successfully loaded from file!" << endl;
	}

	void Sum()
	{
		int sum = 0;

		for (auto i = 0; i < size; i++)
		{
			for (auto j = 0; j < size; j++)
			{
				sum += A[i][j];
			}
		}

		cout << "Sum A: " << sum << endl <<endl;
	}

	void SumByRows()
	{
		for (auto i = 0; i < size; i++)
		{
			int sum = 0;
			for (auto j = 0; j < size; j++)
			{
				sum += A[i][j];
			}
			B[i] = sum;
		}
	}

	void MaxB()
	{
		int max = B[0];
		for (int i = 1; i < size; i++) {
			if (max < B[i]) {
				max = B[i];
			}
		}
		cout << "Max B: " << max << endl;
	}

	void MinB()
	{
		int min = B[0];
		for (int i = 1; i < size; i++) {
			if (min > B[i]) {
				min = B[i];
			}
		}
		cout << "Min B: " << min << endl << endl;
	}
};

