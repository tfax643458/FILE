

//このプログラムはファイルを読み込み、配列に入れ、それを別のファイルに書き込む物です。
//ファイルを指定すれば使えるので実行してみてください。

//補足　"y/any"==yesの時はy,noのときは他のキー

using System;
using System.IO;

namespace createfile
{
    class Program
    {
        static void Main()
        {
            int i, i2;
            int counter = 0;
            int cs = 0;
            var SEL="";
            string line;
            string[] date = new string[500];

            string LoadFilePath = default;
            string WriteFilePath = default;
                                  //↑あらかじめファイルを指定する場合変更してください
                                  //その場合は以降のファイルパス指定用の文も消してください

            for (i2 = 0; i2 < 1;)
            {
                Console.Write("読み込むファイルのパスを指定してください。\n>>");
                LoadFilePath = Console.ReadLine();

                StreamReader file = new StreamReader(@LoadFilePath);
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    date[counter] = line;
                    counter++;
                }
                file.Close();

                Console.Write("\n>>There were {0} lines.\n>>このデータを書き込みますか?(y/any)\n>>", counter);

                SEL = Console.ReadLine();

                if (SEL == "y")
                {
                    Console.Write("書き込むファイルのパスを指定してください。\n>>");
                    WriteFilePath = Console.ReadLine();

                    Console.WriteLine(">>start\n");
                    using (var fileStream = new FileStream(@WriteFilePath, FileMode.Open))
                    {
                        fileStream.SetLength(0);
                    }
                    //↑書き込むファイルのサイズを0にしてデータを消去

                    for (i = 0; i < 1;)
                    {
                        File.AppendAllText(@WriteFilePath, date[cs] + Environment.NewLine);
                        cs++;
                        if (counter == cs)
                        {
                            i = 2;
                        }
                    }
                    //↑lineC配列に入っているデータを一行ずつ書き込み

                    Console.WriteLine(">>Complete\n");
                }
                else
                {
                    Console.WriteLine("書き込みをキャンセルしました。\n");
                }

                Console.Write(">>continue?(y/any)\n>>");
                SEL = Console.ReadLine();
                if (SEL != "y")
                {
                    i2 = 2;
                }
            }
        }
    }
}
     



