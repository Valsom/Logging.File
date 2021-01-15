using Valsom.Logging.File.Formats.Abstractions;
using Valsom.Logging.File.Formats.Default;

namespace Valsom.Logging.File.Formats
{
    /// <summary>
    /// Default file naming formats
    /// </summary>
    public static class FileNamingFormats
    {
        /// <summary>
        /// The default file naming format
        /// </summary>
        public static IFileNamingFormat Default => new DefaultFileNamingFormat();
    }
}
