

using UnityEngine;
/// <summary>
/// Contains UI helper methods
/// </summary>
public static class DebugUtil
{

    public static void LogVector3(string msg,Vector3 v3)
    {
        Debug.LogFormat("{0} x:{1} y:{2} z:{3}", msg, v3.x, v3.y, v3.z);

    }

    public static void Log(string msg)
    {
        Debug.Log(msg);

    }

    public static void LogFormat(string format, params object[] args)
    {
        Debug.LogFormat(format,args);

    }



}

