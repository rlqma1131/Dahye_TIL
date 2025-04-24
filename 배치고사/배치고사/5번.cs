using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 배치고사
{
    internal class _5번
    {
        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("숫자를 입력하세요.");
                    string answer = Console.ReadLine();

                    bool isSuccess = int.TryParse(answer, out int result);

                    // TODO : 입력받은 정수가 홀수인지 짝수인지 구분하는 코드 작성하기
                    if (isSuccess)
                    {
                        int number = int.Parse(answer);
                        if (number % 2 == 0)
                        {
                            Console.WriteLine("짝수입니다.");
                        }
                        else
                        {
                            Console.WriteLine("홀수입니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("프로그램이 종료합니다.");
                        break;
                    }
                }
            }
        }
    }
}
