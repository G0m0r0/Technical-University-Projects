#include <stdio.h>
#include <string.h>
#include <stdlib.h>

struct mobile {
	int nomenclatureNumber;
	char model[20];
	int price;
	int manufactureYear;
	struct mobile* next;
};

struct mobile* addToList(int* nomenclatureNumber, char* model,
	int* price, int* manufactureYear) {

	struct mobile* toAdd = NULL;
	toAdd = malloc(sizeof * toAdd);

	if (toAdd != NULL) {
		toAdd->nomenclatureNumber = nomenclatureNumber;
		strncpy(toAdd->model, model, 20);
		toAdd->price = price;
		toAdd->manufactureYear = manufactureYear;
	}
	return toAdd;
}

typedef struct { char filePath[100]; } char100; //file path as struckt
char100* FilePath(char100* path);
void Menu(char* path); 
void AddNew(char* path);
void FileRead(char* path);
void ClearFileInfo(char* path);
void GetInformationForPriceAboveGiven(int* price);
void ShowInfoByNomenclatureNumber(int* nomenclaturNumber);
void ShowAllInfoFromList();

static struct mobile* head = NULL;
struct mobile* st;

int main()
{
	int exit = -1;
	char input[10];
	char filePath[100];

	strcpy(filePath, "Enter test directory");

	char100* path = malloc(sizeof(char100));

	while (exit == -1)
	{
		Menu(filePath);

		printf("Input> ");
		scanf("%s", &input);


		switch (atoi(input))
		{
		case 0:
		{
			path = FilePath(path);
			strcpy(filePath, path->filePath);
			break;
		}
		case 1:
		{
			AddNew(filePath);
			break;
		}
		case 2:
		{
			FileRead(filePath);
			break;
		}
		case 3:
		{
			ClearFileInfo(filePath);
			break;
		}
		case 4:
		{
			int priceToLookFor = 0;
			printf("\nSet price to look over: ");
			scanf_s("%d", &priceToLookFor);
			GetInformationForPriceAboveGiven(priceToLookFor);
			break;
		}
		case 5:
		{
			int nomenclatureNumberToLookFor = 0;
			printf("\nNomenclature number: ");
			scanf_s("%d", &nomenclatureNumberToLookFor);
			ShowInfoByNomenclatureNumber(nomenclatureNumberToLookFor);
			break;
		}
		case 6:
		{
			ShowAllInfoFromList();
			break;
		}
		case 7:
		{
			exit = 1;
			break;
		}
		}

		system("cls");
	}

	free(path);

	return 0;
}

void Menu(char* path)
{
	char path_view[30];
	strcpy(path_view, " - ");
	strcat(path_view, path);

	printf("-------------------------------------------------\n");
	printf("0. Choose file(enter path)/ Current: %s\n", path);
	printf("1. Enter mobile information\n");
	printf("2. Show all information(From file and list)\n");
	printf("3. Clear File information\n");
	printf("4. Get information for price above entered\n");
	printf("5. Show information by nomenclature number\n");
	printf("6. Show all information(From list)\n");
	printf("7. Exit\n");
	printf("-------------------------------------------------\n");
}

char100* FilePath(char100* path)
{
	printf("\nInput file path: ");

	scanf("%s", &path->filePath);

	return path;
}

void AddNew(char* path)
{
	int nomenclatureNumber; char modelName[20];
	int price; int manufactureYear;
	struct mobile* next;

	printf("\nNomenclature number: ");
	scanf_s("%d", &nomenclatureNumber);
	printf("Model name: ");
	scanf("%s", &modelName);
	printf("Price:  ");
	scanf_s("%d", &price);
	printf("Manufacturing year: ");
	scanf_s("%d", &manufactureYear);

	st = addToList(nomenclatureNumber, modelName, price, manufactureYear);
	st->next = head;
	head = st;

	system("pause");
	FILE* file;
	file = fopen(path, "ab");

	if (file == NULL)
	{
		perror("Error opening the file!");
	}
	else
	{
		fprintf(file, "\n\nNomenclature number: %d", nomenclatureNumber);
		fprintf(file, "\nModel name: %s", &modelName);
		fprintf(file, "\nPrice: %d", price);
		fprintf(file, "\nManufacturing year: %d", manufactureYear);
	}

	fclose(file);
}

void ClearFileInfo(char* path)
{
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

	system("pause");

	fclose(file);
}

void FileRead(char* path)
{
	FILE* file;
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
			printf("%s", buffer);
		}
		printf("\n");
		printf("\n");
	}
	system("pause");

	fclose(file);
}

void GetInformationForPriceAboveGiven(int* price) {
	int flag = -1;
	struct mobile* tmp = head;
	while (tmp)
	{
		if (tmp->price > price) {
			printf("\nNomenclature number: %d", tmp->nomenclatureNumber);
			printf("\nModel name: %s", tmp->model);
			printf("\nPrice: %d", tmp->price);
			printf("\nManufacturing year: %d", tmp->manufactureYear);
			flag = 1;
		}
		tmp = tmp->next;

		printf("\n");
		printf("\n");
	}
	if (flag == -1) {
		printf("\nThere is no mobiles with price higher than %d! \n\n", price);
	}

	system("pause");
}

void ShowInfoByNomenclatureNumber(int* nomenclatureNumber) {
	int flag = -1;

	struct mobile* tmp = head;
	while (tmp)
	{
		if (nomenclatureNumber == tmp->nomenclatureNumber) {
			printf("\nModel name: %s", tmp->model);
			printf("\nPrice: %d", tmp->price);
			printf("\nManufacturing year: %d", tmp->manufactureYear);
			flag = 1;
		}
		tmp = tmp->next;

		printf("\n");
		printf("\n");
	}
	if (flag == -1) {
		printf("\nNumber %d was not found! \n\n", nomenclatureNumber);
	}

	system("pause");
}

void ShowAllInfoFromList() {
	int flag = -1;

	struct mobile* tmp = head;
	while (tmp)
	{
		printf("\nNomenclature number: %d", tmp->nomenclatureNumber);
		printf("\nModel name: %s", tmp->model);
		printf("\nPrice: %d", tmp->price);
		printf("\nManufacturing year: %d", tmp->manufactureYear);
		tmp = tmp->next;
		flag = 1;

		printf("\n");
		printf("\n");
	}
	if (flag == -1) {
		printf("\nNo information in the list, try option 4.\n\n");
	}

	system("pause");
}
















