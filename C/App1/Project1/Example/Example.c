#include <stdio.h>
#include <string.h>
#include <stdlib.h>

typedef enum { false, true } bool;
typedef struct { char filePath[100]; } char100;
typedef struct 
{ 	
	int uniqueCode;
	double price; 
	char date[10]; //DD-MM-YYYY
	int duration; 
} charA;

void Menu(char *path);

char100 *FilePath(char100 *path);

void Add(char *path);
void FileRead(char *path);
void ClearFile(char* path);

int main()
{	
	bool exit = false;
	char input[10];
	char filePath[100];
	
	strcpy(filePath, "D:\\Programming\\text.bin");
	
	char100 *path = malloc(sizeof(char100));
	
	while (exit == false)
	{
		Menu(filePath);
		
	
			printf("User> ");
			scanf("%s", &input);
	
		
		switch (atoi(input))
		{
			case 1: 
			{
				path = FilePath(path);
				strcpy(filePath, path->filePath);
				break;
			}
			case 2:
			{
				Add(filePath);
				break;
			}
			case 3: 
			{
				FileRead(filePath);
				break;
			}
			case 4: 
			{
				ClearFile(filePath);
				break;
			}
			case 5: 
			{
				
				break;
			}
			case 6: 
			{
				
				break;
			}
			case 7: 
			{
				exit = true;
				break;
			}
		}
		
		system("cls");
	}
	
	free(path);
	
	return 0;
}

void Menu(char *path)
{
	char path_view[30];
	strcpy(path_view, " - ");
	strcat(path_view, path); 
	
	printf("#################################\n\n");
	printf("1. Choose file(database) %s\n", path);
	printf("2. Add\n");
	printf("3. Read All\n");
	printf("4. Clear File\n");
	printf("6. Remove all\n");
	printf("7. Exit\n\n");
}

char100 *FilePath(char100 *path) 
{	
	printf("\nInput path: ");
	scanf("%s", &path->filePath);
	
	return path;
}

void Add(char *path)
{
	charA *a = malloc(sizeof(charA));
	FILE *file;
	
	printf("\nID of delivery: ");
	scanf("%d", &a->uniqueCode);
	
	
	printf("\nprice: ");
	scanf("%lf", &a->price);
	
	printf("\nDate of delivery(DD-MM-YYYY): ");
	scanf("%s", &a->date);
	
	printf("\nDelivery quantity: ");
	scanf("%d", &a->duration);
	
	printf("\n\nID of delivery: %d", a->uniqueCode);
	printf("\nprice: %lf", a->price);
	printf("\nDate of delivery: %s", a->date);
	printf("\nDelivery quantity: %d\n", a->duration);
	
	system("pause");
	
	file = fopen(path, "ab");
	
	if (file == NULL)
	{
		perror("Error opening the file!");
	}
	else 
	{
		fprintf(file, "\n\nAdd unique code: %d", a->uniqueCode);
		fprintf(file, "\nprice: %lf", a->price);
		fprintf(file, "\nDate of delivery: %s", a->date);
		fprintf(file, "\nDelivery quantity: %d\n", a->duration);
	}
	
	fclose(file);
}

void ClearFile(char* path)
{
	charA* a = malloc(sizeof(charA));
	FILE* file;

	file = fopen(path, "wb");

	if (file == NULL)
	{
		perror("Error opening the file!");
	}
	else
	{
		fprintf(file, "");	
		printf("\nFile cleared!\n\n");
	}

	fclose(file);
}

void FileRead(char *path) 
{
	FILE *file;
	char buffer[255];
	
	file = fopen(path, "rb");
	
	if (!file)
	{
		printf("\nUbable to open the file!\n\n");
	}
	else 
	{
		while (fgets(buffer, sizeof buffer, file))
		{
			printf("%s\n", buffer);
		}
		printf("\n");
	}
	system("pause");
	
	fclose(file);
}

















