using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NontouchedPoint_Control : MonoBehaviour
{
    public GameObject Basketball;
    ManageViapoint script_point;

    public GameObject[] AllBalls;
    public BallStop[] script_ball;
    public UnityEngine.UI.Image Myarrow;
    // Start is called before the first frame update
    void Start()
    {
        script_point = Basketball.GetComponent<ManageViapoint>();

        AllBalls = GameObject.FindGameObjectsWithTag("Basketball");
        script_ball = new BallStop[AllBalls.Length];
        Debug.Log("總共有" + AllBalls.Length + "顆球");
        for (int i = 0; i < AllBalls.Length; ++i)
        {
            script_ball[i] = AllBalls[i].GetComponent<BallStop>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Basketball") //如果aaa碰撞事件的物件名稱是CubeA
        {
            print("碰到禁區"); //在除錯視窗中顯示OK
            for (int i = 0; i < AllBalls.Length; ++i)
            {
                script_ball[i].reset_ball();
            }
            //script_ball.reset_ball();
            script_point.reset_color();
            Myarrow.enabled = true;
        }
    }
}
