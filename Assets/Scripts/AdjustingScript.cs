using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Newtonsoft.Json; 
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class AdjustingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject mPrefab;
    private int mNumberOfRows, mNumberOfColumns;
    private float mCameraAspectRatio;
    private float mShapeWidth;
    private float mShapeHeight;
    private List<Cell> m_GridCells;
    [SerializeField]
    private GameObject mBallPrefab;
    Vector3 cellScale;
    GameObject mCricle;
    GameObject mCircleCopy;
    private int[,] mMaze;
    Test[] test;
    int source,destination;
    System.Random mRand;
    [SerializeField]
    RectTransform mHome;
    [SerializeField]
    Text mText;
    [SerializeField]
    Button mRestart,mMute,mTime,mEnemy,mClassic,mHint,mUndo;
    bool isTime=false,isEnemy=false;
    float timeStart;
    int num;
    [SerializeField]
    GameObject mAudioManager,mWon,mLost;
    [SerializeField]
    Text mRunningTime;
    private List<Vector3> mVectorList;
    int sx,sy,dx,dy;
    int [,] path;

    GameObject mC1, mC2;
    bool isInstantiated = false;

    [SerializeField]
    private GameObject panel;
    bool canStart = false;

    private AdjustingScript()
    {
        
    }
    static AdjustingScript m_Instance;
    public static AdjustingScript Instance
    {
        get
        {
            return m_Instance;
        }
    }
    void Awake()
    {
        mRand=new System.Random();
        m_Instance=this;
        TextAsset t=Resources.Load("MazeData") as TextAsset;
        string text=t.ToString();
        test=JsonConvert.DeserializeObject<Test[]>(text);
        num=mRand.Next(test.Length);
        mMaze=test[num].Maze;
        source=test[num].source;
        destination=test[num].destination;
        mNumberOfRows=mMaze.GetLength(0);
        mNumberOfColumns=mMaze.GetLength(1);
        mTime.gameObject.SetActive(false);
        mEnemy.gameObject.SetActive(false);
        mClassic.gameObject.SetActive(false);
        mRunningTime.gameObject.SetActive(false);
        mWon.gameObject.SetActive(false);
        mLost.gameObject.SetActive(false);
        mAudioManager.gameObject.SetActive(true);
        mMute.enabled=true;
        mRestart.enabled=true;
        mHint.enabled=true;
        mUndo.enabled=true;
        if(LevelManager.isTime){
            isTime=true;
        }
        if(LevelManager.isEnemy){
            isEnemy=true;
        }
    }
    void itIsTime(){
        timeStart=20;
        mRunningTime.gameObject.SetActive(true);
        mRunningTime.text="00 : "+timeStart.ToString();
    }
    void itIsEnemy(){
        timeStart=30;
        mRunningTime.gameObject.SetActive(true);
        mRunningTime.text="00 : "+timeStart.ToString();
    }
    void Start()
    {
        m_GridCells=new List<Cell>();
        path=new int[mNumberOfRows,mNumberOfColumns];
        mCameraAspectRatio=Camera.main.aspect;
        mShapeHeight=Camera.main.orthographicSize*2;
        cellScale=new Vector3((mCameraAspectRatio*mShapeHeight)/mNumberOfColumns,mShapeHeight/mNumberOfRows,0);
        mVectorList=new List<Vector3>();
        CreateGrid();
        mVectorList.Add(m_GridCells[source].transform.position);
        if(isTime)itIsTime();
        if(isEnemy)itIsEnemy();
    }

    public void InstatiatingTheBall(int x)
    {
        if(isEnemy){
            if(num==0){
                //GameObject mC1,mC2;
                mC1 =  Instantiate(mBallPrefab);
                mC1.transform.position=m_GridCells[99].transform.position;
                mC1.transform.localScale=cellScale;
                mC2 =  Instantiate(mBallPrefab);
                mC2.transform.position=m_GridCells[126].transform.position;
                mC2.transform.localScale=cellScale;
            }else if(num==1){
                //GameObject mC1,mC2;
                mC1 =  Instantiate(mBallPrefab);
                mC1.transform.position=m_GridCells[77].transform.position;
                mC1.transform.localScale=cellScale;
                mC2 =  Instantiate(mBallPrefab);
                mC2.transform.position=m_GridCells[125].transform.position;
                mC2.transform.localScale=cellScale;
            }else if(num==2){
                //GameObject mC1,mC2;
                mC1 =  Instantiate(mBallPrefab);
                mC1.transform.position=m_GridCells[126].transform.position;
                mC1.transform.localScale=cellScale;
                mC2 =  Instantiate(mBallPrefab);
                mC2.transform.position=m_GridCells[111].transform.position;
                mC2.transform.localScale=cellScale;
            }else if(num==3){
                //GameObject mC1,mC2;
                mC1 =  Instantiate(mBallPrefab);
                mC1.transform.position=m_GridCells[83].transform.position;
                mC1.transform.localScale=cellScale;
                mC2 =  Instantiate(mBallPrefab);
                mC2.transform.position=m_GridCells[129].transform.position;
                mC2.transform.localScale=cellScale;
            }else if(num==4){
                //GameObject mC1,mC2;
                mC1 =  Instantiate(mBallPrefab);
                mC1.transform.position=m_GridCells[31].transform.position;
                mC1.transform.localScale=cellScale;
                mC2 =  Instantiate(mBallPrefab);
                mC2.transform.position=m_GridCells[103].transform.position;
                mC2.transform.localScale=cellScale;
            }else if(num==5){
                //GameObject mC1,mC2;
                mC1 =  Instantiate(mBallPrefab);
                mC1.transform.position=m_GridCells[70].transform.position;
                mC1.transform.localScale=cellScale;
                mC2 =  Instantiate(mBallPrefab);
                mC2.transform.position=m_GridCells[150].transform.position;
                mC2.transform.localScale=cellScale;
            }else{
                //GameObject mC1,mC2;
                mC1 =  Instantiate(mBallPrefab);
                mC1.transform.position=m_GridCells[30].transform.position;
                mC1.transform.localScale=cellScale;
                mC2 =  Instantiate(mBallPrefab);
                mC2.transform.position=m_GridCells[138].transform.position;
                mC2.transform.localScale=cellScale;
            }
        }
        if(mCricle==null)
        {
            mCricle =  Instantiate(mBallPrefab);
            mCricle.transform.position=m_GridCells[source].transform.position;
            mCricle.transform.localScale=cellScale;
        }
        if(mCircleCopy==null)
        {
            mCircleCopy=Instantiate(mBallPrefab);
            mCircleCopy.transform.position=m_GridCells[destination].transform.position;
            mCircleCopy.transform.localScale=cellScale;
        }
        panel.SetActive(false);
        canStart = true;
        isInstantiated = true;
            Vector3 tempVector=m_GridCells[x-1].transform.position;
            float posX=mCricle.transform.position.x-m_GridCells[x-1].transform.position.x;
            float posY=mCricle.transform.position.y-m_GridCells[x-1].transform.position.y;
            if(posY>0&&posX==0){
                int n=(int)((mCricle.transform.position.y-m_GridCells[x-1].transform.position.y)/mCricle.transform.localScale.y);
                if(n>0){
                    while(n>=0){
                        if(m_GridCells[(x-1)-(n*mNumberOfColumns)].mCelltype==CellType.BLACK){
                            break;
                        }
                        tempVector=m_GridCells[(x-1)-(n*mNumberOfColumns)].transform.position;
                        --n;
                    }
                    DOTween.Sequence().Append(mCricle.transform.DOMoveY(tempVector.y,0.3f));
                    mVectorList.Add(tempVector);
                }
            }
            if(posY<0&&posX==0){
                int n=(int)((m_GridCells[x-1].transform.position.y-mCricle.transform.position.y)/mCricle.transform.localScale.y);
                if(n>0){
                    while(n>=0){
                        if(m_GridCells[(x-1)+((n)*mNumberOfColumns)].mCelltype==CellType.BLACK){
                            break;
                        }
                        tempVector=m_GridCells[(x-1)+((n)*mNumberOfColumns)].transform.position;
                        --n;
                    }
                    DOTween.Sequence().Append(mCricle.transform.DOMoveY(tempVector.y,0.3f));
                    mVectorList.Add(tempVector);
                }
            }
            if(posX>0&&posY==0){
                int n=(int)((mCricle.transform.position.x-m_GridCells[x-1].transform.position.x)/mCricle.transform.localScale.x);
                if(n>0){
                    while(n>=0){
                        if(m_GridCells[(x-1)+(n)].mCelltype==CellType.BLACK){
                            break;
                        }
                        tempVector=m_GridCells[(x-1)+(n)].transform.position;
                        --n;
                    }
                    DOTween.Sequence().Append(mCricle.transform.DOMoveX(tempVector.x,0.3f));
                    mVectorList.Add(tempVector);
                }
            }
            if(posX<0&&posY==0){
                int n=(int)((m_GridCells[x-1].transform.position.x-mCricle.transform.position.x)/mCricle.transform.localScale.x);
                if(n>0){
                    while(n>=0){
                        if(m_GridCells[(x-1)-(n)].mCelltype==CellType.BLACK){
                            break;
                        }
                        tempVector=m_GridCells[(x-1)-(n)].transform.position;
                        --n;
                    }
                    DOTween.Sequence().Append(mCricle.transform.DOMoveX(tempVector.x,0.3f));
                    mVectorList.Add(tempVector);
                }
            }
            if(mCricle.transform.position==mCircleCopy.transform.position)
            {
                mAudioManager.gameObject.SetActive(false);
                mWon.gameObject.SetActive(true);
                mLost.gameObject.SetActive(false);
                mCricle.gameObject.SetActive(false);
                mCircleCopy.gameObject.SetActive(false);
                if (isEnemy)
                {
                    mC1.SetActive(false);
                    mC2.SetActive(false);
                }
                
                for(int i=0;i<m_GridCells.Count;i++)m_GridCells[i].SetColor(Color.black);
                mMute.enabled=false;
                mMute.gameObject.SetActive(false);
                mRestart.enabled=false;
                mRestart.gameObject.SetActive(false);
                mHint.enabled=false;
                mHint.gameObject.SetActive(false);
                mUndo.enabled=false;
                mUndo.gameObject.SetActive(false);
                mHome.DOAnchorPos(Vector2.zero,0.5f);
                mRunningTime.gameObject.SetActive(false);
                mTime.gameObject.SetActive(true);
                mEnemy.gameObject.SetActive(true);
                mClassic.gameObject.SetActive(true);
                isTime=false;
                isEnemy=false;
            }
    }

    private void checkResult()
    {
        if (mCricle.transform.position == mCircleCopy.transform.position)
        {
            mAudioManager.gameObject.SetActive(false);
            mWon.gameObject.SetActive(true);
            mLost.gameObject.SetActive(false);
            mCricle.gameObject.SetActive(false);
            mCircleCopy.gameObject.SetActive(false);
            if (isEnemy)
            {
                mC1.SetActive(false);
                mC2.SetActive(false);
            }
            for (int i = 0; i < m_GridCells.Count; i++) m_GridCells[i].SetColor(Color.black);
            mMute.enabled = false;
            mMute.gameObject.SetActive(false);
            mRestart.enabled = false;
            mRestart.gameObject.SetActive(false);
            mHint.enabled = false;
            mHint.gameObject.SetActive(false);
            mUndo.enabled = false;
            mUndo.gameObject.SetActive(false);
            mHome.DOAnchorPos(Vector2.zero, 0.5f);
            mRunningTime.gameObject.SetActive(false);
            mTime.gameObject.SetActive(true);
            mEnemy.gameObject.SetActive(true);
            mClassic.gameObject.SetActive(true);
            isTime = false;
            isEnemy = false;
        }
    }
    void CreateGrid()
    {
        int rowOffset=1;
        int columnOffset=1;

        GameObject tempGameObject;

        for(int i=0;i<(mNumberOfRows);i++)
        {
            columnOffset=1;
            for(int j=0;j<mNumberOfColumns;j++)
            {
                
                tempGameObject=Instantiate(mPrefab,Vector3.one,Quaternion.identity);;
                Cell cell=tempGameObject.GetComponent<Cell>();
                cell.SetID((mNumberOfColumns * i + j +1));
                m_GridCells.Add(cell);
                tempGameObject.transform.localScale=cellScale;
                tempGameObject.transform.position=new Vector3(-((mCameraAspectRatio*mShapeHeight)/2)+((columnOffset)*(cellScale.x)/2),((mShapeHeight)/2)-((rowOffset)*(cellScale.y)/2),0);
                    
                tempGameObject.GetComponentInChildren<TextMeshPro>().text=(mNumberOfColumns * i + j +1).ToString();
                tempGameObject.GetComponentInChildren<TextMeshPro>().enabled=false;
                if(mMaze[i,j]==1)
                {
                    cell.mCelltype=CellType.BLACK;
                    cell.SetColor(Color.black);
                }
                else
                {
                    cell.mCelltype=CellType.WHITE;
                    cell.SetColor(Color.white);
                }

                columnOffset=columnOffset+2;
            }
            rowOffset=rowOffset+2;
        }
        
    }
    public void restartGame(){
        mCricle.transform.position=m_GridCells[source].transform.position;
        mCricle.SetActive(true);
        mCircleCopy.SetActive(true);
        if (isEnemy)
        {
            mC1.SetActive(true);
            mC2.SetActive(true);
        }
        if (isEnemy)timeStart=30;
        else timeStart=20;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) ) {

            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                hit.collider.GetComponent<Cell>().OnMouseDownTest();
            }
        }
        if(isTime && canStart){
            timeStart-=Time.deltaTime;
            mRunningTime.text="00 : "+Math.Round(timeStart).ToString();
            if(Math.Round(timeStart)==0){
                doneTimeTrial();
            }
        }
        if(isEnemy && canStart)
        {
            timeStart-=Time.deltaTime;
            mRunningTime.text="00 : "+Math.Round(timeStart).ToString();
            if(Math.Round(timeStart)==0){
                doneEnemyHub();
            }
        }
        if(isInstantiated)
        checkResult();
    }

    void doneTimeTrial(){
        mAudioManager.gameObject.SetActive(false);
        mLost.gameObject.SetActive(true);
        mWon.gameObject.SetActive(false);
        mRunningTime.gameObject.SetActive(false);
        for(int i=0;i<m_GridCells.Count;i++)m_GridCells[i].SetColor(Color.black);
        mMute.enabled=false;
        mMute.gameObject.SetActive(false);
        mRestart.enabled=false;
        mRestart.gameObject.SetActive(false);
        mHint.enabled=false;
        mHint.gameObject.SetActive(false);
        mUndo.enabled=false;
        mUndo.gameObject.SetActive(false);
        mHome.DOAnchorPos(Vector2.zero,0.5f);
        mClassic.gameObject.SetActive(true);
        mEnemy.gameObject.SetActive(true);
        mTime.gameObject.SetActive(true);
        mCricle.SetActive(false);
        mCircleCopy.SetActive(false);
        isTime =false;
    }

    void doneEnemyHub(){
        mAudioManager.gameObject.SetActive(false);
        mLost.gameObject.SetActive(true);
        mWon.gameObject.SetActive(false);
        mRunningTime.gameObject.SetActive(false);
        for(int i=0;i<m_GridCells.Count;i++)m_GridCells[i].SetColor(Color.black);
        mMute.enabled=false;
        mMute.gameObject.SetActive(false);
        mRestart.enabled=false;
        mRestart.gameObject.SetActive(false);
        mHint.enabled=false;
        mHint.gameObject.SetActive(false);
        mUndo.enabled=false;
        mUndo.gameObject.SetActive(false);
        mHome.DOAnchorPos(Vector2.zero,0.5f);
        mClassic.gameObject.SetActive(true);
        mEnemy.gameObject.SetActive(true);
        mTime.gameObject.SetActive(true);
        mCricle.SetActive(false);
        mCircleCopy.SetActive(false);
        mC1.SetActive(false);
        mC2.SetActive(false);
        isEnemy =false;
    }
    int findPath(int i,int j){
        if(i==dx&&j==dy){
            path[i,j]=1;
            return 0;
        }
        if(i>=0&&i<20&&j>=0&&j<8){
            if(mMaze[i,j]==0 && path[i,j]==0){
                path[i,j]=1;
                if(findPath(i-1,j)==0)return 0;
			    if(findPath(i,j+1)==0)return 0;
			    if(findPath(i+1,j)==0)return 0;
			    if(findPath(i,j-1)==0)return 0;
                path[i,j]=0;
            }
        }
        return 1;
    }

    void normalColor(){
        for(int i=0;i<path.GetLength(0);i++){
            for(int j=0;j<path.GetLength(1);j++){
                if(path[i,j]==1){
                    int x=(i*mNumberOfColumns)+(j+1);
                    m_GridCells[x-1].SetColor(Color.white);
                    path[i,j]=0;
                }
            }
        }
    }

    public void undoFeature(){
        if(mVectorList.Count>0){
            mVectorList.RemoveAt(mVectorList.Count-1);
            mCricle.transform.position=mVectorList[mVectorList.Count-1];
        }
    }



    public void hintFeature(){
        int n=0;
        for(int i=0;i<m_GridCells.Count;i++){
            if(m_GridCells[i].transform.position==mCricle.transform.position){
                n=i;
                sx=(m_GridCells[i].ID/mNumberOfColumns);
                sy=(m_GridCells[i].ID-(mNumberOfColumns*sx))-1;
                break;
            }
        }
        dx=(destination+1)/mNumberOfColumns;
        dy=((destination+1)-(mNumberOfColumns*dx))-1;
        findPath(sx,sy);
        for(int i=0;i<path.GetLength(0);i++){
            for(int j=0;j<path.GetLength(1);j++){
                if(path[i,j]==1){
                    int x=(i*mNumberOfColumns)+(j+1);
                    m_GridCells[x-1].SetColor(Color.red);
                }
            }
        }
        Invoke("normalColor",1.5f);
    }
}

    