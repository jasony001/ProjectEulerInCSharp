using ProjectEulerDataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerLib
{
    public class Problem2Solver : ProblemSolver
    {

        /*
        1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144
        f3 = f2 + f1
        f4 = f3 + f2 = 2f2 + f1
        f5 = f4 + f3 = 2f2 + f1 + f2 + f1 = 3f2 + 2f1
        f6 = f5 + f4 = 3f2 + 2f1 + 2f2 + f1 = 5f2 + 3f1

        */

        public Problem2Solver() : base()
        {
            Problem.UpperBound = 4000000;
            Problem.IsClosedOnRight = true;
            Problem.Id = 2;
            Problem.Title = "Even Fibonacci numbers";
            Problem.Description =
                "Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:\n"
                    + "\n"
                    + "1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...\n"
                    + "\n"
                    + "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.";


            Problem.Solutions.Add(new Solution
            {
                ProblemId = 2,
                Description = "Brutal Force",
                Version = 1,
            });
            Problem.Solutions.Add(new Solution
            {
                ProblemId = 2,
                Description = "fib(n) = (Math.Pow(phi, n) - (Math.Pow(-1,n) / Math.Pow(phi, n))) / Math.Sqrt(5), sum of (fib(3x))",
                Version = 2,
            });
        }


        public override string solution1()
        {
            int f0 = 1;
            int f1 = 2;
            int f = f0 + f1;
            int sum = 2;
            while (f <= Problem.CalculatedIncludedUpperBound)
            {
                if (f % 2 == 0)
                {
                    sum += f;
                }

                f0 = f1;
                f1 = f;
                f += f0;
            }

            return sum.ToString();
        }

        override public string solution2()
        {
            int n = 3;
            int f = fib(n);
            int sum = 0;
            while (f <= Problem.CalculatedIncludedUpperBound)
            {
                sum += f;
                n += 3;
                f = fib(n);
            }

            return sum.ToString();
        }

        public int fib(int n)
        {
            double phi = (1 + Math.Sqrt(5)) / 2;
            return (int)(Math.Round((Math.Pow(phi, n) - (Math.Pow(-1, n) / Math.Pow(phi, n))) / Math.Sqrt(5)));
        }
    }
}