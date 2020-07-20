using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet = PlayerWeaponBullet;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject bulletObjects;
    private List<Bullet> bullets = new List<Bullet>();

    private float defaultAttackCoolDown = 0.1f;
    private float attackCoolDown;
    private bool canAttack;
    
    protected virtual void Awake() {
        bullets = bulletObjects.GetComponentsInChildren<Bullet>(true).ToList();
        attackCoolDown = defaultAttackCoolDown;    
    }

    protected virtual void Update(){
        if(!canAttack){
            if(attackCoolDown > 0){
                attackCoolDown -= Time.unscaledDeltaTime;
            } else {
                attackCoolDown = defaultAttackCoolDown; 
                canAttack = true;
            }
        }
    }

    public virtual void StrongAttack(){
       
    }

    public virtual void Attack(){
        if(!canAttack){
            return;
        }
        
        Bullet generateBullet = GetAvaliableBullet(bullets);
        
        if(generateBullet == null){
            return;
        }

        generateBullet.gameObject.transform.position = gameObject.transform.position;
        generateBullet.Execute();

        canAttack = false;
    }

    public virtual void Ability(){
        
    }

    // 2020-07-16 : Avaliable 메서드 스태릭으로 바꾸는거 생각해보기
    protected Bullet GetAvaliableBullet(List<Bullet> bullet){        
        for(int i = 0; i < bullet.Count; i++){
            if(!bullet[i].gameObject.activeInHierarchy){
                return bullet[i];
            }
        }

        return null;
    }

    
}