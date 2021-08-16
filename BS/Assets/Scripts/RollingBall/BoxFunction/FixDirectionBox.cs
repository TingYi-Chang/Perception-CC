using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixDirectionBox : MonoBehaviour
{
    public GameObject Basketball;
    float YAngle;
    private Rigidbody rb;
    Vector3 NormVector;
    float Mag;

    [HeaderAttribute("Parameter Setting")]
    public bool ChangeWithRotation;
    public Vector3 FieldDirection;
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
        if (col.gameObject.name == "BasketBall") //如果aaa碰撞事件的物件名稱是CubeA
        {
            NormVector = FieldDirection.normalized;
            if (ChangeWithRotation)
            {
                YAngle = -1 * transform.localRotation.eulerAngles.y;
                NormVector = new Vector3(FieldDirection.x * Mathf.Cos(YAngle / Mathf.Rad2Deg) + FieldDirection.z * Mathf.Cos((YAngle + 90) / Mathf.Rad2Deg)
                    , FieldDirection.y, FieldDirection.x * Mathf.Sin(YAngle / Mathf.Rad2Deg) + FieldDirection.z * Mathf.Sin((YAngle + 90) / Mathf.Rad2Deg));
                NormVector = NormVector.normalized;
            }
            Mag = rb.velocity.magnitude;
            Basketball.transform.position = new Vector3(transform.position.x, Basketball.transform.position.y, transform.position.z);
            rb.velocity = NormVector * Mag;
            Debug.Log("固定方向飛出");
            
        }
    }
}
