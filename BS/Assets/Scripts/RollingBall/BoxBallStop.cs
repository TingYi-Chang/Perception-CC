using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBallStop : MonoBehaviour
{
    private GameObject Basketball;
    private Rigidbody rb;
    private float Stopspeed, Movespeed;

    private BallStop basketball_script;
    private BallManage ballManage;

    private Vector3 RestartPos, ParentPos;
    private int MoveFlag;

    bool StopFlag;
    float slowtime;

    // Start is called before the first frame update
    void Start()
    {
        Basketball = GameObject.Find("BasketBall");
        basketball_script = Basketball.GetComponent<BallStop>();
        Stopspeed = basketball_script.StopSpeed;
        Movespeed = basketball_script.MoveSpeed;

        ballManage = GameObject.Find("Court").GetComponent<BallManage>();

        rb = GetComponent<Rigidbody>();
        RestartPos = transform.position;
        MoveFlag = 0;
        StopFlag = false;
        slowtime = Time.time;

        ParentPos = transform.parent.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= Movespeed && MoveFlag == 0)
        {
            MoveFlag = 1;
        }
        //重製stopflag 假的停
        if (rb.velocity.magnitude >= Movespeed && StopFlag == true)
            StopFlag = false;

        if (rb.velocity.magnitude <= Stopspeed && MoveFlag == 1)
        {
            StopFlag = false;
            stop_ball();
            ballManage.CheckAllBallStop();
        }

    }
    public void reset_ball()
    {
        transform.position = RestartPos + transform.parent.gameObject.transform.position - ParentPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
        MoveFlag = 0;
    }
    public void stop_ball()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
        MoveFlag = 0;
    }
}
