using System;
using System.Collections.Generic;
using Migrator.Framework;

namespace Agendas.Infrastructure
{
    class TraceLogger : IDisposable, ILogger
    {
        public TraceLogger(string initialMessage)
        {
            System.Diagnostics.Trace.Write(initialMessage + " ...");
        }

        public void Dispose()
        {
            System.Diagnostics.Trace.WriteLine("Done.");
        }

        public void Started(List<long> currentVersion, long finalVersion)
        {
        }

        public void MigrateUp(long version, string migrationName)
        {
        }

        public void MigrateDown(long version, string migrationName)
        {
        }

        public void Skipping(long version)
        {
        }

        public void RollingBack(long originalVersion)
        {
        }

        public void ApplyingDBChange(string sql)
        {
        }

        public void Exception(long version, string migrationName, Exception ex)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("Migration {0} ({1}) failed with exception:", version, migrationName));
            System.Diagnostics.Trace.WriteLine(ex);
        }

        public void Exception(string message, Exception ex)
        {
            System.Diagnostics.Trace.WriteLine(message);
            System.Diagnostics.Trace.WriteLine(ex);
        }

        public void Finished(List<long> currentVersion, long finalVersion)
        {
        }

        public void Log(string format, params object[] args)
        {
        }

        public void Warn(string format, params object[] args)
        {
        }

        public void Trace(string format, params object[] args)
        {
        }
    }
}