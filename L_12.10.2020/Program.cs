

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//для скачяивания файлов

//Задание 1.
//Создать класс/классы с методами для записи/считывания текста в файл/из файла. 
//    Предусмотреть возможность освобождения ресурсов (отключения от потока) с использованием интерфейса IDisposable

public class Read : IDisposable
{
    string buf;

    public Read()
    {
        buf = string.Empty;
    }


    public void Dispose()
    {
        GC.SuppressFinalize(this);//отключаем финализатор(деструктор в с++)
        Console.WriteLine("Dispose");
    }

    public string LoadFromFile()
    {
        FileStream fileStream;
        using (fileStream = new FileStream("text1.txt", FileMode.Open, FileAccess.Read))
        {
            using (StreamReader reader = new StreamReader(fileStream,Encoding.Default))
            {
                buf = reader.ReadToEnd();
            }
        }

        Console.WriteLine("Debug info");
        Console.WriteLine(buf);

        this.Dispose();//отключаем поток

        return buf;
    }

    public void SaveToFile(string str)
    {
        FileStream fileStream;
       
        using (fileStream = new FileStream("text2.txt", FileMode.Open, FileAccess.Write))
        {
            using (StreamWriter write = new StreamWriter(fileStream, Encoding.Default))
            {
                write.WriteLine(str);
            }
        }
        this.Dispose();//отключаем поток
    }
    ~Read()
    {
        Console.WriteLine();
        Console.WriteLine("Finalizator");
        Console.WriteLine();
    }
}

//Задание 1:

//Создать класс содержащий методы для записи/считывания текста в файл/из файла. 
//    Предусмотреть возможность освобождения ресурсов (отключения от потока) при различных ситуациях.

namespace L_12._10._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Read read = new Read();
           
          
                read.LoadFromFile();
            string str = "Any text\nHello world\nhome task";
            read.SaveToFile(str);


         

        }
    }
}
