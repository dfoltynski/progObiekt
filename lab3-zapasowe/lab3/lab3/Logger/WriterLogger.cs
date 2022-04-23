using System;
using System.IO;

namespace lab3.Logger
{
    public abstract class WriterLogger: ILogger
    {
        protected TextWriter writer;

        public abstract void Dispose();

        public void Log(params string[] messages)
        {
            this.writer.Write(DateTime.Now.ToString("o"));
            this.writer.Write(":");
            foreach (var message in messages)
            {
                writer.Write(" " + message);
            }
            writer.Write(Environment.NewLine);
            writer.Flush();
        }
    }
}
