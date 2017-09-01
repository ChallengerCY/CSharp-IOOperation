using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpIOOperation
{
    class Program
    {
        private const string File_Name = "Text.txt";
        static void Main(string[] args)
        {
            // IOOperationBase(args);

            // WriteInNewFile();

            // using可以很好的利用系统资源
            // using (StreamWriter w = File.AppendText("Text.txt"))
            // {
            //    log("Challener", w);
            //   log("CY", w);

            // w.Close();
            // }

            //    readFile();
            UseUsingReadFile();
        }

        //c#读取文件详情
        public static void IOOperationBase(string[] args)
        {
            //C#中的IO事件
            //File.Exists判断该文件是否存在
            // Console.WriteLine(File.Exists(@"C:\Hello\IO.txt"));
            //Directory.Exists判断一个文件夹是否存在
            //Console.WriteLine(Directory.Exists(@"C:\"));

            //当前路径可以用.来表示
            string path = ".";
            if (args.Length > 0)
            {
                if (Directory.Exists(args[0]))
                {
                    path = args[0];
                }
                else
                {
                    Console.WriteLine(args[0]);
                }
            }

            //DirectoryInfo可以实例化，针对具体的文件夹
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo fil in dir.GetFiles("*.exe"))
            {
                string name = fil.Name;
                long size = fil.Length;
                DateTime filDataTime = fil.CreationTime;
                Console.WriteLine("{0},{1},{2}", name, size, filDataTime);
            }

            Console.ReadLine();
        }

        //c#写入文件操作
        //example:当一个文件不存在时创建并进行写入操作，当文件存在时返回文件存在
        public static void WriteInNewFile()
        {
            if (File.Exists(File_Name))
            {
                Console.Write("该文件存在");
                Console.ReadLine();
                return;
            }


            FileStream fs = new FileStream(File_Name, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < 11; i++)
            {
                bw.Write("a");
            }
            bw.Close();
            fs.Close();
        }


        //当文件存在的时候，进行写入操作
        public static void log(string logMessage, TextWriter w)
        {
            w.Write("\r\nlog Entry: ");
            w.WriteLine(":{0}", logMessage);
            w.Flush();
        }

        //C#读取文件
        public static void readFile()
        {
            if (!File.Exists(File_Name))
            {
                Console.Write("没有该文件");
                Console.ReadLine();
                return;
            }
            FileStream fs = new FileStream(File_Name, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < 5; i++)
            {
                Console.Write(br.ReadString());
            }
            fs.Close();
            br.Close();
            Console.ReadLine();
        }

        //使用using来读取文件
        public static void UseUsingReadFile()
        {
            if (!File.Exists(File_Name))
            {
                Console.WriteLine("找不到文件");
                Console.ReadLine();
                return;
            }

            using (StreamReader sr = File.OpenText(File_Name))
            {
                string input;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
                sr.Close();
            }
            Console.ReadLine();
        }
    }
}
