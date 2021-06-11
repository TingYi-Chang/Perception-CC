using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBall : MonoBehaviour
{
    private Rigidbody rb;
    public Renderer ballrend;
    public Renderer[] linerend;
    public int goal;
    public Vector3 myVector;
    public float m_Speed = 1075.0f;
    public int count = 0;
    float timer;
    //Random rnd = new Random();
    //public Text text;
    //private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        //count = 0;
        ballrend = GetComponent<Renderer>();
        ballrend.enabled = true;
        linerend = GetComponentsInChildren<Renderer>();
        Debug.Log(linerend);
    }
    void FixedUpdate()
    {
        if(count == 0)//準備投球
        {
            if (Input.GetKeyDown(KeyCode.W))//進球
            {
                rb.useGravity = true;
                myVector = new Vector3(-0.6f, 1.5f, 0);
                myVector = Vector3.Normalize(myVector);
                rb.AddForce(myVector * m_Speed);
                count = 1;
                timer = 0;
            }
            if (Input.GetKeyDown(KeyCode.E))//打鐵
            {
                rb.useGravity = true;
                myVector = new Vector3(-0.6f + Random.Range( 0, 0.2f), 1.5f + Random.Range(-0.3f, 0.3f), Random.Range(-0.05f, 0.05f));
                m_Speed += Random.Range(30, 70.0f);
                myVector = Vector3.Normalize(myVector);
                rb.AddForce(myVector * m_Speed);
                count = 1;
                timer = 0;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                rb.useGravity = true;
                myVector = new Vector3(-0.6f, 1.5f, Random.Range(-0.2f, 0.2f));
                m_Speed = 950.0f;

                myVector = Vector3.Normalize(myVector);
                rb.AddForce(myVector * m_Speed);
                count = 1;
                timer = 0;
            }

        }
        else if(count==1)//飛行途中要看不到
        {
            timer += Time.deltaTime;
            if (timer > 0.8f)
            {
                ballrend.enabled = false;
                if (linerend != null)
                {
                    foreach (Renderer line in linerend)
                        line.enabled = false;
                }
                count = 2;
            }
            
        }
        else if (count == 3)
        {
            timer += Time.deltaTime;
            if (timer > 0.6f)
            {
                ballrend.enabled = true;
                if (linerend != null)
                {
                    foreach (Renderer line in linerend)
                        line.enabled = true;
                }

            }
        }

    }
    void OnCollisionEnter(Collision touch) //aaa為自定義碰撞事件
    {
        if (count == 2)
        {
            count = 3;
            timer = 0;
        }
        
    }
}

