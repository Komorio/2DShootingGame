using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponBullet : MonoBehaviour
{   
    [Header("Values")]
    [SerializeField]
    private float _speed;
    protected float speed => _speed;
    public virtual void Execute(){
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

            gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
            yield return YieldInstructionCache.WaitUntil;
        }
    }

    public virtual void Exit(){
        gameObject.SetActive(false);
    }

    private Vector2 GetBulletViewPosition(){
        return Camera.main.WorldToViewportPoint(gameObject.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            other.GetComponent<Enemy>().GetDamage();
            Exit();
        }    
    }
}
