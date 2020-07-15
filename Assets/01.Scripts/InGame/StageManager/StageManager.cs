using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [HideInInspector]
    public UIController uiController;

    private int gameScore;
    public int GameScore {
        get{
            return gameScore;
        }   

        set{
            gameScore = value;
            uiController.SetScoreText(gameScore);
        }
    }

    protected override void Awake(){
        base.Awake();
        
        uiController = gameObject.GetComponent<UIController>();
    }
}
