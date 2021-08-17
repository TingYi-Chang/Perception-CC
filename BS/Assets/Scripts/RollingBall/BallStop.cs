using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStop : MonoBehaviour
{
    public GameObject Basketball;
    private Rigidbody rb;
    public float StopSpeed, MoveSpeed;
    private Vector3 RestartPos,ParentPos;
    private int MoveFlag;
    public UnityEngine.UI.Image Myarrow;
    ManageViapoint script;
    bool StopFlag;
    float slowtime;
    public bool BoxBall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RestartPos = transform.position;
        MoveFlag = 0;
        script = Basketball.GetComponent<ManageViapoint>();
        StopFlag = false;
        slowtime = Time.time;
        if(BoxBall)
            ParentPos = transform.parent.gameObject.transform.position;
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
                if (script.CheckCondition() == false) //not pass the game
                {
                    reset_ball();
                }
                else // pass the game
                {
                    //transform.position = RestartPos;
                    stop_ball();
                    Debug.Log("end of Game");
                }
            }
        }
        
    }
    public void reset_ball()
    {
        Myarrow.enabled = true;
        if (BoxBall)
            transform.position = RestartPos + transform.parent.gameObject.transform.position - ParentPos;
        else
            transform.position = RestartPos;
        //transform.position = RestartPos + transform.parent.gameObject.transform.position - ParentPos;
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
