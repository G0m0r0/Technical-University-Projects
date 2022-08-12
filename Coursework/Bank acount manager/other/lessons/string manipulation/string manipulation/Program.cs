using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string sampleString1 = "someString";
            string sampleString2 = "someOtherString";
            string trimString = sampleString1.Trim();
            Console.WriteLine(sampleString1.Replace("some", "apple")); 
            if(sampleString1==sampleString2) //key sensitive
            {

            }
            if(sampleString1.Equals(sampleString2, StringComparison.CurrentCultureIgnoreCase))
            {
                //compare two sting with capital and small letters
            }
            if(sampleString1.Length>10)
            {

            }
            Console.WriteLine(sampleString1[4]);
            string sybstringOfsample1 = sampleString1.Substring(1, 4);
            if(string.IsNullOrEmpty(sampleString1))
            {

            }
            //SPLIT string and put it into array
            string newSampleString = "I,typed,something,here,and,it,has,to,become,array";
            string[] words = newSampleString.Split(',');
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
            string joinOldString = string.Join(",",words);

       
        }
    }
}
