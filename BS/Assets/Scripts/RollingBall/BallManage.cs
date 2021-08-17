using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManage : MonoBehaviour
{
    private GameObject Basketball;
    ManageViapoint script_point;
    private BallStop script_ball;

    private GameObject[] AllBoxBalls;
    private BoxBallStop[] script_boxball;

    private Rigidbody[] all_rb;
    // Start is called before the first frame update
    void Start()
    {
        Basketball = GameObject.Find("BasketBall");
        script_ball = Basketball.GetComponent<BallStop>();
        script_point = Basketball.GetComponent<ManageViapoint>();

        AllBoxBalls = GameObject.FindGameObjectsWithTag("Boxball");
        script_boxball = new BoxBallStop[AllBoxBalls.Length];
        for (int i = 0; i < AllBoxBalls.Length; ++i)
        {
            script_boxball[i] = AllBoxBalls[i].GetComponent<BoxBallStop>();
        }

        all_rb = new Rigidbody[AllBoxBalls.Length + 1];
        all_rb[0] = Basketball.GetComponent<Rigidbody>();
        for (int i = 1; i < all_rb.Length; ++i)
        {
            all_rb[i] = AllBoxBalls[i-1].GetComponent<Rigidbody>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckAllBallStop()
    {
        Debug.Log("檢查是否過關");
        for (int i = 0; i < all_rb.Length; ++i)
        {//如果有還在動的就跳開
            if (all_rb[i].velocity.magnitude > 4.0f)
                return;
        }
        //都停下來的話 就檢查結束沒
        if (!script_point.CheckCondition())//失敗
        {
            ResetAllBall();
            Debug.Log("失敗重來");
        }
        else//成功
        {
            //**************
            //add pass scene here
            //**************
            ResetAllBall();
        }
    }
    public void ResetAllBall()
    {
        script_ball.reset_ball();
        for (int i = 0; i < AllBoxBalls.Length; ++i)
        {
            script_boxball[i].reset_ball();
        }
    }
}
