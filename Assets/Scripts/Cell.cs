using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum CellType{BLACK,WHITE}
public class Cell : MonoBehaviour
{   
    public CellType mCelltype;
    [SerializeField]
    TextMeshPro m_CellNo;
    [SerializeField]
    SpriteRenderer m_SpriteRenderer;
    public string text;
    private int m_ID;
    public static bool mFirstTimeClicked=true;
    
    public int ID
    {
        get
        {
            return m_ID;
        }
    }
    void Start()
    {
        
    }

    public void SetID(int id)
    {
        m_ID=id;
        m_CellNo.text=id.ToString();
    }
    public void OnMouseDownTest()
    {
        text=ID.ToString();
        AdjustingScript.Instance.InstatiatingTheBall(Int32.Parse(text));
        mFirstTimeClicked=false;
    }

    public void SetColor(Color inColor)
    {
        m_SpriteRenderer.color=inColor;
    }
}
