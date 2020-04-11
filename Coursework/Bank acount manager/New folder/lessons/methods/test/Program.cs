using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace test
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var customer = new Customer(1,"john");
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);           
        }
    }
}
