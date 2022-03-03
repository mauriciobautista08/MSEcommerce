using Microsoft.Extensions.Logging;
using System;

namespace Catalos.Service.Commons
{
    public static class SyslogLoggerExtensionsBase
    {
        public static ILoggerFactory AddSyslog(this ILoggerFactory factory,
                                        string host, int port,
                                        Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new SyslogLoggerProvider(host, port, filter));
            return factory;
        }
    }
}