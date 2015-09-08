using UnityEngine;
using System.Collections;

namespace Developers
{
    public enum LogSeverity
    {
        MISC,
        WARNING,
        ERROR,
        FATAL
    }

    public class DBG : MonoBehaviour
    {
        public static void Log(string msg, LogSeverity severity = LogSeverity.MISC)
        {
            switch(severity)
            {
                case LogSeverity.MISC:
                    Debug.Log(msg);
                    break;
                case LogSeverity.WARNING:
                    Debug.LogWarning(msg); 
                    break;
                case LogSeverity.ERROR:
                    Debug.LogError(msg);
                    break;
                case LogSeverity.FATAL:
                    Debug.LogError(msg);
                    Debug.Break();
                    break;
            }
        }
    }

}