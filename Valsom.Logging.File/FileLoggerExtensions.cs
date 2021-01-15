using System.IO;
using Microsoft.Extensions.Logging;
using Valsom.Logging.File.Formats;
using Valsom.Logging.File.Formats.Abstractions;

namespace Valsom.Logging.File
{
    public static class FileLoggerExtensions
    {
        /// <summary>
        /// Adds a <see cref="FileLogger"/> instance to the <seealso cref="ILoggingBuilder"/>
        /// </summary>
        /// <param name="name">The name of this log file</param>
        /// <param name="directory">The directory of the log file</param>
        /// <param name="namingFormat">The naming format applied</param>
        /// <param name="format">The format applied</param>
        public static ILoggingBuilder AddPrettyConsole(this ILoggingBuilder builder, string name, DirectoryInfo directory, IFileNamingFormat namingFormat, IFileFormat format)
        {
            if (namingFormat == null) { namingFormat = FileNamingFormats.Default; }
            if (format == null) { format = FileFormats.Default; }

            builder.AddProvider(new FileLoggerProvider(name, directory, namingFormat, format));

            return builder;
        }
    }
}