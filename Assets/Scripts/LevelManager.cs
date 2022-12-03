using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool isTime,isEnemy;
    void Start(){
        isTime=false;
        isEnemy=false;
    }
    public void timeTrial(){
        isTime=true;
    }
    public void enemyHub(){
        isEnemy=true;
    }
}
