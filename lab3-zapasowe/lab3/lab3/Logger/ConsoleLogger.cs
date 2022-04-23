using System;

namespace lab3.Logger
{
    public class ConsoleLogger : WriterLogger
    {
        public ConsoleLogger()
        {
            base.writer = Console.Out;
        }

        public override void Dispose()
        {
            // empty
        }
    }
}