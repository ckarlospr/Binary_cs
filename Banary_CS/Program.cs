using System;
using System.Security;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void SaveCurrentTime()
        {
            FileStream fs = new FileStream("time.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(DateTime.Now.Hour);
            bw.Write(DateTime.Now.Minute);
            bw.Write(1.2);
            bw.Write("C");

            bw.Close();
            fs.Close(); 
        }

        static void SavePreviousTime()
        {
            FileStream fs = new FileStream("time.bin", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            string previousTime = br.ReadInt32() + ":" +br.ReadInt32();
            string previousTime2 = br.ReadDouble().ToString();
            string previousTime3 = br.ReadString();
            Console.WriteLine(previousTime+"-"+previousTime2+"-"+previousTime3);
        }

        static void Main(string[] args)
        {
            SaveCurrentTime();
            SavePreviousTime();
            Console.ReadKey();
        }
    }
}