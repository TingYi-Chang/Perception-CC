using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketball_init : MonoBehaviour
{
    private Rigidbody rb;
    public int goal;
    public Vector3 myVector;
    public float m_Speed = 1080.0f;
    int count = 0;
    //Random rnd = new Random();
    //public Text text;
    //private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //count = 0;

    }
    void FixedUpdate()
    {
        if (count == 0)
        {
            if (goal == 2)//打鐵
            {
                myVector = new Vector3(-0.6f, 1.5f, Random.Range(-0.05f, 0.05f));
                m_Speed += Random.Range(30, 70.0f);
            }
            else if (goal == 3)//肉包
            {
                myVector = new Vector3(-0.6f, 1.5f, Random.Range(-0.2f, 0.2f));
                m_Speed = 950.0f;
            }
            else//goal==1 進球
            {
                myVector = new Vector3(-0.6f, 1.5f, 0);
            }
            myVector = Vector3.Normalize(myVector);
            rb.AddForce(myVector * m_Speed);
            count = 1;
        }
    }
}