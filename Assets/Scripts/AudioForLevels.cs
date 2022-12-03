using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForLevels : MonoBehaviour
{
    [SerializeField]
    GameObject mGmOb;
    public void muteAudio(){
        if(mGmOb.activeInHierarchy){
            mGmOb.gameObject.SetActive(false);
        }else{
            mGmOb.gameObject.SetActive(true);
        }
    }
    public void backToMain(){
        Application.LoadLevel("MenuNew");
    }
}
