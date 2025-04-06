using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Score.instance.UpdateScore();
           TriggerHaptic();

        }
    }

    public void TriggerHaptic()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        vibrator.Call("vibrate", 100); // Vibrate for 100ms
#elif UNITY_IOS && !UNITY_EDITOR
        Handheld.Vibrate(); // iOS basic vibration
#else
        Debug.Log("Haptic feedback is not supported on this platform.");
#endif
    }
}
