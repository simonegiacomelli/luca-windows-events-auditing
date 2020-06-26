using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<EventRecord>();
            string eventQueryString = "*";
            EventLogQuery eventQuery = new EventLogQuery("Application", PathType.LogName, eventQueryString);
            var ev = new EventLogWatcher(eventQuery, null, false);
            ev.EventRecordWritten += (sender, eventArgs) =>
            {
                var rec = eventArgs.EventRecord;
                list.Add(rec);

                Console.WriteLine($"event Id={rec.Id} RecordId={rec.RecordId} {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(100);
            };
            ev.Enabled = true;
            Console.WriteLine($"root-id={Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"minid={list.Min(x => x.RecordId)}  maxid={list.Max(x => x.RecordId)} ");
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}