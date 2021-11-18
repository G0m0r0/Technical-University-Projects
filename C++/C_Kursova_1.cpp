#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
using namespace std;
 class Matrix
{
  public:
	 int size;
	 int **matrixA;
	 int *B;
	 void inputMatrix()
	 {
		 cout << "Enter size of the Matrix:";
		 cin >> size;
	
		 matrixA = new int*[size];
		 for (size_t i = 0; i < size; i++)
		 {
			 matrixA[i] = new int[size];
		 }
		 for (size_t i = 0; i < size; i++)
		 {
			 for (size_t j = 0; j < size; j++)
			 {
				 cout << "Enter value for element for position [" << i << "]" << "[" << j << "]:";
				 cin >> matrixA[i][j];
			 }
		 }
	 }
	 void inputMatrix(int s, int **test)
	 {
		 
		 size =  s;
		 matrixA = new int*[size];
		 for (size_t i = 0; i < size; i++)
		 {
			 matrixA[i] = new int[size];
		 }
		 for (size_t i = 0; i < size; i++)
		 {
			 for (size_t j = 0; j < size; j++)
			 {				
				 matrixA[i][j] = test[i][j];
			 }
		 }
	 }
     void outputMatrix()
     {
    	 cout << "Matrix A:" << "\n";
    	 for (size_t i = 0; i < size; i++)
    	 {
    		 for (size_t j = 0; j < size; j++)
    		 {
    			 cout << matrixA[i][j] << " ";
    		 }
    		 cout << "\n";
    	 }
     }
	 void saveFile()
	 {
		 ofstream myfile;
		 myfile.open("Matrix.txt");
		 myfile << size << "\n";
		 for (size_t i = 0; i < size; i++)
		 {
			 for (size_t j = 0; j < size; j++)
			 {
				 myfile << matrixA[i][j] << " ";
			 }
			 myfile << "\n";
		 }
		 myfile.close();
		 cout << "Ready!" << "\n";
	 }
	 void loadFile()
	 {
		 ifstream myfile;
		 myfile.open("Matrix.txt");
		 myfile >> size;
		 matrixA = new int*[size];
		 for (size_t i = 0; i < size; i++)
		 {
			 matrixA[i] = new int[size];
		 }
		 for (size_t i = 0; i < size; i++)
		 {
			 for (size_t j = 0; j < size; j++)
			 {			
				 myfile >> matrixA[i][j];
			 }
		 }
		 myfile.close();
		 cout << "Ready!" << "\n";
	 }
	 void sum()
	 {
		 int sum=0;

		 for (size_t i = 0; i < size; i++)
		 {
			 for (size_t j = 0; j < size; j++)
			 {
				 sum += matrixA[i][j];
			 }
		 }
		 cout << "The sum of elements of A:"<<sum<< "\n";
	 }
	 void rowSumArray()
	 {
		 B = new int[size];
		 for (size_t i = 0; i < size; i++)
		 {
			 int sumb = 0;
			 for (size_t j = 0; j < size; j++)
			 {
				sumb += matrixA[i][j];
			 }
			 B[i] = sumb;		
		 }
		 cout << "B:"<< "\n";
		 for (size_t j = 0; j < size; j++)
		 {
			 cout <<B[j] << "\n";
		 }		 
	 }
	 void minMaxB()
	 {
		 int min = B[0];
		 int max = B[0];
		 for (int i = 1; i < size; i++) {
			 if (min > B[i]) {
				 min = B[i];
			 }
			 if (max < B[i]) {
				 max = B[i];
			 }

		 }
		 cout << "Array B Min: "<< min << "\n";
		 cout << "Array B Max: "<< max << "\n";
	 }
 };
