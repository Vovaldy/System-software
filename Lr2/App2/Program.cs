
class TestClass
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Аргумент 1\n{args[0][0]}\nАргумент 2\n{args[0][1]}" +
            $"\nРезультат:" +
            $"\n{(Convert.ToInt32(args[0][0]) + Convert.ToInt32(args[0][1]) - 96).ToString()}");
        
        Thread.Sleep(1000);
        Console.ReadLine();
    }
}
