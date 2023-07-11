using System;
namespace Throw_Exception
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Enter the Number : ");
            int n = Convert.ToInt32(Console.ReadLine());
            try
            {
                if(n%2 != 0)
                {
                    throw new Exception("number is not even");
                }
                else
                {
                    Console.WriteLine("{0} is even",n);
                }
            }catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}