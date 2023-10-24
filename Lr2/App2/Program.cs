
using System.IO.MemoryMappedFiles;

class TestClass
{
    static void Main(string[] args)
    {

        if (args.Length < 1)
        {
            //Массив для сообщения из общей памяти
            int[] message;
            //Размер введенного сообщения
            int size;

            //Получение существующего участка разделяемой памяти
            //Параметр - название участка
            MemoryMappedFile sharedMemory = MemoryMappedFile.OpenExisting("MemoryFile");
            //Сначала считываем размер сообщения, чтобы создать массив данного размера
            //Integer занимает 4 байта, начинается с первого байта, поэтому передаем цифры 0 и 4
            using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(0, 4, MemoryMappedFileAccess.Read))
            {
                size = reader.ReadInt32(0);
            }
            //Считываем сообщение, используя полученный выше размер
            //Сообщение - это строка или массив объектов char, каждый из которых занимает два байта
            //Поэтому вторым параметром передаем число символов умножив на из размер в байтах плюс
            //А первый параметр - смещение - 4 байта, которое занимает размер сообщения
            using (MemoryMappedViewAccessor reader = sharedMemory.CreateViewAccessor(4, size * 4, MemoryMappedFileAccess.Read))
            {
                //Массив символов сообщения
                message = new int[size];
                reader.ReadArray<int>(0, message, 0, size);
            }
            Console.WriteLine($"Аргумент1 : {message[0]}\nАргумент 2: {message[1]}\n" +
                $"Сумма:{message[0] + message[1]}");
        }
        else
        {
            Console.WriteLine($"Аргумент 1\n{args[0][0]}\nАргумент 2\n{args[0][1]}" +
            $"\nРезультат:" +
            $"\n{(Convert.ToInt32(args[0][0]) + Convert.ToInt32(args[0][1]) - 96).ToString()}");
        }

        Thread.Sleep(1000);
        Console.ReadLine();
    }
}
