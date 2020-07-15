using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInformation", menuName = "EnemyInformation", order = 0)]
public class EnemyInformation : ScriptableObject {

    [SerializeField]
    private int _defaultHp;

    [SerializeField]
    private float _defaultSpeed;
    
    [SerializeField]
    private int _score;

    public void GetValues(out int defaultHp, out float defaultSpeed, out int score){
        defaultHp = _defaultHp;
        defaultSpeed = _defaultSpeed;
        score = _score;
    }
}