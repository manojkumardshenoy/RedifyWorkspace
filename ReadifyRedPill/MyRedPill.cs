using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using knockknock.readify.net;

namespace ReadifyRedPill
{
    public class MyRedPill : IRedPill
    {
        public Guid WhatIsYourToken()
        {
            return new Guid("bb287917-4243-44aa-a787-2427a901abfa");
        }

        public long FibonacciNumber(long n)
        {
            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {

            if (a <= 0)
                return TriangleType.Error;
            if (b <= 0)
                return TriangleType.Error;
            if (c <= 0)
                return TriangleType.Error;

            if (a == int.MaxValue && b == int.MaxValue && c == int.MaxValue)
                return TriangleType.Equilateral;

            if (a >= int.MaxValue)
                return TriangleType.Error;
            if (b >= int.MaxValue)
                return TriangleType.Error;
            if (c >= int.MaxValue)
                return TriangleType.Error;

            if (a >= b + c || a <= Math.Abs(b - c))
                return TriangleType.Error;

            if (b >= a + c || b <= Math.Abs(a - c))
                return TriangleType.Error;

            if (c >= b + a || c <= Math.Abs(b - a))
                return TriangleType.Error;


            if (a == b && b == c)//All three equal
                return TriangleType.Equilateral;

            if (a == b || a == c || b == c)//if any two equal
                return TriangleType.Isosceles;

            return TriangleType.Scalene;
        }

        public string ReverseWords(string s)
        {
            if (s == null)
                throw new ArgumentNullException();

            int idx = 0;
            List<char> chars = new List<char>();
            foreach (char ch in s)
            {
                if (ch != ' ')
                    chars.Insert(idx, ch);
                else
                {
                    chars.Add(ch);
                    idx = chars.Count;
                }
            }
            return new string(chars.ToArray());
        }
    }
}
