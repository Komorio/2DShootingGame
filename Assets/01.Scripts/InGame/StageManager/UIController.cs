using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private Text scoreText;

    public void SetScoreText(int scoreValue){
        scoreText.text = scoreValue.ToString("D11");
    }
}
