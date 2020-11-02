using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _61._1
{
    class Program
    {

        static void Main(string[] args)
        {
            //pharentases problem page 61 exercise 1
            string text = Console.ReadLine();
            RemoveTetxt(ref text);

            List<char> openParentheses = new List<char>();

            bool balancedOrNot = true;

            if (text[0] == ')')
            {
                balancedOrNot = false;
            }
            else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '(')
                        openParentheses.Add('(');
                    if (text[i] == ')')
                    {
                        if (openParentheses.Count > 0)
                            openParentheses.Remove('(');
                        else
                            balancedOrNot = false;
                    }
                }
            }
            Console.WriteLine(balancedOrNot == true && openParentheses.Count == 0 ? "Balanced" : "Not balanced");
        }

        private static void RemoveTetxt(ref string text)
        {
            StringBuilder filteredText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ')' || text[i] == '(')
                    filteredText.Append(text[i]);
            }
            text = filteredText.ToString();
        }
    }
}
