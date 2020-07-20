using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject normalEnemyObject;

    [SerializeField]
    private GameObject explosionEnemyObject;

    private List<Enemy> normalEnemys = new List<Enemy>();
    private List<Enemy> explosionEnemys = new List<Enemy>();

    private IEnumerator enemyGenerateCoroutine;

    private void Awake(){
        normalEnemys = normalEnemyObject.GetComponentsInChildren<Enemy>(true).ToList(); 
        explosionEnemys = explosionEnemyObject.GetComponentsInChildren<Enemy>(true).ToList();       
    }  

    private void Start(){
        enemyGenerateCoroutine = EnemyGenerateCoroutine().Start(this);
    }

    private IEnumerator EnemyGenerateCoroutine(){
        while(true){
            if(Random.Range(0, 2).Equals(1)){
                EnemyGenerate(normalEnemys);
            } else {
                EnemyGenerate(explosionEnemys);
            }
            yield return YieldInstructionCache.WaitingSeconds(1.5f);
        }
    }

    public void EnemyGenerate(List<Enemy> enemyList){
        Enemy generateEnemy = GetAvailableEnemy(enemyList);

        if(generateEnemy == null){
            return;
        }    

        generateEnemy.gameObject.transform.position = GetRandomViewPosition();
        generateEnemy.ObjectActive();
        
    }

    public Enemy GetAvailableEnemy(List<Enemy> list){
        for(int i = 0; i < list.Count; i++){
            if(!list[i].gameObject.activeInHierarchy){
                return list[i];
            }
        }

        return null;
    }

    private Vector2 GetRandomViewPosition(){
        Vector2 randomPosition;
        
        randomPosition.x = Random.Range(0.2f, 0.6f);
        randomPosition.y = 1.2f;

        return Camera.main.ViewportToWorldPoint(randomPosition);
    }
    
}
