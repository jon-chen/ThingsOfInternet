using System;
using System.Linq;
using System.Text;

namespace ThingsOfInternet.Utilities
{
    public static class ExceptionExtensions
    {
        public static string AsFriendlyMessage(this AggregateException exception)
        {
            var exceptions = exception
                .Flatten()
                .InnerExceptions
                .ToList();

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}:", exception.Message);
            builder.AppendLine();

            for (int i = 0; i < exceptions.Count; i++)
            {
                builder.AppendFormat("({0}) {1}", i+1, exceptions[i].Message);
                builder.AppendLine();
            }

            return builder.ToString();
        }

        public static string AsFlattenedMessage(this AggregateException exception)
        {
            var exceptions = exception
                .Flatten()
                .InnerExceptions
                .ToList();

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < exceptions.Count; i++)
            {
                if (exceptions.Count > 1)
                {
                    builder.AppendFormat("({0}) ", i + 1);
                }

                builder.Append(exceptions[i].Message);

                if (i + 1 != exceptions.Count)
                {
                    builder.Append(", ");
                }
            }

            return builder.ToString();
        }
    }
}

