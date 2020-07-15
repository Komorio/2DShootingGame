using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [HideInInspector]
    public UIController uiController;

    protected override void Awake(){
        base.Awake();
        
        uiController = gameObject.GetComponent<UIController>();
    }
}
