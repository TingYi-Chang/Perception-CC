using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NontouchedPoint_Control : MonoBehaviour
{
    private GameObject Basketball;
    ManageViapoint script_point;
    private BallManage ballManage;
    //private MySceneManager script_scenemanager;

    public UnityEngine.UI.Image Myarrow;
    // Start is called before the first frame update
    void Start()
    {
        Basketball = GameObject.Find("BasketBall");
        script_point = Basketball.GetComponent<ManageViapoint>();
        ballManage = GameObject.Find("Court").GetComponent<BallManage>();
        //script_scenemanager = GameObject.Find("MySceneManager").GetComponent<MySceneManager>();
        /*AllBalls = GameObject.FindGameObjectsWithTag("Boxball");
        script_boxball = new BallStop[AllBalls.Length];
        Debug.Log("總共有" + AllBalls.Length + "顆球");
        for (int i = 0; i < AllBalls.Length; ++i)
        {
            script_boxball[i] = AllBalls[i].GetComponent<BoxBallStop>();
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Basketball" || col.gameObject.tag == "Boxball") //如果aaa碰撞事件的物件名稱是CubeA
        {
            print("碰到禁區"); //在除錯視窗中顯示OK
            if(true)//script_scenemanager.PassGame == false
            {
                ballManage.ResetAllBall();
                script_point.reset_color();
                Myarrow.enabled = true;
            }
            
        }
    }
}
