using System;
using System.Collections.Generic;
using System.Globalization;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public static class UtilsACE
{
    private static int UILayer = -1;
    //Returns 'true' if we touched or hovering on Unity UI element.
    public static bool IsPointerOverUIElement()
    {
        if (UILayer == -1)
        {
            UILayer = LayerMask.NameToLayer("UI");
        }
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }
 
    
    public static bool IsPointerOverUIElement(Vector2 touchPosition)
    {
        if (UILayer == -1)
        {
            UILayer = LayerMask.NameToLayer("UI");
        }
        return IsPointerOverUIElement(GetEventSystemRaycastResults(touchPosition));
    }
 
    //Returns 'true' if we touched or hovering on Unity UI element.
    private static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
            {
                return true;
            }
        }
        return false;
    }
 
 
    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }


    static List<RaycastResult> GetEventSystemRaycastResults(Vector2 touchPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = touchPosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
    
    public static string GetNumberAroundString(this int input)
    {
        if (input < 1000)
        {
            return input.ToString();
        }
        else if (input < 1_000_000)
        {
            return input / 1000 + "K";
        }
        else if (input < 1_000_000_000)
        {
            return input / 1_000_000 + "M";
        }
        //else if (input < 1_000_000_000_000)
        //{
        //    return input / 1_000_000_000 + "B";
        //}

        return input.ToString();
    }
    public static string GetNumberAroundString(this long input)
    {
        if (input < 5000)
        {
            return input.ToString();
        }
        else if (input < 1_000_000)
        {
            return input / 1000 + "K";
        }
        else if (input < 1_000_000_000)
        {
            return input / 1_000_000 + "M";
        }
        else if (input < 1_000_000_000_000)
        {
            return input / 1_000_000_000 + "B";
        }

        return input.ToString();
    }
    public static int GetNumberAround(this int input)
    {
        if (input < 5000)
        {
            return input;
        }
        else if (input < 1_000_000)
        {
            return (input / 1000) * 1000;
        }
        else if (input < 1_000_000_000)
        {
            return (input / 1_000_000) * 1_000_000;
        }
        //else if (input < 1_000_000_000_000)
        //{
        //    return (input / 1_000_000_000) * 1_000_000_000;
        //}
    
        return input;
    }
    public static long GetNumberAround(this long input)
    {
        if (input < 5000)
        {
            return input;
        }
        else if (input < 1_000_000)
        {
            return (input / 1000) * 1000;
        }
        else if (input < 1_000_000_000)
        {
            return (input / 1_000_000) * 1_000_000;
        }
        else if (input < 1_000_000_000_000)
        {
            return (input / 1_000_000_000) * 1_000_000_000;
        }
    
        return input;
    }

    public static string GetNumberFormat(this int input)
    {
        string formatted = string.Format(CultureInfo.InvariantCulture, "{0:N0}", input);
        return formatted;
    }
}


public static class Vibration
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate()
    {
        // if (UIController.instace.vibrate == 0)
        // {
        //     return;
        // }

        if (isAndroid())
            vibrator.Call("vibrate");
        else
            Handheld.Vibrate();
    }


    public static void Vibrate(long milliseconds)
    {
        // if (UIController.instace.vibrate == 0)
        // {
        //     return;
        // }

        if (isAndroid())
            vibrator.Call("vibrate", milliseconds);
        else
            Handheld.Vibrate();
    }

    public static bool HasVibrator()
    {
        return isAndroid();
    }

    public static void Cancel()
    {
        if (isAndroid())
            vibrator.Call("cancel");
    }

    private static bool isAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
	return true;
#else
        return false;
#endif
    }
}