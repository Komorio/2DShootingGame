using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{   
    [Header("Values")]
    [SerializeField]
    private float defaultSpeed;
    private float speed;

    private SpriteRenderer spriteRenderer;
    private Vector2 moveVector;

    private void Awake(){
        speed = defaultSpeed;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update(){
        Move();
        Attack();   
    }

    private void Move(){
        float verticalValue = Input.GetAxis("Vertical");
        float horizontalValue = Input.GetAxis("Horizontal");
        
        moveVector.x = horizontalValue;
        moveVector.y = verticalValue;

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed /= 3.0f;
        } 

        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = defaultSpeed;
        }

        gameObject.transform.Translate(moveVector * speed * Time.unscaledDeltaTime);
    }

    private void Attack(){
        
    }

    private void Ability(){

    }

    private void Death(){

    }
}
