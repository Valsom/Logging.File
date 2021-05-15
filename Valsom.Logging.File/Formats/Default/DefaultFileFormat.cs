using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Valsom.Logging.File.Formats.Abstractions;

namespace Valsom.Logging.File.Formats.Default
{
    public class DefaultFileFormat : IFileFormat
    {
        internal DefaultFileFormat()
        {
        }

        /// <inheritdoc />
        public StringBuilder CreateLogEntry(LogLevel logLevel, string category, EventId eventId, string message,
            Exception ex)
        {
            StringBuilder entry = new StringBuilder();

            var now = DateTime.Now;

            // 2021/01/23 24:12:23.400 
            entry.Append($"{now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} ");

            // debug
            entry.Append($"{GetLogLevel(logLevel).ToUpper(),5} ");

            // Somfic.Logging.Test.Source
            entry.Append($"{category} ");

            entry.AppendLine();
            entry.Append("                              ");
            entry.Append(message);

            if (ex != null)
            {
                string stack = ex.StackTrace;

                while (ex != null)
                {
                    entry.AppendLine();
                    entry.Append("                              ");

                    // Invalid file format
                    entry.Append(GetPrettyExceptionName(ex));

                    entry.Append(": ");
                    entry.Append(ex.Message.Trim());

                    if (ex.Data.Count > 0)
                    {
                        entry.AppendLine();
                        entry.Append(JsonConvert.SerializeObject(ex.Data));
                    }

                    ex = ex.InnerException;
                }

                if (!string.IsNullOrWhiteSpace(stack))
                {
                    IEnumerable<string> stackLines = stack.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
                    stackLines = stackLines.Reverse();

                    for (int index = 0; index < stackLines.Count(); index++)
                    {
                        string stackLine = stackLines.ElementAt(index).Trim();

                        entry.AppendLine();
                        entry.Append("                              ");

                        entry.Append(index + 1);
                        entry.Append($": {stackLine}");
                    }
                }
            }

            return entry;
        }

        private string GetLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    return "Trace";
                case LogLevel.Debug:
                    return "Debug";
                case LogLevel.Information:
                    return "Info";
                case LogLevel.Warning:
                    return "Warn";
                case LogLevel.Error:
                    return "Error";
                case LogLevel.Critical:
                    return "Fail";
                case LogLevel.None:
                    return "None";
                default:
                    return "?????";
            }
        }

        private string GetPrettyExceptionName(Exception ex)
        {
            string output = Regex.Replace(ex.GetType().Name, @"\p{Lu}", m => " " + m.Value.ToLowerInvariant());

            output = ex.GetType().Name == "Exception" ? "Exception" : output.Replace("exception", "");

            output = output.Trim();
            output = char.ToUpperInvariant(output[0]) + output.Substring(1);
            switch (output)
            {
                case "I o":
                    output = "IO";
                    break;
            }

            return output;
        }
    }
}