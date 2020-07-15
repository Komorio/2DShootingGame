using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{   
    private Vector2 moveVector;

    protected override void Awake(){
        moveVector = Vector2.down;
    }

    private void Update(){
        if(!isActive){
            this.enabled = false;
        }

        gameObject.transform.Translate(moveVector * speed * Time.deltaTime);       
    }
}
