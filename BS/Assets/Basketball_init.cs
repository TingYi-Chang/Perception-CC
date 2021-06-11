using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball_init : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 myVector;
    public float m_Speed = 100.0f;
    int count = 0;
    //public Text text;
    //private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //count = 0;

    }
    void FixedUpdate()
    {
        if (count == 0) {
            myVector = Vector3.Normalize(myVector);
        //text.text = "質量:" + rb.mass + " 施力次數:" + count.ToString();
            rb.AddForce(myVector * m_Speed);
            count = 1;
        }
    }
}
