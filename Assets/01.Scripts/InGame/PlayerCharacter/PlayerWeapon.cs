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

    private void Awake() {
        bullets = bulletObjects.GetComponentsInChildren<Bullet>(true).ToList();    
    }

    public virtual void StrongAttack(){
        Attack();
    }

    public virtual void Attack(){
        GetAvaliableBullet(bullets)?.Execute();
    }

    protected Bullet GetAvaliableBullet(List<Bullet> bullet){
        for(int i = 0; i < bullet.Count; i++){
            if(!bullet[i].gameObject.activeInHierarchy){
                return bullet[i];
            }
        }

        return null;
    }

    
}