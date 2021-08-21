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


    [HeaderAttribute("Parameter Setting")]
    public int AvailbleTestTimes;
    public int AvailbleTryTimes;
    // Start is called before the first frame update
    void Start()
    {
        ViaPoints = GameObject.FindGameObjectsWithTag("ViaPoint");
        NonViaPoints = GameObject.FindGameObjectsWithTag("NontouchedPoint");
        ShowText = GameObject.Find("FrontText").GetComponent<Text>();
        MovedTime = 0;
        //先把點關掉
        PointsChangeEnable(false);
        pointsActive = false;
        Debug.Log(MovedTime);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PointsChangeEnable(true);
            //ShowText.enabled = false;
            MovedTime = 0;
        }
        //次數顯示和若超過次數...測試
        if(pointsActive == false && AvailbleTestTimes > MovedTime)
        {
            ShowText.text = "Available test times :" + (AvailbleTestTimes - MovedTime);
        }
        else if (pointsActive == false && AvailbleTestTimes <= MovedTime)
        {
            PointsChangeEnable(true);
            //ShowText.enabled = false;
            MovedTime = 0;
        }
        //次數顯示和若超過次數...測試
        if (pointsActive == true)
        {
            ShowText.text = "Available test times :" + (AvailbleTryTimes - MovedTime);
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
}
