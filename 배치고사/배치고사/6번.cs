using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 배치고사
{
    internal class _6번
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] intArr = { 4, 7, 2, 5, 6, 8, 3 };

                // '옆에 인수와 크기 비교하여 왼쪽으로 이동시켜주는 연산구현 어떻게하더라'하니까 자동완성 시켜줬어요ㅜ
                for (int i = 0; i < intArr.Length; i++)
                {
                    for (int j = i + 1; j < intArr.Length; j++)
                    {
                        if (intArr[i] > intArr[j])
                        {
                            int temp = intArr[i];
                            intArr[i] = intArr[j];
                            intArr[j] = temp;
                        }
                    }
                }

                foreach (int i in intArr)
                    Console.Write(i + " ");
            }
        }
    }
}
