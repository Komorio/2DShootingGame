using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : Enemy
{
    [SerializeField]
    private EnemyBullet[] bullets;
    private Vector2 moveVector;
    private bool isDeath;
    private BoxCollider2D boxCollider;

    protected override void Awake(){
        moveVector = Vector2.down;
        boxCollider = gameObject.GetComponent<BoxCollider2D>();

        base.Awake();
    }

    private void Update(){
        if(!isActive){
            this.enabled = false;
        }

        if(!isDeath){
            gameObject.transform.Translate(moveVector * speed * Time.deltaTime);     
        }

        if(!bullets[bullets.Length - 1].gameObject.activeInHierarchy && isDeath){
            base.Death();
            isDeath = false;
        }  
    }

    protected override void Death(){
        Vector2 pivotPosition = (Vector2)gameObject.transform.position;

        for(int i = 0; i < bullets.Length; i++){
            float value = ((float)i / (float)bullets.Length) * (2 * Mathf.PI) - (Mathf.PI / 2);
            
            Vector2 direction;
            direction.x = Mathf.Cos(value);
            direction.y = Mathf.Sin(value);
            
            bullets[i].Execute(direction);
        }
        
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;

        isDeath = true;
    }

    protected override void ObjectReset(){
        base.ObjectReset();

        for(int i = 0; i < bullets.Length; i++){
            bullets[i].Exit();
        }

        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
    }
}
