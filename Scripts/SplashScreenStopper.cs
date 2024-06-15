//#if !UNITY_EDITOR
using UnityEngine;
using UnityEngine.Rendering;

public class SkipSplash
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    private static void BeforeSplashScreen()
    {
#if UNITY_WEBGL
        Application.focusChanged += Application_focusChanged;
        //#else
        //System.Threading.Tasks.Task.Run(AsyncSkip);
#endif
    }
    private static void Application_focusChanged(bool obj)
    {
#if UNITY_WEBGL
        Application.focusChanged -= Application_focusChanged;
        SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
#endif
    }
    //#else
    //private static void AsyncSkip()
    //{
    //SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
    //}
}
//#endif