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
        while(true){
            gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
            yield return YieldInstructionCache.WaitUntil;
        }
    }

    public virtual void Exit(){
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            other.GetComponent<Enemy>().GetDamage();
            Exit();
        }    
    }
}
