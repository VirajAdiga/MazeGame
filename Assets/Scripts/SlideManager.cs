using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlideManager : MonoBehaviour
{
    public RectTransform mMainMenu, mOptions,mPlay,mQuit;
    void Start()
    {
        mMainMenu.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void getOptions(){
        mMainMenu.DOAnchorPos(new Vector2(-720,0),0.3f);
        mOptions.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void closeOptions(){
        mOptions.DOAnchorPos(new Vector2(720,0),0.3f);
        mMainMenu.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void getPlay(){
        mMainMenu.DOAnchorPos(new Vector2(-720,0),0.3f);
        mPlay.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void closePlay(){
        mPlay.DOAnchorPos(new Vector2(0,1320),0.5f);
        mMainMenu.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void getQuit(){
        mMainMenu.DOAnchorPos(new Vector2(-720,0),0.3f);
        mQuit.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void quit(){
        Application.Quit();
    }
    public void closeQuit(){
        mQuit.DOAnchorPos(new Vector2(0,-1320),0.3f);
        mMainMenu.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void getClassic(){
        mPlay.DOAnchorPos(new Vector2(-720,0),0.3f);
    }
    public void closeClassic(){
        mPlay.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void getTime(){
        mPlay.DOAnchorPos(new Vector2(-1440,0),0.3f);       
    }
    public void closeTime(){
        mPlay.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void getEnemy(){
        mPlay.DOAnchorPos(new Vector2(-2160,0),0.3f);  
    }
    public void closeEnemy(){
        mPlay.DOAnchorPos(Vector2.zero,0.3f);
    }
    public void openClassic(){
        Application.LoadLevel("Classic");
    }
}
