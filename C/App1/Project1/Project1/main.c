#include <stdio.h>

int main()
{
    /*
Names are case-sensitive and may begin with:
     letters, _
After, may include
     letters, numbers, _
Convention says
     Start with a lowercase word, then additional words are capitalized
     ex. myFirstVariable
*/
    char testGrade = 'A';    // single 8-bit character.
    char name[] = "Mike";    // array of characters (string)

    // you can make them unsigned by adding "unsigned" prefix
    short age0 = 10;         // atleast 16-bits signed integer
    int age1 = 20;           // atleast 16-bits signed integer (not smaller than short)
    long age2 = 30;          // atleast 32-bits signed integer
    long long age3 = 40;     // atleast 64-bits signed integer

    float gpa0 = 2.5;       // single percision floating point
    double gpa1 = 3.5;       // double-precision floating point
    long double gpa2 = 3.5;  // extended-precision floating point

    int isTall;             // 0 if false, non-zero if true
    isTall = 1;

    testGrade = 'F';

    printf("%s, your grade is %c \n", name, testGrade);
    printf("%d \n", (int)gpa0);
    printf("%f \n", (float)3/2);
    /*
    %c	character
    %d	integer number (base 10)
    %e	exponential floating-point number
    %f	floating-point number
    %i	integer (base 10)
    %o	octal number (base 8)
    %s	a string of characters
    %u	unsigned decimal (integer) number
    %x	number in hexadecimal (base 16)
    %%	print a percent sign
    \%	print a percent sign
    */


    //pointers
    int num = 10;
    printf("%p \n", &num); //print memory addres of the variable

    int *pNum = &num; //save the memory addres in variable   
    printf("%p \n", pNum); //memory address
    printf("%d \n", *pNum); //value reference

    //user input 
    char name1[10];
    printf("Enter your name: ");
    fgets(name1, 10, stdin);
    printf("Hello %s! \n", name1);
    printf("Enter your age: ");
    int age5;
    scanf_s("%d", &age5);
    printf("You are %d \n", age5);

    //int luckyNumber[6]; //empty array of integers with 6 slots
    int twoDarray[2][3] = { {1,2,3},{3,4,5} };
}