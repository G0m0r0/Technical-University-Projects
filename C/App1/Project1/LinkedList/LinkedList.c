#include <stdio.h>
#include <stdlib.h>
#include <string.h>

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

int main(void) {
	static struct Reader* head = NULL;
	struct Reader* st;
	char readersNumber[8];
	char name[80];
	char address[80];
	char EGN[10];
	int  takenBooks;

	for (size_t i = 0; i < 3; i++)
	{
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
	}


	// Make a new student
	//st = enroll_reader("sdg4t", "Ivan petrov", "my address","98763225", 10);

	// Insert in front of list
	//st->next = head;
	//head = st;

	// Make a new student
	//st = enroll_reader("aj4n5jw", "Kalina Mihova", "her address","35325235", 2);

	// Insert in front of list
	//st->next = head;
	//head = st;

	// Print all students in the list
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

	// Free allocated memory
	while (head)
	{
		tmp = head;
		head = head->next;
		free(tmp);
	}

	return 0;
}