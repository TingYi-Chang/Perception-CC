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
    public float m_Speed = 2600.0f;
    public int count = 0,round;
    float timer;
    public List<int> mycondition;
    //Random rnd = new Random();
    //public Text text;
    //private int count;
    void Start()
    {
        round = produce_ball.RoundCount;
        if(round < produce_ball.condition.Count)
        {
            mycondition = produce_ball.condition[round];
        }
        else
        {
            mycondition = produce_ball.condition[0];
        }
        Debug.Log(mycondition[0]);
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        //count = 0;
        ballrend = GetComponent<Renderer>();
        ballrend.enabled = true;
        linerend = GetComponentsInChildren<Renderer>();
        //Debug.Log(linerend);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
            Debug.Log("destroy");
        }
        if (Input.GetKeyDown(KeyCode.A))//投球
        {
            if (mycondition[0]==1)//進球
            {
                rb.useGravity = true;
                myVector = new Vector3(-0.6f, 2.0f, Random.Range(-0.02f, 0.02f));
                myVector = Vector3.Normalize(myVector);
                m_Speed = 2600.0f;
                rb.AddForce(myVector * m_Speed);
                count = 1;
                timer = 0;
            }
            if (mycondition[0]==2)//打鐵
            {
                rb.useGravity = true;
                float ZShift = (float)(((Random.Range(0, 2) == 1)) ? Random.Range(0.03f, 0.05f) : Random.Range(-0.05f, -0.03f));
                myVector = new Vector3(-0.6f + Random.Range( 0, 0.2f), 1.5f + Random.Range(-0.3f, 0.3f), ZShift);
                m_Speed = 2600.0f;
                //m_Speed += Random.Range(30, 50.0f);
                myVector = Vector3.Normalize(myVector);
                rb.AddForce(myVector * m_Speed);
                count = 1;
                timer = 0;
            }
            if (mycondition[0]==3)
            {
                rb.useGravity = true;
                myVector = new Vector3(-0.6f, 1.5f, Random.Range(-0.2f, 0.2f));
                m_Speed = 2200.0f;

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
                if (mycondition[1] == 0)
                {
                    ballrend.enabled = false;
                    if (linerend != null)
                    {
                        foreach (Renderer line in linerend)
                            line.enabled = false;
                    }
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
                count = 4;
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

