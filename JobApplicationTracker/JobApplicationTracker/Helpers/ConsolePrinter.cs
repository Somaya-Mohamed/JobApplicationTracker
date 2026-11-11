using System;

namespace JobApplicationTracker.Helpers
{
    public static class ConsolePrinter
    {
        public static void WriteTitle(string message)
        {
            WriteColored(message, ConsoleColor.Cyan);
        }

        public static void WriteSuccess(string message)
        {
            WriteColored(message, ConsoleColor.Green);
        }

        public static void WriteError(string message)
        {
            WriteColored(message, ConsoleColor.Red);
        }

        public static void WriteWarning(string message)
        {
            WriteColored(message, ConsoleColor.Yellow);
        }

        public static void WriteInfo(string message)
        {
            WriteColored(message, ConsoleColor.Gray);
        }

        public static void WritePrompt(string message)
        {
            WriteColored(message, ConsoleColor.DarkYellow, false);
        }

        public static void WriteResult(
            bool isSuccess,
            string successMessage,
            string failureMessage)
        {
            if (isSuccess)
                WriteSuccess(successMessage);
            else
                WriteError(failureMessage);
        }

        private static void WriteColored(
            string message,
            ConsoleColor color,
            bool newLine = true)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            try
            {
                Console.ForegroundColor = color;

                if (newLine)
                    Console.WriteLine(message);
                else
                    Console.Write(message);
            }
            finally
            {
                Console.ForegroundColor = oldColor;
            }
        }
    }
}
