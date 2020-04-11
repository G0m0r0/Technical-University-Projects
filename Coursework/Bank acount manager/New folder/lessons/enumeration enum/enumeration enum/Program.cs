using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enumeration_enum
{
    class Program
    {
        enum DaysOfWeek
        {
            Monday=100, // int = 100,	Tuesday, // = 1,	
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        static void Main(string[] args)
        {
            DaysOfWeek lectureDay; //declaration of variable
            lectureDay = DaysOfWeek.Monday; //variable take value
            Console.WriteLine(lectureDay);
            int enumVal = (int)lectureDay; //parse to int 
            Console.WriteLine(enumVal); //output 100
            lectureDay = (DaysOfWeek)0; // = DaysOfWeek.Monday
            Console.WriteLine(DaysOfWeek.IsDefined(typeof(DaysOfWeek), 54)); // false, 100 is Monday its not 54
        }
    }
}
