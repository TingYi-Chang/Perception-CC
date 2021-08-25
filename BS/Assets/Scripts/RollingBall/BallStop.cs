using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStop : MonoBehaviour
{//Script on BasketBall
    private Rigidbody rb;
    public float StopSpeed, MoveSpeed;
    private Vector3 RestartPos,ParentPos;
    private int MoveFlag;
    public UnityEngine.UI.Image Myarrow;
    bool StopFlag;
    float slowtime;
    private BallManage ballManage;
    private BallConstantStart script_ballstart;

    // Start is called before the first frame update
    void Start()
    {
        ballManage = GameObject.Find("Court").GetComponent<BallManage>();
        script_ballstart = GameObject.Find("BasketBall").GetComponent<BallConstantStart>();

        rb = GetComponent<Rigidbody>();
        RestartPos = transform.position;
        MoveFlag = 0;
        StopFlag = false;
        slowtime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= MoveSpeed && MoveFlag == 0)
        {
            MoveFlag = 1;
        }
        //重製stopflag 假的停
        if (rb.velocity.magnitude >= MoveSpeed && StopFlag == true)
            StopFlag = false;
            
        if (rb.velocity.magnitude <= StopSpeed && MoveFlag == 1)
        {
            if ( StopFlag == false)//開始減速
            {
                slowtime = Time.time;
                StopFlag = true;
            }
            else if (Time.time - slowtime > 1.0f)//真的停下來
            {
                StopFlag = false;
                stop_ball();
                ballManage.CheckAllBallStop();
            }
        }
        
    }
    public void reset_ball()
    {
        Myarrow.enabled = true;
        transform.position = RestartPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
        MoveFlag = 0;
        //script_ballstart.ChangeBallColliderEnable(false);
    }
    public void stop_ball()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
        MoveFlag = 0;
    }
}
