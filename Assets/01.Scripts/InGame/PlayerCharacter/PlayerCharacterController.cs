﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{   
    [Header("Values")]
    [SerializeField]
    private float defaultSpeed;
    private float speed;

    private bool isSlow;

    private PlayerWeapon weapon;
    private SpriteRenderer spriteRenderer;

    private void Awake(){
        speed = defaultSpeed;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        weapon = gameObject.GetComponent<PlayerWeapon>();
    }

    private void Update(){
        Move();
        Attack();   
        Ability();
    }

    private void Move(){
        
        switch(Input.anyKey){
            case var k when Input.GetKey(KeyCode.LeftArrow):
            CharacterMove(Vector3.left);
            break;

            case var k when Input.GetKey(KeyCode.RightArrow):
            CharacterMove(Vector3.right);
            break;
        }
        
        switch(Input.anyKey){
            case var k when Input.GetKey(KeyCode.UpArrow):
            CharacterMove(Vector3.up);
            break;

            case var k when Input.GetKey(KeyCode.DownArrow):
            CharacterMove(Vector3.down);
            break;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed /= 3.0f;
            isSlow = true;
        } else if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = defaultSpeed;
            isSlow = false;
        }

    }

    private void CharacterMove(Vector3 moveVector){
        Vector3 characterPoint = GetCharacterViewPoint();
        
        if(moveVector.x != 0){
            float plusX = moveVector.x * speed * Time.unscaledDeltaTime;

            if(characterPoint.x + plusX > 0 && characterPoint.x + plusX < 0.65f){
                gameObject.transform.position += moveVector * speed * Time.unscaledDeltaTime;
            }
        } else if(moveVector.y != 0){
            float plusY = moveVector.y * speed * Time.unscaledDeltaTime;

            if(characterPoint.y + plusY > 0 && characterPoint.y + plusY < 0.95f){
                gameObject.transform.position += moveVector * speed * Time.unscaledDeltaTime;
            }
        }
    }
    
    private void Attack(){
        if(Input.GetKey(KeyCode.Z)){
            if(isSlow){
                weapon.StrongAttack();
                return;
            }

            weapon.Attack();
        }
    }

    private void Ability(){
        if(Input.GetKeyDown(KeyCode.X)){
            weapon.Ability();
        }
    } 

    private void Death(){

    }

    private Vector2 GetCharacterViewPoint(){
        return Camera.main.WorldToViewportPoint(gameObject.transform.position);
    }
}
