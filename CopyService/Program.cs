using System;
using System.Threading.Tasks;

namespace CopyService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var printerChain = new BWPrinter();
            printerChain.SetNext(new ColorPrinter());

            for (int i = 0; i < 10; i++)
            {
                var request = GenerateRandomPrintRequest();
                await printerChain.PrintAsync(request);
            }
        }

        private static PrintRequest GenerateRandomPrintRequest()
        {
            return new PrintRequest()
            {
                Color = GetRandomEnumValue<PrintColor>(),
                File = GetRandomBool() ? Guid.NewGuid().ToString() : null,
                Format = GetRandomEnumValue<FileFormat>()
            };
        }

        private static T GetRandomEnumValue<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            Random random = new Random();
            return (T) values.GetValue(random.Next(values.Length));
        }

        private static bool GetRandomBool()
        {
            Random random = new Random();
            if (random.Next(5) < 2)
                return true;

            return false;
        }
    }
}