using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flag_operation_with_enum
{
    class Program
    {
        enum DayOfWeekFlags
        {
            Monday = 1,
            Tuesday = 1 << 1, // 2
            Wednesday 	= 1 << 2, // 4	
            Thursday 	= 1 << 3, // 8	
            Friday 		= 1 << 4, // 16	
            Saturday 	= 1 << 5, // 32	
            Sunday 	= 1 << 6, // 64	
            Workdays	= Monday | Tuesday | Wednesday | Thursday | Friday,
            Weekend	= Saturday | Sunday,
        }

        static void Main(string[] args)
        {
            DayOfWeekFlags lectureDay = DayOfWeekFlags.Monday; //create variable and initializat it
            var exerciseDay = DayOfWeekFlags.Monday | DayOfWeekFlags.Thursday; 
            var informaticsDays = lectureDay | exerciseDay; //combine flag
            bool hasInfOnThursday = (informaticsDays & DayOfWeekFlags.Thursday) == DayOfWeekFlags.Thursday; // true
            bool hasInfOnWeekends = (informaticsDays & DayOfWeekFlags.Weekend) == DayOfWeekFlags.Weekend; // false

        }
    }
}
