namespace ExploringCSharp13
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            PrintNumbers(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            PrintWords(new List<string> { "one", "two", "three", "four", "five" });

            PrintNumbersOld(1, 2, 3);    // Could only use arrays directly. Before c#13

            #region Escape 
            Console.WriteLine("\e[0mThis is bold text\e[0m");

            Console.WriteLine("\x1b[0mThis is bold text Before c#13\x1b[0m"); //Before c#13
            #endregion

            ImplicitIndexAccess();
            ImplicitIndexAccessOld();

            await ProcessDataAsync();
            await ProcessDataAsyncOld();
        }

        #region params 
        public static void PrintNumbers(params List<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        public static void PrintWords(params List<string> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        public static void PrintNumbersOld(params int[] numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        #endregion

        #region lock

        public static void lockMethod()
        {
            Lock myLock = new Lock();
            using (myLock.EnterScope())
            {
                // Critical section
                Console.WriteLine("Thread-safe code here.");
            }
        }
        private static readonly object _lock = new object();

        //Before c#13
        public static void ThreadSafeMethod()
        {
            lock (_lock)
            {
                // Critical section
                Console.WriteLine("Thread-safe code here.");
            }
        }
        #endregion

        #region ImplicitIndexAccess
        public static void ImplicitIndexAccess()
        {
            var numbers = new int[5] { 1, 2, 3, 4, 5 };
            numbers[^1] = 32; // Sets the last element to 32
            Console.WriteLine(numbers[^1]);
        }
        public static void ImplicitIndexAccessOld()
        {
            var numbers = new int[5] { 1, 2, 3, 4, 5 };
            var initializer = new List<int> { 1, 2, 3, 4, 5 };
            initializer[initializer.Count - 1] = 32; // Manually set the last element.
            Console.WriteLine(initializer[4]);
        }
        #endregion

        #region Async Ref
        public static async Task ProcessDataAsync()
        {
            Span<byte> buffer = stackalloc byte[1024]; // Unsafe context
            await Task.Delay(1000);
        }
        static void ProcessData()
        {
            Span<byte> buffer = stackalloc byte[1024]; // Unsafe context
        }

        // Asynchronous wrapper
        public static async Task ProcessDataAsyncOld()
        {
            await Task.Run(() => ProcessData());
        }
        #endregion
    }
}
