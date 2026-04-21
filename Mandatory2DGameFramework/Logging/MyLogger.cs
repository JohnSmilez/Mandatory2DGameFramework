using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Mandatory2DGameFramework.Logging
{
    public class MyLogger
    {
        // ===== SINGLETON =====
        private static readonly Lazy<MyLogger> _instance =
            new Lazy<MyLogger>(() => new MyLogger());

        public static MyLogger Instance => _instance.Value;

        // ===== INTERNAL =====
        private readonly TraceSource _traceSource;
        private readonly SourceSwitch _switch;
        private readonly List<TraceListener> _listeners;

        // ===== CONSTRUCTOR =====
        private MyLogger()
        {
            _traceSource = new TraceSource("GameLog", SourceLevels.All);
            _switch = new SourceSwitch("LogSwitch", SourceLevels.All.ToString());
            _traceSource.Switch = _switch;

            _listeners = new List<TraceListener>();
        }

        // ===== LISTENERS =====
        public void AddListener(TraceListener listener)
        {
            if (!_listeners.Contains(listener))
            {
                _listeners.Add(listener);
                _traceSource.Listeners.Add(listener);
            }
        }

        public void RemoveListener(TraceListener listener)
        {
            if (_listeners.Contains(listener))
            {
                _listeners.Remove(listener);
                _traceSource.Listeners.Remove(listener);
            }
        }

        // ===== LOG METHODS =====
        public void Log(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Information, 0, message);
            _traceSource.Flush();
        }

        public void LogWarning(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Warning, 0, message);
            _traceSource.Flush();
        }

        public void LogError(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Error, 0, message);
            _traceSource.Flush();
        }

        // ===== SPECIFIC GAME EVENTS =====
        public void LogDamage(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Information, 1, message);
        }

        public void LogLowHP(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Warning, 2, message);
        }

        public void LogDeath(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Critical, 3, message);
        }

        // ===== CLEANUP =====
        public void Close()
        {
            _traceSource.Close();

            foreach (var listener in _listeners)
            {
                listener.Close();
            }
        }
    }
}