
using System;
using System.IO;

namespace lab3.Logger
{
    public class FileLogger : WriterLogger
    {
        public FileLogger(string filename)
        {
            base.writer = File.AppendText(filename);
        }

        public override void Dispose()
        {
            base.writer.Dispose();
        }
    }
}