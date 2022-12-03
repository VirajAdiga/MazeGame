using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public void time(){
        LevelManager.isTime=true;
        Application.LoadLevel("Classic");
    }
    public void enemy(){
        LevelManager.isEnemy=true;
        Application.LoadLevel("Classic");
    }

    public void classic(){
        LevelManager.isEnemy=false;
        LevelManager.isTime=false;
        Application.LoadLevel("Classic");
    }
}
