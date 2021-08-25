using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBoxPhase : MonoBehaviour
{
    private GameObject[] ViaPoints;
    private GameObject[] NonViaPoints;
    private Text ShowText;
    private bool pointsActive;
    public int MovedTime;
    private int RemainMin, RemainSec, RemainingTime;
    private MySceneManager script_scenemanager;



    [HeaderAttribute("Parameter Setting")]
    public bool HaveTestPhase;
    public int AvailbleTestTimes;
    public int AvailbleTryTimes;
    public int TestingTime, PlayingTime;
    // Start is called before the first frame update
    void Start()
    {
        ViaPoints = GameObject.FindGameObjectsWithTag("ViaPoint");
        NonViaPoints = GameObject.FindGameObjectsWithTag("NontouchedPoint");
        ShowText = GameObject.Find("FrontText").GetComponent<Text>();
        MovedTime = 0;
        //先把點關掉
        if (HaveTestPhase)
        {
            PointsChangeEnable(false);
            pointsActive = false;
            Debug.Log(MovedTime);
            RemainingTime = TestingTime;
        }
        else
        {
            RemainingTime = PlayingTime;
            pointsActive = true;
        }
        InvokeRepeating("timer", 1, 1);

        script_scenemanager = GameObject.Find("MySceneManager").GetComponent<MySceneManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!script_scenemanager.PassGame)
        {
            if (Input.GetKeyDown(KeyCode.Return) && HaveTestPhase && pointsActive==false)//pass test phase
            {
                PointsChangeEnable(true);
                //ShowText.enabled = false;
                MovedTime = 0;
                RemainingTime = PlayingTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))//to next scene
            {
                
                script_scenemanager.LoadNextScene();
            }
        }
        //次數顯示和若超過次數...測試
        
        if (pointsActive == false )
        {
            if(AvailbleTestTimes > MovedTime)
            {
                if (RemainingTime % 60 >= 10)
                    ShowText.text = "Available test times : " + (AvailbleTestTimes - MovedTime) + "\n" + "Remaining Time " + RemainingTime / 60 + ":" + RemainingTime % 60;
                else
                    ShowText.text = "Available test times : " + (AvailbleTestTimes - MovedTime) + "\n" + "Remaining Time " + RemainingTime / 60 + ":0" + RemainingTime % 60;
            }
            else if ( AvailbleTestTimes <= MovedTime)
            {
                PointsChangeEnable(true);
                //ShowText.enabled = false;
                MovedTime = 0;
                RemainingTime = PlayingTime;
            }
            if(RemainingTime <=0)
            {
                PointsChangeEnable(true);
                MovedTime = 0;
                RemainingTime = PlayingTime;
            }
        }
        
        //遊玩階段
        if (pointsActive == true)
        {
            if (RemainingTime <= 0)
            {

            }
            if (RemainingTime % 60 >= 10)
                ShowText.text = "Remaining Time " + RemainingTime / 60 + ":" + RemainingTime % 60;
            else
                ShowText.text = "Remaining Time " + RemainingTime / 60 + ":0" + RemainingTime % 60;
        }

    }
    void PointsChangeEnable(bool ToWhat)
    {
        foreach (GameObject point in ViaPoints)
        {
            point.SetActive(ToWhat);
        }
        foreach (GameObject point in NonViaPoints)
        {
            point.SetActive(ToWhat);
        }
        pointsActive = ToWhat;
    }
    void timer()
    {    //自訂一個函式叫做timer。

        RemainingTime -= 1;
        if (RemainingTime < 0)
        {
            CancelInvoke("timer");
            ShowText.text = "Times UP";
        }
    }
}
