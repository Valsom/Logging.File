using Valsom.Logging.File.Formats.Abstractions;
using Valsom.Logging.File.Formats.Default;

namespace Valsom.Logging.File.Formats
{
    /// <summary>
    /// Default file formats
    /// </summary>
    public static class FileFormats
    {
        /// <summary>
        /// The default file format
        /// </summary>
        public static IFileFormat Default => new DefaultFileFormat();
    }
}
