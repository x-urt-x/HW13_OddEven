namespace HW13_OddEven
{
    internal class Program
    {
        static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
            var taskOdd = new Task(() =>
        {
            for (int i = 1; i <= 99; i += 2)
            {
                Print(i);
            }
        });
            var taskEven = new Task(() =>
            {
                for (int i = 2; i <= 100; i += 2)
                {
                    Print(i);
                }
            });
            taskOdd.Start();
            taskEven.Start();
            Console.ReadLine();
        }
        static void Print(int i)
        {
            mutex.WaitOne();
            Console.WriteLine(i);
            mutex.ReleaseMutex();
        }
    }
}
