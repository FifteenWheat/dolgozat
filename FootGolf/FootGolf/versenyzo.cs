using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace footgolf
{
    class versenyzo
    {
        public string nev{ get; set; }
        public string kategoria { get; set; }
        public string egyesulet{ get; set; }
        public int[]pontok { get; set; }
        public versenyzo(string s)
        {
            var t = s.Split(';');
            this.nev = t[0];
            this.kategoria = t[1];
            this.egyesulet = t[2];
            this.pontok = new int[8];
            for (int i = 0; i < 8; i++)
            {
                this.pontok[i] = int.Parse(t[i+3]);
            }
        }
        public int oszpontszam()
        {
            int ossz = 0;
            Array.Sort(pontok);
            if (pontok[0] != 0) ossz += 10;
            if (pontok[1] != 0) ossz += 10;
            for (int i = 2; i < pontok.Length; i++) ossz += pontok[i];
            return ossz;
        }
    }
}
