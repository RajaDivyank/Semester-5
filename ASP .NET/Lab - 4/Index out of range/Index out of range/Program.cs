using System;
namespace Index_out_of_bound
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter element : {0}",i+1);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter the index = ");
            int a = Convert.ToInt32(Console.ReadLine());
            try
            {
                Console.WriteLine("Value = {0}", arr[a]);
            }catch (Exception e)
            {
                Console.WriteLine (e.Message);
            }
        }
    }
}
