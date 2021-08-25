using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    float YAngle;

    [HeaderAttribute("Parameter Setting")]
    public bool Gravity;
    public Vector3 FieldDirection;
    public float ForceScale;

    private Rigidbody rb;
    Vector3 NormField;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Gravity)
        {
            YAngle = -1 * transform.localRotation.eulerAngles.y;
            NormField = new Vector3(FieldDirection.x * Mathf.Cos(YAngle / Mathf.Rad2Deg) + FieldDirection.z * Mathf.Cos((YAngle + 90) / Mathf.Rad2Deg)
                , FieldDirection.y, FieldDirection.x * Mathf.Sin(YAngle / Mathf.Rad2Deg) + FieldDirection.z * Mathf.Sin((YAngle + 90) / Mathf.Rad2Deg));
            NormField = NormField.normalized;
        }


    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Basketball" || col.gameObject.tag == "Boxball") //如果aaa碰撞事件的物件名稱是CubeA
        {
            if (Gravity)
            {
                rb = col.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(NormField * ForceScale);
                //Debug.Log(NormField);
            }
                
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Basketball" || col.gameObject.tag == "Boxball") //如果aaa碰撞事件的物件名稱是CubeA
        {
            rb = col.gameObject.GetComponent<Rigidbody>();
            if (!Gravity)
            {
                rb.velocity = rb.velocity * 1.4f;
                Debug.Log("加速");
            }
        }
    }
}
