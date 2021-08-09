using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStop : MonoBehaviour
{
    private Rigidbody rb;
    public float StopSpeed, MoveSpeed;
    private Vector3 RestartPos;
    private int MoveFlag;
    ManageViapoint script;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RestartPos = transform.position;
        MoveFlag = 0;
        script = this.GetComponent<ManageViapoint>();
        //ScriptName sn = thsi.GetComponent<ManageViapoint>()
        //sn.DoSomething();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= MoveSpeed && MoveFlag ==0)
            MoveFlag = 1;
        if (rb.velocity.magnitude <= StopSpeed && MoveFlag == 1)
        {
            if(script.CheckCondition() == false) //not pass the game
            {
                transform.position = RestartPos;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.velocity = new Vector3(0, 0, 0);
                rb.angularVelocity = new Vector3(0, 0, 0);
                MoveFlag = 0;
            }
            else // pass the game
            {
                //transform.position = RestartPos;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                rb.velocity = new Vector3(0, 0, 0);
                rb.angularVelocity = new Vector3(0, 0, 0);
                MoveFlag = 0;
                Debug.Log("end of Game");
            }

        }
    }
}
