#include <ctype.h>
#include <string.h>
#include <stdio.h> 
#include <stdlib.h>
#include <malloc.h>

#define NAME 50
#define MOD 3

struct u4ili6te
{
	long nomer;
	char ime[NAME + 1];
	float plo6t;
	long broj;
	char direktor[NAME + 1];

};
typedef struct u4ili6te BODY;
struct List
{

	BODY body;
	struct List* pNext;
};
typedef struct List LIST;


int proverka();
int getName(char* s);
void getMode(char* mode);
int izvajdannidirektor(LIST* pFirst);
int izvajdanniplosht(LIST* pFirst);
int delbody(LIST** pFirst1, LIST* p);
int delALL(LIST** pFirst1);
int promqna(LIST** pFirst);
int vuvejdane(LIST** pFirst);
int otpe4atvane(LIST* pFirst);
int insertBegin(LIST** pN, BODY newBody);
int save(LIST* pFirst, char* s, int a);
int readf(LIST** pFirst, char* s, int a);




int main() {
	char mode[MOD] = "1";
	char mode1[MOD];
	char fnameS[55] = "\0";
	char fnameR[55] = "\0";
	int b;

	LIST* pFirst = NULL;
	LIST* p = NULL;
	LIST* p1 = NULL;
	system("chcp 1251");
	system("cls");



	do {
		printf("\n\t1-Enter new data for schools\n\t2-Change date for schools\n\t3-output data for schools by director\n\t4-output data of schools with area larger than that\n\t5-read from file\n\t6-Exit");
		printf("\nChoose between [1-6]: ");
		do {
			if (!(0 == strcmp(mode, "1") || 0 == strcmp(mode, "2") || 0 == strcmp(mode, "3") || 0 == strcmp(mode, "4") || 0 == strcmp(mode, "5") || 0 == strcmp(mode, "6")))
				printf("\nWrong input information[1-5]: ");
			getMode(mode);
		} while (!(0 == strcmp(mode, "1") || 0 == strcmp(mode, "2") || 0 == strcmp(mode, "3") || 0 == strcmp(mode, "4") || 0 == strcmp(mode, "5") || 0 == strcmp(mode, "6")));


		if (0 == strcmp(mode, "1"))
		{
			system("cls");
			if (pFirst != NULL)
				delALL(&pFirst);
			for (;;)
			{
				system("cls");
				b = vuvejdane(&pFirst);
				if (b == 0)
				{
					if (pFirst != NULL)
						delALL(&pFirst);
					printf("\nNo data intered\n");

				}
				printf("\nEnter 1 to exit the program-> ");
				//gets(mode1);
				getMode(mode1);
				if (0 == strcmp(mode1, "1"))
					break;
			}


			do {
				if (0 != strcmp(fnameR, "\0") && 0 != strcmp(fnameS, "\0"))
				{
					printf("\nEnter\n 1 for last saved file\n 2 to save in last file\n or to save in another file\nEnter-->");
					getMode(mode1);
					if (0 == strcmp(mode1, "1"))
						b = save(pFirst, fnameR, 1);
					else if (0 == strcmp(mode1, "2"))
						b = save(pFirst, fnameS, 1);
					else
						b = save(pFirst, fnameS, 0);
				}
				else if (0 != strcmp(fnameR, "\0"))
				{
					printf("\nEnter\n 1 to save in last read file\n or to save in another file\nEnter-->");
					getMode(mode1);
					if (0 == strcmp(mode1, "1"))
						b = save(pFirst, fnameR, 1);
					else
						b = save(pFirst, fnameS, 0);
				}
				else if (0 != strcmp(fnameS, "\0"))
				{
					printf("\nEnter\n 1 to save in the last file\n or to read from another file\nEnter-->");

					getMode(mode1);
					if (0 == strcmp(mode1, "1"))
						b = save(pFirst, fnameS, 1);
					else
						b = save(pFirst, fnameS, 0);
				}
				else
					b = save(pFirst, fnameS, 0);
				if (b == 0)
					printf("\nError");
				else
					printf("\nFile is saved successfuly!\n");
			} while (b == 0);

			system("pause");
			system("cls");
		}

		else if (0 == strcmp(mode, "2"))
		{
			if (pFirst != NULL)
			{

				if (promqna(&pFirst))
					if (pFirst != NULL)
						do {
							if (0 != strcmp(fnameR, "\0") && 0 != strcmp(fnameS, "\0"))
							{
								printf("\nEnter\n 1 to save in last read file\n 2 to save in the last file\n or to save in another file\nEnter-->");
								getMode(mode1);
								if (0 == strcmp(mode1, "1"))
									b = save(pFirst, fnameR, 1);
								else if (0 == strcmp(mode1, "2"))
									b = save(pFirst, fnameS, 1);
								else
									b = save(pFirst, fnameS, 0);
							}
							else if (0 != strcmp(fnameR, "\0"))
							{
								printf("\nEnter\n 1 зto save in last read file\n or to save in another file\nEnter-->");
								getMode(mode1);
								if (0 == strcmp(mode1, "1"))
									b = save(pFirst, fnameR, 1);
								else
									b = save(pFirst, fnameS, 0);
							}
							else if (0 != strcmp(fnameS, "\0"))
							{
								printf("\nEnter\n 1 to save in last file\n or to another readл\nEnter-->");

								getMode(mode1);
								if (0 == strcmp(mode1, "1"))
									b = save(pFirst, fnameS, 1);
								else
									b = save(pFirst, fnameS, 0);
							}
							else
								b = save(pFirst, fnameS, 0);
							if (b == 0)
								printf("\nError");
							else
								printf("\nFile is saved successfuly\n");
						} while (b == 0);
					else
						printf("\nError in the change of data\n");
			}
			else
				printf("\nPlease first read the file\n");
			system("pause");
			system("cls");
		}

		else if (0 == strcmp(mode, "3"))
		{
			system("cls");
			if (pFirst != NULL)
				izvajdannidirektor(pFirst);
			else
				printf("\nPlease first read the file or enter new list");
			printf("\n");
			system("pause");
			system("cls");
		}
		else if (0 == strcmp(mode, "4"))
		{
			system("cls");
			if (pFirst != NULL)
				izvajdanniplosht(pFirst);
			else
				printf("\nPlease first read the file or enter new list");
			printf("\n");
			system("pause");
			system("cls");
		}
		else if (0 == strcmp(mode, "5"))
		{
			system("cls");
			if (pFirst != NULL)
				delALL(&pFirst);

			do {
				if (0 != strcmp(fnameR, "\0") && 0 != strcmp(fnameS, "\0"))
				{
					printf("\nEnter\n 1 to read from the last read file\n 2 to read from the saved file\n or for another reading\nEnter-->");
					getMode(mode1);
					if (0 == strcmp(mode1, "1"))
						b = readf(&pFirst, fnameR, 1);
					else if (0 == strcmp(mode1, "2"))
						b = readf(&pFirst, fnameS, 1);
					else
						b = readf(&pFirst, fnameR, 0);
				}
				else if (0 != strcmp(fnameR, "\0"))
				{
					printf("\nEnter\n 1 to read from last read file\n иor for another reading\nEnter-->");
					getMode(mode1);
					if (0 == strcmp(mode1, "1"))
						b = readf(&pFirst, fnameR, 1);
					else
						b = readf(&pFirst, fnameR, 0);
				}
				else if (0 != strcmp(fnameS, "\0"))
				{
					printf("\nEnter\n 1 to read from last saved file\n иor for another reading from file\nEnter-->");

					getMode(mode1);
					if (0 == strcmp(mode1, "1"))
						b = readf(&pFirst, fnameS, 1);
					else
						b = readf(&pFirst, fnameR, 0);
				}
				else
					b = readf(&pFirst, fnameR, 0);
				if (b == 0)
					printf("\nError");
				else if (b == -1)
					printf("\nFile is not for this program\n");
				else
					printf("\nFile is read successfuly\n");
			} while (b == 0 || b == -1);

			system("pause");
			system("cls");
		}
	} while (0 != strcmp(mode, "6"));
	return 0;
}

