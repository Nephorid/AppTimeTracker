using System;

namespace Test
{
    public class Oyun
    {
        public string Ad { get; set; }
        public string ExecutablePath { get; set; }
        public TimeSpan OynamaSuresi { get; set; }

        public Oyun(string ad, string executablePath)
        {
            Ad = ad;
            ExecutablePath = executablePath;
        }

        public override string ToString()
        {
            return Ad;
        }
    }

}
