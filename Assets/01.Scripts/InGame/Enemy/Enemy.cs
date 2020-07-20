using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Information")]
    [SerializeField]
    private EnemyInformation _enemyInformation;
    protected EnemyInformation enemyInformation => _enemyInformation;

    private int _defaultHp;
    protected int defaultHp => _defaultHp;

    private int _hp;
    protected int hp => _hp;

    private float _defaultSpeed;
    protected float defaultSpeed => _defaultSpeed;

    private float _speed;
    protected float speed => _speed;

    private int _score;
    protected int score => _score;

    private SpriteRenderer _spriteRenderer;
    protected SpriteRenderer spriteRenderer => _spriteRenderer;

    private bool _isActive;
    protected bool isActive => _isActive;
        
    protected virtual void Awake(){
        _enemyInformation.GetValues(out _defaultHp, out _defaultSpeed, out _score);
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ObjectReset();
    }

    public virtual void ObjectActive(){
        gameObject.SetActive(true);
        _isActive = true;
    }

    protected virtual void Attack() { }

    protected virtual void Move() { }
    
    public virtual void GetDamage(){
        _hp--;

        if(_hp <= 0){
            Death();
        }
    }

    protected virtual void Death() { 
        StageManager.instance.GameScore += score;
        ObjectReset();
    }

    protected virtual void ObjectReset() { 
        gameObject.SetActive(false);

        _hp = _defaultHp;
        _speed = _defaultSpeed;

        _isActive = false;
    }

}
