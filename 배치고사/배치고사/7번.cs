using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 배치고사
{
    internal class _7번
    {
        class Program
        {
            public class Unit
            {
                public virtual void Move() // 버추얼
                {
                    Console.WriteLine("두발로 걷기");
                }

                public void Attack()
                {
                    Console.WriteLine("Unit 공격");
                }
            }

            public class Marine : Unit
            {

            }

            public class Zergling // 유닛에게 종속
            {
                public void Move() // 오버라이드
                {
                    Console.WriteLine("네발로 걷기");
                }
            }

            static void Main(string[] args)
            {
                Zergling zerg = new Zergling();
                zerg.Move(); // "네발로 걷기" 출력
            }
        }
    }
}
