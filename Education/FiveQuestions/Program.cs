using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirstQuestion();
            //SecondQuestion();
            ThirdQuestion();
            Console.ReadLine();
        }

        private static void ThirdQuestion()
        {
            var magicValue = new MagicValue(1, 2);
            MagicValue.ApplyRef(ref magicValue);
            MagicValue.Apply(magicValue);

            Console.WriteLine(magicValue.Left * magicValue.Right);
        }

        class MagicValue
        {
            public int Left { get; set; }
            public int Right { get; set; }

            public MagicValue(int left, int right)
            {
                Left = left;
                Right = right;
            }

            public static void Apply(MagicValue magicValue)
            {
                magicValue.Left += 3;
                magicValue.Right += 4;
                magicValue = new MagicValue(5, 6);
            }

            public static void ApplyRef(ref MagicValue magicValue)
            {
                magicValue.Left += 7;
                magicValue.Right += 8;
                magicValue = new MagicValue(9, 10);
            }
        }



        private static void FirstQuestion()
        {
            var numbers = new int[] { 7, 2, 5, 5, 7, 6, 7 };
            var result = numbers.Sum() + numbers.Skip(2).Take(3).Sum();
            var y = numbers.GroupBy(x => x).Select(x =>
            {
                result += x.Key;
                return x.Key;
            });

            Console.WriteLine(result);
        }

        private static void SecondQuestion()
        {
            int result;
            try
            {
                result = GetNumber(1);
            }
            catch (FileNotFoundException e)
            {
                result = int.Parse(e.Message) + 1;
            }
            catch (ArgumentException e)
            {
                result = int.Parse(e.Message) + 2;
            }
            catch (NullReferenceException e)
            {
                result = int.Parse(e.Message) + 3;
            }

            Console.WriteLine(result * 100);
        }

        private static int GetNumber(int input)
        {
            try
            {
                throw new FileNotFoundException(input.ToString());
            }
            catch (Exception e)
            {
                throw new ArgumentException((++input).ToString());
            }
            finally
            {
                throw new NullReferenceException((++input).ToString());
            }

            return (input += 4);
        }
    }
}
