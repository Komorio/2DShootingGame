using UnityEngine;
using System.Collections;

public static class ExtensionMethods{
    public static IEnumerator Start(this IEnumerator coroutine, MonoBehaviour monoBehaviour){
        monoBehaviour.StartCoroutine(coroutine);
        return coroutine;
    }

    public static void Stop(this IEnumerator coroutine, MonoBehaviour monoBehaviour){
        monoBehaviour.StopCoroutine(coroutine);
    }

    public static void Log(this object value){
        Debug.Log(value.ToString());
    }
}