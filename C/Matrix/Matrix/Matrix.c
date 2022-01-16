#include<stdio.h>

int main() {
	printf("Print \n");
	printf("Name: \n\n");

	int size = 3;
	int A[3][3];
	int C[3];

	//c
	int i = 0;
	int j = 0;
	for (i = 0; i < size; i++) {
		for (j = 0; j < size; j++) {
			printf("[%d][%d]:", i, j);

			int input = 0;
			scanf_s("%d", &input);

			if (input < -1000 || input>1000) {
				printf("Number should be between -1000 and 1000!\n");
				j--;
			}
			else
			{
				A[i][j] = input;
			}
		}
	}

	//d
	printf("\nMatrix A:\n");
	for (i = 0; i < size; i++) {
		for (j = 0; j < size; j++) {
			printf("%d ", A[i][j]);
		}
		printf("\n");
	}
	printf("\n");

	//a)
	int index = 0;
	for (i = 1; i < size; i++) {
		for (j = 0; j < size; j++) {
			if (i > j)
			{
				C[index] = A[i][j];
				index++;
			}
		}
	}

	printf("Array C:\n");
	for (j = 0; j < size; j++) {
		printf("%d ", C[j]);
	}

	printf("\n");

	//b)

	for (int i = 0; i < size; i++) {
		for (int j = i + 1; j < size; j++) {
			if (C[i] > C[j]) {
				int temp = C[i];
				C[i] = C[j];
				C[j] = temp;
			}
		}
	}

	printf("Array sorted C:\n");
	for (j = 0; j < size; j++) {
		printf("%d ", C[j]);
	}

	printf("\n");

	return 0;
}
