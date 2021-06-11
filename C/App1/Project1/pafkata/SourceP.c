#include <stdio.h>
#include <string.h>
#include <stdlib.h>

typedef enum { false, true } bool;
typedef struct { char filePath[100]; } char100;

struct Reader {
	char readersNumber[8];
	char name[80];
	char address[80];
	char EGN[10];
	int  takenBooks;
	struct Reader* next;
};

struct Reader* enroll_reader(char* readersNumber, char* name, char* address, char* EGN, int* takenBooks) {
	struct Reader* enroll = NULL;
	/*allocate memory*/
	enroll = malloc(sizeof * enroll);

	if (enroll != NULL) {
		/*INITIALIZE*/
		strncpy(enroll->readersNumber, readersNumber, 8);
		strncpy(enroll->name, name, 80);
		strncpy(enroll->address, address, 80);
		strncpy(enroll->EGN, EGN, 10);
		enroll->takenBooks = takenBooks;
	}
	return enroll;
}

void Menu(char* path);

char100* FilePath(char100* path);

void Add(char* path);
void FileRead(char* path);
void ClearFile(char* path);
void GetReaderWithMostBooks();
void FindByName(char* readersName);

static struct Reader* head = NULL;
struct Reader* st;

int main()
{
	bool exit = false;
	char input[10];
	char filePath[100];

	strcpy(filePath, "D:\\text.bin");

	char100* path = malloc(sizeof(char100));

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

			// Print all readers in the list
			struct Reader* tmp = head;
			while (tmp)
			{
				printf("\n\nReaders number: %s", tmp->readersNumber);
				printf("\nname: %s", tmp->name);
				printf("\naddress: %s", tmp->address);
				printf("\nEGN number: %s", tmp->EGN);
				printf("\ntaken books: %d\n", tmp->takenBooks);
				tmp = tmp->next;
			}
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
			GetReaderWithMostBooks();
			break;
		}
		case 6:
		{
			char readersName[80];
			printf("\nEnter name to find? ");
			scanf("%s", &readersName);

			FindByName(readersName);
			break;
		}
		case 7:
		{

			break;
		}
		case 8:
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

void Menu(char* path)
{
	char path_view[30];
	strcpy(path_view, " - ");
	strcat(path_view, path);

	printf("#################################\n\n");
	printf("1. Choose file(database) %s\n", path);
	printf("2. Register reader\n");
	printf("3. Show all  info\n");
	printf("4. Clear File\n");
	printf("5. Reader with most taken books\n");
	printf("6. Find reader by name\n");
	printf("7. \n");
	printf("8. Exit\n\n");
}

char100* FilePath(char100* path)
{
	printf("\nInput path: ");
	scanf("%s", &path->filePath);

	return path;
}

void Add(char* path)
{
	char readersNumber[8];
	char name[80];
	char address[80];
	char EGN[10];
	int  takenBooks;
	FILE* file;


	printf("\nReaders number: ");
	scanf("%s", &readersNumber);

	printf("\nname: ");
	scanf("%s", &name);

	printf("\naddress:  ");
	scanf("%s", &address);

	printf("\nEGN number: ");
	scanf("%s", &EGN);

	printf("\nNumber of taken books: ");
	scanf("%d", &takenBooks);

	st = enroll_reader(readersNumber, name, address, EGN, takenBooks);
	st->next = head;
	head = st;

	system("pause");

	file = fopen(path, "ab");

	if (file == NULL)
	{
		perror("Error opening the file!");
	}
	else
	{
		fprintf(file,"\n\nReaders number: %s", &readersNumber);
		fprintf(file,"\nname: %s", &name);
		fprintf(file,"\naddress: %s", &address);
		fprintf(file,"\nEGN number: %s", &EGN);
		fprintf(file,"\ntaken books: %d\n", takenBooks);
	}

	fclose(file);
}

void ClearFile(char* path)
{
	struct Reader* head = malloc(sizeof(struct Reader));
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
			printf("%s\n", buffer);
		}
		printf("\n");
	}
	system("pause");

	fclose(file);
}

void GetReaderWithMostBooks() {
	int max = -1;
	char readersNum[8];
	char readersName[80];	

	struct Reader* tmp = head;
	while (tmp)
	{
		if (tmp->takenBooks > max) {
			max = tmp->takenBooks;

			strcpy(&readersNum, tmp->readersNumber);
			strcpy(&readersName, tmp->name);
		}
		tmp = tmp->next;
	}

	printf("\n\nReader with most taken books is: ");
	printf("\nReaders number: %s", &readersNum);
	printf("\nname: %s", &readersName);
	printf("\ntaken books: %d\n", max);

	system("pause");
}

void FindByName(char* readersName) {
	struct Reader* tmp = head;
	while (tmp)
	{
		//int tmp2 = strcmp(readersName, tmp->name);
		if (strcmp(readersName, tmp->name) ==0) {

			printf("\n\nFound reader with name %s: ", tmp->name);
			printf("\n\nReaders number: %s", tmp->readersNumber);
			printf("\naddress: %s", tmp->address);
			printf("\nEGN number: %s", tmp->EGN);
			printf("\ntaken books: %d\n", tmp->takenBooks);
		}
		tmp = tmp->next;
	}

	system("pause");
}
















