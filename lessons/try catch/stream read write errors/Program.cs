using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace stream_read_write_errors
{
    //not finished
    class Program
    {
        static void Main(string[] args)
        {
           
            string[] lines = { "This is line 1", "This is line 2", "This is line 3" };
            //using (StreamWriter writer = new StreamWriter("storage.txt")) 
            //{
            //    foreach(var line in lines)
            //        Console.WriteLine(line);
            //}
            StreamWriter writer = null;
            try
            {
                writer= new StreamWriter(@"D:\C#\University\lessons\try catch\stream read write errors\bin\Debug\storage.txt");
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(writer!=null)
                {
                    writer.Dispose();
                }
            }
        }
    }
}
