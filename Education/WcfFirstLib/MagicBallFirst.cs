using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfFirstLib
{
    public class MagicBallFirst : IEightBall
    {
        public MagicBallFirst()
        {
            Console.WriteLine("MagicBallFirst is ready");
        }

        public string GetAnswer(string question)
        {
            return "nonono";
        }
    }
}
