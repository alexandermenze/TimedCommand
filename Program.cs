using System;
using System.Threading.Tasks;

namespace TimedCommand
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var arguments = ParseArguments(args);
        }

        private static (int DelayMilliseconds, string Command) ParseArguments(string[] args)
        {
            if (args.Length < 2)
                throw new ArgumentException("Less than two arguments supplied!", nameof(args));

            if (!int.TryParse(args[0], out var parsedDelay))
                throw new ArgumentException("First argument is not a number!", nameof(args));

            if (string.IsNullOrEmpty(args[1]))
                throw new ArgumentException("Second argument is no valid command!", nameof(args));

            return (parsedDelay, args[1]);
        }
    }
}