int proverka() {
	char ch;
	for (;;)
	{
		ch = getchar();
		if (!isspace(ch))
		{
			//*b = 0;
			fflush(stdin);
			return 0;
			//break;
		}
		else if (ch == '\n')
			break;
	}
	fflush(stdin);
	//*b = 1;
	return 1;
}

int getName(char* s) {
	char ch;
	int j = 0, b = 0;

	for (;;)
	{
		ch = getchar();
		//printf("\nisalpha %d\t\tisspace %d", isalpha(ch), isspace(ch));

		if (ch == '\n')
		{
			s[j] = '\0';
			break;
		}
		else if (b == 0 && 8 == isspace(ch))
			continue;
		else if (2/*1*/ == isalpha(ch) || 1/*1*/ == isalpha(ch) || ch == '.' || ch == '-' || ch == '"' || 8/*1*/ == isspace(ch))
		{
			b = 1;
			j++;
			if (j == (NAME + 1))
			{
				fflush(stdin);
				return 0;
			}
			s[j - 1] = ch;
		}
		else {
			fflush(stdin);
			return -1;
		}
	}

	return 1;
}

void getMode(char* mode) {
	char ch;
	int i;

	for (i = 0;;)
	{
		ch = getchar();
		if (ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9' || ch == 'y' || ch == 'n' || ch == 'Y' || ch == 'N')
		{
			mode[i] = ch;
			i++;
			if (i == (MOD - 1))
			{
				mode[i] = '\0';
				break;
			}
		}
		else if (!isspace(ch))
		{

			mode[0] = 'g';
			mode[1] = '\0';
			break;
		}
		else if (ch == '\n')
		{
			mode[i] = '\0';
			break;
		}
	}
	fflush(stdin);
}

int izvajdannidirektor(LIST* pFirst)
{
	int a = 0, b1;
	char* direktor[NAME + 1];

	LIST* p = NULL;
	LIST* pFirst1 = NULL, * p1 = NULL, * p2 = NULL;


	if (pFirst == NULL)
		return 0;

	do {
		printf("\n\tName of director: ");
		b1 = getName(direktor);
		if (b1 == 0)
			printf("\n\t\tMax allowed symbols 50!");
		else if (b1 == -1)
			printf("\n\t\t\tWrong symbols!");
		else if (0 == strcmp(direktor, "\0"))
			printf("\n\t\t\tNo name entered!");
	} while (0 == strcmp(direktor, "\0") || b1 != 1);


	p = pFirst;
	system("cls");
	printf("\nFound %d schools with director: %s\n\n", a, direktor);
	while (p != NULL)
	{
		if (0 == strcmp(direktor, p->body.direktor))
		{
			a++;
			if (pFirst1 != NULL)
			{
				for (p2 = pFirst1; (p2->pNext) != NULL; p2 = p2->pNext)
				{
				}
			}
			if (insertBegin(&p1, p->body) == 0)
				return 0;
			if (pFirst1 == NULL)
				pFirst1 = p1;
			else
				p2->pNext = p1;
		}
		p = p->pNext;
		system("cls");
		printf("\nFound %d schools with name of director : %s\n\n", a, direktor);

	}

	otpe4atvane(pFirst1);
	if (!delALL(&pFirst1))
		return 0;
	return 1;
}

int izvajdanniplosht(LIST* pFirst)
{
	int a = 0, b, b1;
	float plo6t;
	char ch;
	LIST* p = NULL;
	LIST* pFirst1 = NULL, * p1 = NULL, * p2 = NULL;


	if (pFirst == NULL)
		return 0;

	do {
		b1 = 1;
		printf("\n\tEnter area(кв.м.): ");
		b = scanf("%f", &plo6t);
		if (b != EOF)
			for (;;)
			{
				ch = getchar();

				if (!isspace(ch))
				{
					b1 = 0;
					break;
				}
				else if (ch == '\n')
					break;
			}
		fflush(stdin);
		if (plo6t <= 0.0 && b1 == 1 && !(b == 0 || b == EOF))
			printf("\n\t\tArea should be possitive number!");
		else if (b1 == 0 || b == 0 || b == EOF)
			printf("\n\t\t\tError!");
	} while (b == 0 || plo6t <= 0.0 || b1 == 0 || b == EOF);



	p = pFirst;

	system("cls");
	printf("\nFound %d schools with area larger than %.2f\n\n", a, plo6t);
	while (p != NULL)
	{

		if ((p->body.plo6t) > plo6t)
		{
			a++;
			if (pFirst1 != NULL)
			{
				for (p2 = pFirst1; (p2->pNext) != NULL; p2 = p2->pNext)
				{
				}
			}
			if (insertBegin(&p1, p->body) == 0)
				return 0;
			if (pFirst1 == NULL)
				pFirst1 = p1;
			else
				p2->pNext = p1;
		}
		p = p->pNext;
		system("cls");
		printf("\nFound %d schools with area larger than %.2f\n\n", a, plo6t);

	}

	otpe4atvane(pFirst1);
	if (!delALL(&pFirst1))
		return 0;
	return 1;
}

int delbody(LIST** pFirst1, LIST* p) {
	LIST* p1;
	if (*pFirst1 == NULL)
		return -1;
	if (p != *pFirst1)
	{
		for (p1 = *pFirst1; p1->pNext != p; p1 = p1->pNext) {}
		p1->pNext = p1->pNext->pNext;
		//if(p1->pNext==NULL)
		if (p)
			free(p);
		else
			return 0;
	}
	else
	{
		*pFirst1 = p->pNext;
		if (p)
			free(p);
		else
			return 0;
	}
	return 1;
}

int delALL(LIST** pFirst1)
{
	LIST* p1 = NULL;
	LIST* p2 = NULL;
	if (*pFirst1 == NULL)
		return -1;

	for (p2 = *pFirst1; p2 != NULL;)
	{
		p1 = p2->pNext;

		if (p2)
			free(p2);

		else
			return 0;
		p2 = p1;
	}
	*pFirst1 = NULL;
	return 1;
}

int promqna(LIST** pFirst)
{
	char mode[MOD] = "1";
	char mode1[MOD] = "1";
	int element, b, b1, b2, elementi = 1, i;
	int a = 1, a1 = 0;
	long nomer;
	LIST* p=NULL, * p1;
	BODY u4il;


	if (*pFirst == NULL)
		return 0;



	do {
		system("cls");
		otpe4atvane(*pFirst);

		printf("\nEnter\n 1 to change elements\n 2 to add new school\n 3 to exit\n Enter-->");


		getMode(mode1);
		if (0 == strcmp(mode1, "2"))
		{
			if (!vuvejdane(pFirst))
				return 0;

		}
		else if (0 == strcmp(mode1, "1"))
		{
			//////////////////////////////////////////////////////////////////////////////////
			b = 0;

			do {

				if (b != 1) {
					printf("\nFind element by number");
					printf("\nEnter -1- for consecutive -2- for unique---> ");//////////////////////
				}
				getMode(mode);
				b = 1;
				if (0 == strcmp(mode, "1"))
				{
					system("cls");
					do {
						for (p = *pFirst; (p->pNext) != NULL; p = p->pNext)
							elementi++;
						//	b1 = 1;			
						printf("\nEnter consecutive number: ");
						b2 = scanf("%d", &element);
						if (b2 != EOF)
							b1 = proverka(&b1);
						if (b2 != 1 || b1 != 1)
							printf("\tError!");
						else if (element > elementi)
							printf("\tThere is not enter so much scools!");
						else if (element < 1)
							printf("\tNumber of elements is possitive number");

					} while (b2 != 1 || b1 != 1 || element > elementi || element < 1);
					for (p = *pFirst, i = 1; i < element; i++)
						p = p->pNext;

				}
				else if (0 == strcmp(mode, "2"))
				{
					system("cls");
					do {
						b2 = 0;

						printf("\n\tEnter number: ");
						b = scanf("%ld", &nomer);
						if (b != EOF)
							/*b1 = */b1 = proverka();
						if (nomer <= 0L && b1 == 1 && !(b == 0 || b == EOF))
							printf("\t\tNumber can not be lower than 1 !");
						else if (b1 == 0 || b == 0 || b == EOF)
							printf("\t\t\tError!");
						else
						{
							for (p = *pFirst; p != NULL; p = p->pNext)
								if (p->body.nomer == nomer)
								{
									b2 = 1;
									break;
								}
							if (!b2)
								printf("\tNumber is not found: %ld", nomer);
						}
					} while (b == 0 || nomer <= 0L || b1 == 0 || b == EOF || b2 != 1);
				}
				else
				{
					printf("Error! ОTry again-->");
					//system("pause");
				}
			} while (!(0 == strcmp(mode, "1") || 0 == strcmp(mode, "2")));


			////////////////////////////////////////////////////////////////////////////////////////////////////////


			do {
				system("cls");
				for (p1 = *pFirst; p1 != p; p1 = p1->pNext)
					a++;
				printf("\n   ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
				printf("\n|||--------------------------------------------------------------------------");
				printf("\n|||\tNumber(in row): %d            Name: %s", a, p->body.ime);
				printf("\n|||__________________________________________________________________________");
				printf("\n|||Number(unique): %ld\tName of director: %s", p->body.nomer, p->body.direktor);
				printf("\n|||Number of students :  %ld\t  area(кв.м.): %.2f", p->body.broj, p->body.plo6t);
				printf("\n|||--------------------------------------------------------------------------");
				printf("\n   ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
				printf("\n\t\t1 - change name of school");
				printf("\n\t\t2 - change number");
				printf("\n\t\t3 - change area");
				printf("\n\t\t4 - number of students( 0 school is deleted)");
				printf("\n\t\t5 - name of director");
				printf("\n\t\t6 - exit");
				printf("\n\tEnter choice[1-6]-->");


				do {
					if (!(0 == strcmp(mode, "1") || 0 == strcmp(mode, "2") || 0 == strcmp(mode, "3") || 0 == strcmp(mode, "4") || 0 == strcmp(mode, "5") || 0 == strcmp(mode, "6")))
						printf("\nIncorect entered choice[1-6]--> ");
					getMode(mode);
				} while (!(0 == strcmp(mode, "1") || 0 == strcmp(mode, "2") || 0 == strcmp(mode, "3") || 0 == strcmp(mode, "4") || 0 == strcmp(mode, "5") || 0 == strcmp(mode, "6")));


				if (0 == strcmp(mode, "1"))
				{

					do {
						printf("\n\tEnter name of school : ");
						//	gets(u4il.ime);
						b1 = getName(u4il.ime);
						if (b1 == 0)
							printf("\t\tMaximum number of elements is 50!");
						else if (b1 == -1)
							printf("\t\t\tEntered incoret symbols!");
						else if (0 == strcmp(u4il.ime, "\0"))
							printf("\t\t\tNo name entered!");
					} while (0 == strcmp(u4il.ime, "\0") || b1 != 1);
					strcpy(p->body.ime, u4il.ime);

				}
				else if (0 == strcmp(mode, "2")) {
					do {
						a1 = 0;
						//b1 = 1;
						printf("\n\tEnter number: ");
						b = scanf("%ld", &u4il.nomer);
						if (b != EOF)
							b1 = proverka();

						if (u4il.nomer <= 0L && b1 == 1 && !(b == 0 || b == EOF))
							printf("\t\tNumber can not be less than 1 !");
						else if (b1 == 0 || b == 0 || b == EOF)
							printf("\t\t\tError!");
						else if (*pFirst != NULL)
						{
							for (p1 = *pFirst; p1 != NULL; p1 = p1->pNext)
								if (p1->body.nomer == u4il.nomer)
								{
									a1 = 1;
									printf("\t\tSchool with this number exist!");
									break;
								}
						}
					} while (b == 0 || u4il.nomer <= 0L || b1 == 0 || b == EOF || a1 == 1);
					p->body.nomer = u4il.nomer;
				}
				else if (0 == strcmp(mode, "3")) {
					do {
						//b1 = 1;
						printf("\n\tEnter area(кв.м.): ");
						b = scanf("%f", &u4il.plo6t);
						if (b != EOF)
							b1 = proverka();
						if (u4il.plo6t <= 0.0 && b1 == 1 && !(b == 0 || b == EOF))
							printf("\t\tArea is postive number!");
						else if (b1 == 0 || b == 0 || b == EOF)
							printf("\t\t\tError!");
					} while (b == 0 || u4il.plo6t <= 0.0 || b1 == 0 || b == EOF);
					p->body.plo6t = u4il.plo6t;
				}

				else if (0 == strcmp(mode, "4")) {
					do {
						//b1 = 1;
						printf("\n\tEnter number of schools: ");
						b = scanf("%ld", &u4il.broj);
						if (b != EOF)
							b1 = proverka();
						if (u4il.broj < 0L && b1 == 1 && !(b == 0 || b == EOF))
							printf("\t\tNumber can not be less than 0!");
						else if (b1 == 0 || b == 0 || b == EOF)
							printf("\t\t\tError!");
						else if (u4il.broj == 0L)
						{
							printf("\nDelete school\n");
							delbody(pFirst, p);
							break;
						}
					} while (b == 0 || b1 == 0 || b == EOF || u4il.broj < 0L);
					if (u4il.broj)
						p->body.broj = u4il.broj;
					else
						break;
				}


				else if (0 == strcmp(mode, "5")) {
					do {
						printf("\n\tEnter name of director: ");
						//gets(u4il.direktor);
						b1 = getName(u4il.direktor);
						if (b1 == 0)
							printf("\t\tMaxmum number of symbols 50!");
						else if (b1 == -1)
							printf("\t\t\tWrong symbols entered!");
						else if (0 == strcmp(u4il.direktor, "\0"))
							printf("\t\t\tNo numbers intered!");
					} while (0 == strcmp(u4il.direktor, "\0") || b1 != 1);
					strcpy(p->body.direktor, u4il.direktor);
				}

			} while (0 != strcmp(mode, "6"));
			b = 0;
			//////////////////////////////////////////////////////////////////////////////////////////////////////////
		}

		else if (0 == strcmp(mode1, "3"))
			return 1;
		else
		{
			printf("\nError!! \n");
			system("pause");
		}
	} while (/*!(0 == strcmp(mode1, "1") || 0 == strcmp(mode1, "2"))*/1);






	return 1;
}

int vuvejdane(LIST** pFirst)
{
	int b = 0, b1 = 1, a = 0, a1 = 0;
	char ch = '\n';
	LIST* p = NULL, * p1 = NULL, * p2 = NULL;
	BODY u4il;



	if (*pFirst != NULL)
	{
		a++;
		for (p = *pFirst; (p->pNext) != NULL; p = p->pNext)
			a++;
	}


	printf("\n\n-----------------------------------------------------------------------------");
	printf("\n-----------------------------------------------------------------------------");
	printf("\nEnter data %d school", a + 1);
	printf("\n-----------------------------------------------------------------------------");

	do {
		printf("\n\tEnter name of school : ");
		//	gets(u4il.ime);
		b1 = getName(u4il.ime);
		if (b1 == 0)
			printf("\t\tMaximum allowed symbols 50!");
		else if (b1 == -1)
			printf("\t\t\tIncorect symbols entered!");
		else if (0 == strcmp(u4il.ime, "\0"))
			printf("\t\t\tNo name entered!");
	} while (0 == strcmp(u4il.ime, "\0") || b1 != 1);

	printf("\n\n");
	do {
		a1 = 0;
		//b1 = 1;
		printf("\n\tEnter number: ");
		b = scanf("%ld", &u4il.nomer);
		if (b != EOF)
			b1 = proverka();

		if (u4il.nomer <= 0L && b1 == 1 && !(b == 0 || b == EOF))
			printf("\t\tNumber can not be less than 1 !");
		else if (b1 == 0 || b == 0 || b == EOF)
			printf("\t\t\tError!");
		else if (*pFirst != NULL)
		{
			for (p2 = *pFirst; p2 != NULL; p2 = p2->pNext)
				if (p2->body.nomer == u4il.nomer)
				{
					a1 = 1;
					printf("\t\tSchool with this name already exists!");
					break;
				}
		}
	} while (b == 0 || u4il.nomer <= 0L || b1 == 0 || b == EOF || a1 == 1);
	printf("\n\n");

	do {
		//b1 = 1;
		printf("\n\tEnter area(кв.м.): ");
		b = scanf("%f", &u4il.plo6t);
		if (b != EOF)
			b1 = proverka();
		if (u4il.plo6t <= 0.0 && b1 == 1 && !(b == 0 || b == EOF))
			printf("\t\tArea should be positive number!");
		else if (b1 == 0 || b == 0 || b == EOF)
			printf("\t\t\tError!");
	} while (b == 0 || u4il.plo6t <= 0.0 || b1 == 0 || b == EOF);

	printf("\n\n");

	do {
		//b1 = 1;
		printf("\n\tEnter number of schools: ");
		b = scanf("%ld", &u4il.broj);
		if (b != EOF)
			b1 = proverka();
		if (u4il.broj < 0L && b1 == 1 && !(b == 0 || b == EOF))
			printf("\t\tNumber can not be less than 0!");
		else if (b1 == 0 || b == 0 || b == EOF)
			printf("\t\t\tError!");
	} while (b == 0 || b1 == 0 || b == EOF || u4il.broj < 0L);

	printf("\n\n");


	do {
		printf("\n\tEnter name of director: ");
		//gets(u4il.direktor);
		b1 = getName(u4il.direktor);
		if (b1 == 0)
			printf("\t\tMaximum numbers allowed 50!");
		else if (b1 == -1)
			printf("\t\t\tSymbols are incorect!");
		else if (0 == strcmp(u4il.direktor, "\0"))
			printf("\t\t\tNo name enetered!");
	} while (0 == strcmp(u4il.direktor, "\0") || b1 != 1);


	printf("\n\n-----------------------------------------------------------------------------");
	b = insertBegin(&p1, u4il);
	if (b == 0)
		return 0;
	if (*pFirst == NULL)
		*pFirst = p1;
	else
		p->pNext = p1;
	return 1;
}

int otpe4atvane(LIST* pFirst)
{
	LIST* p;
	int a = 0;
	if (pFirst == NULL)
		return 0;
	for (p = pFirst; p != NULL; p = p->pNext)
	{
		a++;
		printf("\n   ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
		printf("\n|||--------------------------------------------------------------------------");
		printf("\n|||\tNumber(in row): %d            Name: %s", a, p->body.ime);
		printf("\n|||__________________________________________________________________________");
		printf("\n|||Number(unique): %ld\tName of director: %s", p->body.nomer, p->body.direktor);
		printf("\n|||Number of students :  %ld\t  area(kv.m.): %.2f", p->body.broj, p->body.plo6t);
		printf("\n|||--------------------------------------------------------------------------");
	}
	printf("\n   ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
	return 1;
}

int insertBegin(LIST** pN, BODY newBody)
{
	LIST* p;
	p = (LIST*)calloc(1, sizeof(LIST));   // отделя памет
	if (p == NULL)
	{
		printf("\nNo enough memory!\n");
		return 0;
	}
	else
	{
		p->body = newBody;   // запазва данните
		*pN = p;
		p->pNext = NULL;
		return 1;
	}
}

int save(LIST* pFirst, char* s, int a) {
	LIST* p = NULL;
	FILE* fp = NULL;
	int b, b1, i;


	if (pFirst == NULL)
		return 0;

	if (a == 0)
		do {
			printf("\nEnter name of file to save\n(max 50 symbols without extention)| ");
			b = scanf("%50s", s);
			if (b != EOF)
				b1 = proverka();
			if (b1 == 1 && b == 1)
			{
				strcat(s, ".dat");
				fp = fopen(s, "wb");
			}
			if (b != 1 || b != 1 || fp == NULL)
				printf("Error");
		} while (b != 1 || b != 1 || fp == NULL);
	else if (a == 1)
	{
		fp = fopen(s, "wb");
		if (fp == NULL) {
			printf("\nError");
			return 0;
		}
	}
	else
		return 0;



	for (p = pFirst, i = 0; p != NULL; p = p->pNext, i++)
	{
		if (!fwrite(&i, sizeof(int), 1, fp))
		{
			printf("\nNot enough space\n");
			return 0;
		}
		if (!fwrite(&(p->body), sizeof(BODY), 1, fp))
		{
			printf("\nNot enough memory\n");
			return 0;
		}

	}
	fclose(fp);
	return 1;
}


int readf(LIST** pFirst, char* s, int a)
{
	LIST* p = NULL, * p1 = NULL;
	FILE* fp = NULL;
	BODY u4il;
	int b, b1, i, ii = -1;

	if (a == 0)
		do {
			printf("\nEnter name of file to read\n(max 50 symbols without extention)| ");
			b = scanf("%50s", s);
			if (b != EOF)
				b1 = proverka();
			if (b1 == 1 && b == 1)
			{
				strcat(s, ".dat");
				fp = fopen(s, "rb");
				if (fp == NULL)
					printf("Error when open file ");
			}
			else
				printf("error");
		} while (b != 1 || b != 1 || fp == NULL);
	else if (a == 1)
	{
		fp = fopen(s, "rb");
		if (fp == NULL) {
			printf("\nError when open file\n");
			return 0;
		}
	}
	else
		return 0;

	/*for (p = *pFirst; (p->pNext) != NULL; p = p->pNext)*/
	for (i = 0, ii = 0;; i++)
	{
		if (*pFirst != NULL)
			for (p = *pFirst; (p->pNext) != NULL; p = p->pNext) {}

		if (0 == fread(&ii, sizeof(int), 1, fp))
		{
			//printf("\n%d\n", ii);
			if (*pFirst != NULL)
				break;
			else if (ii == 0) { fclose(fp); printf("\nФайла е празен\n"); return 1; }
			else {
				fclose(fp);
				return -1;
			}
		}
		if (ii != i)
		{
			fclose(fp);
			return-1;
		}
		b1 = fread(&u4il, sizeof(BODY), 1, fp);
		if (b1 == 0)
			break;
		b = insertBegin(&p1, u4il);
		if (b == 0) {
			fclose(fp);
			return 0;
		}
		if (*pFirst == NULL)
			*pFirst = p1;
		else
			p->pNext = p1;

	}
	fclose(fp);
	return 1;
}
