using System;
namespace Zero_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number - 1 : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number - 2 : ");
            int b = Convert.ToInt32(Console.ReadLine());
            try
            {
                double ans = a / b;
                Console.WriteLine(ans);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
