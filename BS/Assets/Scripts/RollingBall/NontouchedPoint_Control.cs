using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NontouchedPoint_Control : MonoBehaviour
{
    public GameObject Basketball;
    ManageViapoint script_point;
    BallStop script_ball;
    // Start is called before the first frame update
    void Start()
    {
        script_point = Basketball.GetComponent<ManageViapoint>();
        script_ball = Basketball.GetComponent<BallStop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "BasketBall") //如果aaa碰撞事件的物件名稱是CubeA
        {
            print("碰到禁區"); //在除錯視窗中顯示OK
            script_ball.reset_ball();
            script_point.reset_color();
        }
    }
}
