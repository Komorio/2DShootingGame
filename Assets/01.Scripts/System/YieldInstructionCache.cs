using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class YieldInstructionCache{
    private static Dictionary<float, WaitForSeconds> waitForSecondDictionary = new Dictionary<float, WaitForSeconds>();
    private static object waitUntil = null;

    public static object WaitUntil => waitUntil;

    public static WaitForSeconds WaitSeconds(float value){
        if(!waitForSecondDictionary.ContainsKey(value)){
            waitForSecondDictionary.Add(value, new WaitForSeconds(value));
        }
        
        return waitForSecondDictionary[value];
    }
}