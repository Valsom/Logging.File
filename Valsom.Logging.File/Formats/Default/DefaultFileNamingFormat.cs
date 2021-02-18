using System;
using System.IO;

using Valsom.Logging.File.Formats.Abstractions;

namespace Valsom.Logging.File.Formats.Default
{
    public class DefaultFileNamingFormat : IFileNamingFormat
    {
        internal DefaultFileNamingFormat()
        {

        }

        /// <inheritdoc />
        public string NameFile(DirectoryInfo directory, string name)
        {
            var i = 0;

            while (true)
            {
                i++;

                var file = $"{name}.{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}.{i:000}.log";

                if (directory.GetFiles(file).Length == 0)
                {
                    return file;
                }
            }
        }
    }
}
