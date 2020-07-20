using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alisha_Weapon : PlayerWeapon
{
    private bool isPause;
    private float defaultPauseTime = 5.0f;
    private float pauseTime;

    private void LateUpdate() {
        if(isPause){
            if(pauseTime < defaultPauseTime){
                pauseTime += Time.unscaledDeltaTime;
                return;
            }

            pauseTime = 0.0f;
            isPause = false;
            Time.timeScale = 1.0f;
        }
    }

    public override void StrongAttack(){
        if(!isPause){
            isPause = true;
            Time.timeScale = 0.0f;
        }
    }
}
