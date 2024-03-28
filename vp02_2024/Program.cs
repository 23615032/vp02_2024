using System.Diagnostics.CodeAnalysis;

namespace vp02_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1에서 100까지의 합
            int sum = 0;
            for (int i = 1; i<=100; i++)
            {
                sum += i;
            }
            Console.WriteLine("1에서 100까지의 합 = " + sum);

            // (43장) 홀수의 합
            int oddsum = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 1)
                    oddsum += i;
            }
            Console.WriteLine("1에서 100까지의 홀수의 합 = " + sum);

            // (43장) 역수의 합
            double recisum = 0;
            for (int i = 1; i <= 100; i++)
            {
                recisum += 1.0/i;
            }
            Console.WriteLine("1에서 100까지의 역수의 합 = " + sum);

            // X에서 Y까지의 합
            int sumxy = 0;
            Console.Write("x : ");
            int x = int.Parse(Console.ReadLine()); // Console.ReadLine 한 것을 정수로 번역
            Console.Write("y : ");
            int y = int.Parse(Console.ReadLine()); ; 
            
            for (int i = x; i <= y; i++)
            {
                sumxy += i;
            }
            Console.WriteLine("{0}~{1}까지의 합 = {2} ", x, y, sumxy);

            // (45장) 구구단

            for (int yy = 1; yy <= 9; yy++)
            {
                for (int xx = 2; xx <= 9; xx++)
                {
                    Console.Write("{0} X {1} = {2}\t", xx, yy, xx * yy);
                }
                Console.WriteLine(); //line change
            }
            // (47장) a의 b승 = a를 b번 곱한다
            int pow = 1;
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            
            for (int i = 0; i <= b; i++)
            {
                pow *= a;
            }
            Console.WriteLine("{0} 의 {1}승 = {2}", a, b, pow);

            // (53장) 팩토리얼 

            int fact = 1;

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            Console.WriteLine("{0}! = {1}", n, fact);

          

        }
    }
}