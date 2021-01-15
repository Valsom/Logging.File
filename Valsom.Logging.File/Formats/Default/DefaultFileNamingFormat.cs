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
            int i = 0;

            while (true)
            {
                i++;

                string file = $"{name}.{i:000}.log";

                if (directory.GetFiles(file).Length == 0)
                {
                    return file;
                }
            }
        }
    }
}
