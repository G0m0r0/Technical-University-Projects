using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("C:\\programs\\file.txt"))
        {
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                Console.WriteLine(line); // Use line.
            }
        }
    }
}
