using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class MenuAnim : MonoBehaviour
{
    [SerializeField]
    GameObject mGmOb;
    public void muteAudio(bool value){
        mGmOb.gameObject.SetActive(value);
    }

}
