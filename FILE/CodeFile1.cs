

//このプログラムはテキストファイルを読み込み、配列に入れ、それを別のファイルに書き込む物です。
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
                Console.Write("読み込むテキストファイルのパスを指定してください。\n>>");
                LoadFilePath = Console.ReadLine();

                StreamReader file = new StreamReader(@LoadFilePath);    //"file"に指定したファイルを読み込ませる
                while ((line = file.ReadLine()) != null)                //ReadLineメソッドを使用し一行ずつ、データが無くなるまで実行
                {
                    Console.WriteLine(line);　//読み込んだデータを表示
                    date[counter] = line;　　 //一行ごと配列に入れる
                    counter++;　　　　　　　　//何行読み込んだかをカウント
                }
                file.Close();  //ファイルを閉じる

                Console.Write("\n>>There were {0} lines.\n>>このデータを書き込みますか?(y/any)\n>>", counter);

                SEL = Console.ReadLine();

                if (SEL == "y")
                {
                    Console.Write("書き込むファイルのパスを指定してください。\n>>");
                    WriteFilePath = Console.ReadLine();

                    Console.WriteLine(">>start\n");
                    using (var fileStream = new FileStream(@WriteFilePath, FileMode.Open))  //FileStreamクラスを利用し書き込むファイルを開く
                    {
                        fileStream.SetLength(0);     //書き込むファイルのサイズを0にしてデータを消去
                    }

                    for (i = 0; i < 1;)
                    {
                        if (counter > cs)
                        { 
                            File.AppendAllText(@WriteFilePath, date[cs]);　//date配列に入っている値を書き込む
                            cs++;
                            if (counter > cs)
                            {
                                File.AppendAllText(WriteFilePath, Environment.NewLine); //+Environmentで改行
                            }
                        }
                        else
                        {
                            i = 2;
                        }
                    }
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
     



