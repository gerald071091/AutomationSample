using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AutoCore
{
    public static class ProcessHelper
    {
        /// <summary>
        /// Ends the selected processes activity in window process provided by list<string>
        /// </summary>
        /// <param name="listProcess"></param>
        public static void EndSession(this Process prc, params string[] listProcess)
        {
            foreach (string process in listProcess)
            {
                foreach (Process proc in GetSpecificProcess(process))
                {
                    proc.Kill();
                }
            }
        }

        /// <summary>
        /// Ends the selected processes activity in window process provided by string list
        /// </summary>
        /// <param name="args"></param>
        public static void EndSession(this Process prc, string args)
        {
            if (args.Contains(','))
            {
                List<string> listProcess = args.Split(',').ToList();

                foreach (string process in listProcess)
                {
                    foreach (Process proc in GetSpecificProcess(process))
                    {
                        proc.Kill();
                    }
                }
            }

            foreach (var proc in GetSpecificProcess(args))
            {
                proc.Kill();
            }
        }

        private static IEnumerable<Process> GetSpecificProcess(string process)
        {
            return Process.GetProcesses().Where(pr => pr.ProcessName == process.Trim());
        }
    }
}
