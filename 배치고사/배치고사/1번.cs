using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 배치고사
{
    internal class _1번
    {
        class Program
        {
            static int Sum(int[] arr)
            {
                int answer = 0;

                foreach (int i in arr)
                {
                    answer += i;
                }

                return answer;
            }

            static void Main(string[] args)
            {
                int[] ints = { 3, 6, 7, 9 };
                Console.WriteLine(Sum(ints));
            }
        }
    }
}
