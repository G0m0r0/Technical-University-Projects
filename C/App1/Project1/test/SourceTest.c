#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <cstdio>

typedef struct
{
    char name[30];
    int nmbr;
    int group;
    float mark;
} student;

student in(void)
{
    student a;
    printf("\nName: ");
    fflush(stdin);
    gets(a.name);
    printf("Number: ");
    scanf("%d", &a.nmbr);
    printf("Group: ");
    scanf("%d", &a.group);
    do
    {
        printf("Mark: ");
        scanf("%f", &a.mark);
    } while (a.mark < 2 || a.mark > 6);
    fflush(stdin);
    return (a);
}
void out(student st)
{
    printf("\nName:    %s\n", st.name);
    printf("Number:  %d\n", st.nmbr);
    printf("Group:   %d\n", st.group);
    printf("Mark:    %.2f\n", st.mark);
}

FILE * writeFile(char* filename)
{
    FILE* fp;
    student s;
    if ((fp = fopen(filename, "ab")) == NULL)   /* Отваряне на двоичен файл за добавяне в края на файла*/
    {
        printf("Cannot open file %s.\n ", filename);
        exit(1);
    }
    do
    {
        s = in();
        fwrite(&s, sizeof(s), 1, fp);/*Запис на една структура-студент във файла*/
        printf("Next student? Y/N: ");
    } while (toupper(getch()) == 'Y');
    fclose(fp);
    printf("\nFile was created! \n");
    return(fp);
}

void readFile(FILE* fp, char* filename)
{
    student s;
    int flag = 0;
    if ((fp = fopen(filename, "rb")) == NULL)   /* Отваряне на двоичен файл за четене*/
    {
        printf("\nCannot open file!\n");
        exit(1);
    }
    while (fread(&s, sizeof(s), 1, fp) == 1) /*Четене на една структура от файла*/
        out(s);
    fclose(fp);
}

void maxMark(FILE* fp, char* filename)
{
    student s;
    int flag = 0;
    float max_mark;
    if ((fp = fopen(filename, "rb")) == NULL)   /* Отваряне на двоичен файл за четене*/
    {
        printf("\nCannot open file!\n");
        exit(1);
    }
    while (fread(&s, sizeof(s), 1, fp) == 1) /*Четене на една структура от файла*/
    {
        if (!flag)
        {
            max_mark = s.mark;
            flag = 1;
        }
        else if (s.mark > max_mark)
            max_mark = s.mark;
    }
    fseek(fp, 0L, SEEK_SET);/*Позициониране в началото на файла*/
    while (fread(&s, sizeof(s), 1, fp) == 1) /*Четене на една структура от файла*/
        if (s.mark == max_mark)
            out(s);
    fclose(fp);
}

float avMark(FILE* fp, char* filename, int searchGroup)
{
    student s;
    float avr = 0.0;
    int count = 0;
    if ((fp = fopen(filename, "rb")) == NULL)   /*Отваряне на двоичен файл за четене*/
    {
        printf("\nCannot open file!\n");
        exit(1);
    }
    while (fread(&s, sizeof(student), 1, fp) == 1)
        if (s.group == searchGroup)
        {
            count++;
            avr += s.mark;
        }
    fclose(fp);
    if (count == 0)
        return 0.0;
    else
        return (avr / count);
}

short updateMark(FILE* fp, char* filename, int searchNmbr, float newMark)
{
    student s;
    if ((fp = fopen(filename, "r+b")) == NULL)   /*Отваряне на двоичен файл за четене и актуализация*/
    {
        printf("\nCannot open file!\n");
        exit(1);
    }
    while (fread(&s, sizeof(student), 1, fp) == 1)
        if (s.nmbr == searchNmbr)
        {
            fseek(fp, ftell(fp) - sizeof(student), SEEK_SET);//Позициониране на указателя с един запис нагоре
            s.mark = newMark;
            fwrite(&s, sizeof(student), 1, fp);
            fclose(fp);
            return 1;
        }
    fclose(fp);
    return 0;
}

short deleteStudent(FILE* fp, char* filename, int searchNmbr)
{
    student s;
    FILE* fp1;
    short flag = 0;
    if ((fp = fopen(filename, "rb")) == NULL)   /*Отваряне на двоичен файл за четене*/
    {
        printf("\nCannot open file!\n");
        exit(1);
    }
    if ((fp1 = fopen("temp", "wb")) == NULL)   /*Отваряне на временен двоичен файл за запис*/
    {
        printf("\nCannot create temp file!\n");
        exit(1);
    }
    while (fread(&s, sizeof(student), 1, fp) == 1)
        if (s.nmbr == searchNmbr)
            flag = 1;
        else
            fwrite(&s, sizeof(student), 1, fp1);
    fclose(fp);
    fclose(fp1);
    if ((fp = fopen(filename, "wb")) == NULL)   /*Отваряне на двоичен файл за запис */
    {
        printf("\nCannot open file!\n");
        exit(1);
    }
    if ((fp1 = fopen("temp", "rb")) == NULL)   /*Отваряне на временен двоичен файл за четене*/
    {
        printf("\nCannot create temp file!\n");
        exit(1);
    }
    while (fread(&s, sizeof(student), 1, fp1) == 1)
        fwrite(&s, sizeof(student), 1, fp);
    fclose(fp);
    fclose(fp1);
    return flag;
}

int main()
{
    FILE* fp;
    char filename[30];
    int searchGroup, searchNmbr, choice;
    float newMark;
    printf("Input filename : ");
    gets(filename);
    do
    {
        printf("\n1. Input info for students.\n");
        printf("2. Print students.\n");
        printf("3. Student with the highest mark.\n");
        printf("4. Average mark for selected group.\n");
        printf("5. Update mark.\n");
        printf("6. Delete student.\n");
        printf("7. End.\n");
        scanf("%d", &choice);
        switch (choice)
        {
        case 1:
            fp = writeFile(filename);
            break;
        case 2:
            printf("\nStudents:\n");
            readFile(fp, filename);
            break;
        case 3:
            printf("\nStudent with the highest mark:\n");
            maxMark(fp, filename);
            break;
        case 4:
            printf("\nInput group: ");
            scanf("%d", &searchGroup);
            if (avMark(fp, filename, searchGroup) == 0)
                printf("\nNo student in group %d!", searchGroup);
            else
                printf("Group %d has average mark: %f\n", searchGroup, avMark(fp, filename, searchGroup));
            break;
        case 5:
            printf("\nInput Number: ");
            scanf("%d", &searchNmbr);
            printf("\nInput new mark: ");
            scanf("%f", &newMark);
            if (updateMark(fp, filename, searchNmbr, newMark) == 0)
                printf("\nNo student with number %d!", searchNmbr);
            else
                printf("\nMark of student %d has been updated!", searchNmbr);
            readFile(fp, filename);
            break;
        case 6:
            printf("\nInput Number: ");
            scanf("%d", &searchNmbr);
            if (deleteStudent(fp, filename, searchNmbr) == 0)
                printf("\nNo student with number %d!", searchNmbr);
            else
                printf("\nThe student %d has been deleted!", searchNmbr);
            readFile(fp, filename);
            break;
        case 7:
            break;
        default:
            printf("Incorrect choice!");
        }
    } while (choice != 7);
    return 0;
}
