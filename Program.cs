using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TimedCommand
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var (DelayMilliseconds, Command) = ParseArguments(args);

            await Task.Delay(DelayMilliseconds);

            ExecuteCommand(Command);
        }

        private static (int DelayMilliseconds, string Command) ParseArguments(string[] args)
        {
            if (args.Length < 2)
                throw new ArgumentException("Less than two arguments supplied!", nameof(args));

            if (!int.TryParse(args[0], out var parsedDelay))
                throw new ArgumentException("First argument is not a number!", nameof(args));

            if (parsedDelay < 0)
                throw new ArgumentException("Delay is negative!", nameof(args));

            if (string.IsNullOrEmpty(args[1]))
                throw new ArgumentException("Second argument is no valid command!", nameof(args));

            return (parsedDelay, args[1]);
        }

        private static void ExecuteCommand(string command)
        {
            var process = new Process();
            var processInfo = new ProcessStartInfo("cmd.exe", $"/C {command}")
            {
                WindowStyle = ProcessWindowStyle.Hidden
            };
            process.StartInfo = processInfo;
            process.Start();
        }
    }
}
