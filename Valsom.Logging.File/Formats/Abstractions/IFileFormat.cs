﻿using Microsoft.Extensions.Logging;

using System;
using System.Text;

namespace Valsom.Logging.File.Formats.Abstractions
{
    /// <summary>
    /// A format used for formatting the file
    /// </summary>
    public interface IFileFormat
    {
        StringBuilder CreateLogEntry(LogLevel logLevel, string category, EventId eventId, string message, Exception ex);
    }
}
