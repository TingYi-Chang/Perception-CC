using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refraction : MonoBehaviour
{
    float InAngle, OutAngle;
    public GameObject Basketball;
    private Rigidbody rb;

    [HeaderAttribute("Parameter Setting")]
    public float index;


    // Start is called before the first frame update
    void Start()
    {
        rb = Basketball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        /*if (col.gameObject.name == "BasketBall") //如果aaa碰撞事件的物件名稱是CubeA
        {
            float Vx, Vz, theta_ball, theta_box, Sine1,Sine2;
            Vx = transform.velocity.x;
            Vz = transform.velocity.z;
            theta_ball = Mathf.Atan2(Vx, Vz);
            theta_box = transform.localRotation.eulerAngles.y;
        }*/
    }
}
