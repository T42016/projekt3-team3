using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLogic
{
    public interface ISB
    {
        void WriteLine(string s);
        void Write(string s);
        string ReadLine();
        void Clear();
        int Next(int max);
    }

    public class SB : ISB
    {
        Random r = new Random();

        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public void Write(string s)
        {
            Console.Write(s);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public int Next(int max)
        {
            return r.Next(0,max);
        }
    }
}
