using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 배치고사
{
    internal class _9번
    {

        class Program
        {
            static void Main(string[] args)
            {
                Stack<int> stack = new Stack<int>();

                stack.Push(1);
                stack.Push(2);
                stack.Push(3);
                stack.Pop();
                Console.WriteLine(stack.Pop());
                stack.Push(4);
                stack.Push(5);

                while (stack.Count > 0)
                    Console.WriteLine(stack.Pop());

                // 35421 Pop으로 나중에 들어간 값부터 출력되는데 3을 먼저 Pop하고 쌓인 데이터가 0이 될때까지 나머지 데이터 Pop이 계속되므로
            }
        }
    }
}
