using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET.Logging
{
    class Tracer : TraceListener, ITraceWriter
    {

        #region Private Fields

        private static Tracer tracer = null;

        private string logFile = Path.Combine(Environment.CurrentDirectory, "SoundCloud.NET.log");

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Trägt den Tracer in die TraceListeners-Liste ein.
        /// </summary>
        private Tracer()
        {
            System.Diagnostics.Trace.AutoFlush = true;
            System.Diagnostics.Trace.Listeners.Add(this);

            this.LogWriter = new StreamWriter(logFile, false, Encoding.UTF8);
            this.LogWriter.AutoFlush = true;

            this.WriteLine("Tracer initialisiert!");
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        /// Ruft die Log-Instanz ab
        /// </summary>
        public static Tracer Instance
        {
            get
            {
                if (tracer == null)
                {
                    tracer = new Tracer();
                }

                return tracer;
            }
        }

        public TraceLevel LevelFilter
        {
            get { return TraceLevel.Warning; }
        }

        #endregion Public Properties

        #region Private Properties

        private StreamWriter LogWriter { get; set; }

        #endregion Private Properties

        #region Public Methods

        public override void Close()
        {
            // Log-Datei schließen
            this.LogWriter.Flush();
            this.LogWriter.Close();

            base.Close();
        }

        public string GetLinePrefix()
        {
            return DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " : ";
        }

        public void Trace(TraceLevel level, string message, Exception ex)
        {
            this.WriteLine(level.ToString() + ": " + message + " (" + ex.Message + ")");
        }

        public override void Write(string message)
        {
            this.WriteLine(message);
        }

        public override void WriteLine(string message)
        {
            this.LogWriter.WriteLine(this.GetLinePrefix() + message);
        }

        #endregion Public Methods
    }
}
