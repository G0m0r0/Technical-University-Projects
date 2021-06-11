#include <ctype.h>
#include <string.h>
#include <stdio.h> 
#include <stdlib.h>
#include <malloc.h>

struct Catalogue {
	char catalogueNumber[20];
	char title[80];
	char author[50];
	int price;
	int yearOfProduction;
	char publishing[80];
	struct Catalogue* next;
};
static struct Catalogue* head = NULL;
struct Catalogue* Catalogue;

//My methods
void DisplayMenu();
void AddBook(char* filePath);
void ReadFromFile(char* filePath);
void CatalogueByTitle(char* title);
void ShowAllBookPublishing(char* publishingName);
struct Catalogue* addBook(char* catalogueNumber, char* title, char* author, int* price, int* yearOfProduction, char* publishing);

int main()
{
	int numExit = -1; //break condition
	char inputData[1] = " "; //because number are to 9
	char filePath[260] = " "; //max allowed file filePath in windows

	strcpy(filePath, "D:\\Programming\\books.bin");

	while (numExit == -1)
	{
		DisplayMenu();

		printf("Option: ");
		scanf("%s", &inputData);
		int num = atoi(inputData);


		switch (num)
		{
		case 1:
		{
			AddBook(filePath);
			break;
		}
		case 2:
		{
			ReadFromFile(filePath);
			break;
		}
		case 3:
		{			
			break;
		}
		case 4:
		{
			char publishingName[80];
			printf("\nPublishing name- ");
			scanf("%s", &publishingName);
			printf("\n-----------------------\n");

			ShowAllBookPublishing(publishingName);
			break;
		}
		case 5:
		{
			char title[80];
			printf("\nCatalague title-  ");
			scanf("%s", &title);
			printf("\n-----------------------\n");

			CatalogueByTitle(title);
			break;
		}
		case 6:
		{
			numExit = 1; //break condition
			break;
		}
		}

		system("cls");
	}

	return 0;
}

void DisplayMenu()
{
	printf("---Enter number/Choose option!---\n\n");
	printf("1. Input data for new Catalogue\n");
	printf("2. Read data from file\n");
	printf("3. Update information by catalogue number\n");
	printf("4. All books from publishing\n");
	printf("5. Search for catalogue by title\n");
	printf("6. Exit program\n\n");
}

struct Catalogue* addBook(char* catalogueNumber, char* title, char* author, int* price, int* yearOfProduction, char* publishing) {
	struct Catalogue* token = NULL;
	token = malloc(sizeof * token); //allocate needed memory

	if (token == NULL) {
		perror("Error with adding Catalogue!");
	}
	else
	{ // add Catalogue
		strncpy(token->catalogueNumber, catalogueNumber, 20);
		strncpy(token->title, title, 80);
		strncpy(token->author, author, 50);
		token->price = price;
		token->yearOfProduction = yearOfProduction;
		strncpy(token->publishing, publishing, 80);
	}
	return token;
}

void AddBook(char* filePath)
{
	char catalogueNumber[20] = " ";
	printf("\nCatalogue Number: ");
	scanf("%s", &catalogueNumber);
	char title[80] = " ";
	printf("Title: ");
	scanf("%s", &title);
	char author[50] = " ";
	printf("Author:  ");
	scanf("%s", &author);
	int price = 0;
	printf("Price: ");
	scanf("%d", &price);
	int yearOfProduction = 0;
	printf("Year of production: ");
	scanf("%d", &yearOfProduction);
	char publishing[80] = " ";
	printf("Publishing:  ");
	scanf("%s", &publishing);

	Catalogue = addBook(catalogueNumber, title, author, price, yearOfProduction, publishing);
	Catalogue->next = head;  //moving the head to next one
	head = Catalogue;

	FILE* file;
	file = fopen(filePath, "ab"); //open, append or create the file for binary writing

	if (file != NULL)
	{ //save to file with fprintf
		fprintf(file, "\n\nCatalogue number: %s", &catalogueNumber);
		fprintf(file, "\nTitle: %s", &title);
		fprintf(file, "\nAuthor: %s", &author);
		fprintf(file, "\nPrice: %d", price);
		fprintf(file, "\nYear of production: %d", yearOfProduction);
		fprintf(file, "\nPublishing: %s", &publishing);
	}
	else
	{
		perror("Error opening the file!");
	}

	system("pause");

	fclose(file);
}

void ReadFromFile(char* filePath)
{
	FILE* file;
	char buffer[255]; //create standart buffer size

	file = fopen(filePath, "rb"); //open file for binary reading

	if (!file)
	{
		printf("\nUbable to open the file!\n\n");
	}
	else
	{ //reading the file by chunks
		while (fgets(buffer, sizeof buffer, file))
		{
			printf("%s", buffer);
		}
		printf("\n");
	}
	system("pause");

	fclose(file);
}

void CatalogueByTitle(char* title) {
	struct Catalogue* token = head;
	int compare = -1; //initial value
	while (token)
	{
		compare = strcmp(title, token->title); //compare values, output 0 for equal values
		if (compare == 0) {
			printf("\n\nTitle: %s (num %s)", token->title, token->catalogueNumber);
			printf("\nAuthor: %s, published by %s on %d", token->author, token->publishing, token->yearOfProduction);
			printf("\nPrice: %d $", token->price);
			printf("\n");
		}
		token = token->next;
	}

	system("pause");
}

void ShowAllBookPublishing(char* publishingName) {
	struct Catalogue* token = head;
	int compare = -1; //initial value
	while (token)
	{
		compare = strcmp(publishingName, token->publishing); //compare values, output 0 for equal values
		if (compare == 0) {
			printf("\n Publishing name %s on %d by Author: %s", token->publishing, token->yearOfProduction, token->author);
			printf("\n\nTitle: %s (num %s)", token->title, token->catalogueNumber);
			printf("\nPrice: %d $", token->price);
			printf("\n");
		}
		token = token->next;
	}

	system("pause");
}
















