using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Values")]
    [SerializeField]
    private float speed;
    private Vector2 direction;

    public void Execute(Vector2 direction){
        this.direction = direction;
        gameObject.SetActive(true);
        ExecuteCoroutine().Start(this);
    } 

    private IEnumerator ExecuteCoroutine(){
        Vector2 viewPoint;
        
        while(true){
            viewPoint = GetBulletViewPosition();

            if(viewPoint.y > 1 || viewPoint.y < 0){
                Exit();
            }

            gameObject.transform.Translate(direction * speed * Time.deltaTime);
            yield return YieldInstructionCache.WaitUntil;
        }
    }


    private Vector2 GetBulletViewPosition(){
        return Camera.main.WorldToViewportPoint(gameObject.transform.position);
    }

    public void Exit(){
        gameObject.transform.localPosition = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            // 2020-07-16 : 플레이어 데미지 입는거 구현
            Exit();
        }    
    }

}
