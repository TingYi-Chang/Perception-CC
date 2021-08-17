using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBall : MonoBehaviour
{
    float YAngle;

    [HeaderAttribute("Parameter Setting")]
    public bool ChangeWithRotation;
    public Vector3 FieldDirection;
    public float ForceScale;
    public float LastingTime;

    private Rigidbody rb;
    private Vector3 NormVector;
    bool ActiveFlag;
    float activetime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveFlag)
        {
            if (Time.time - activetime <= LastingTime)
                rb.AddForce(NormVector * ForceScale);
            else
                ActiveFlag = false;
        }


    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Basketball" || col.gameObject.tag == "Boxball") //如果aaa碰撞事件的物件名稱是CubeA
        {
            rb = col.gameObject.GetComponent<Rigidbody>();
            ActiveFlag = true;
            activetime = Time.time;
            NormVector = FieldDirection.normalized;
            if (ChangeWithRotation)
            {
                YAngle = -1 * transform.localRotation.eulerAngles.y;
                NormVector = new Vector3(FieldDirection.x * Mathf.Cos(YAngle / Mathf.Rad2Deg) + FieldDirection.z * Mathf.Cos((YAngle + 90) / Mathf.Rad2Deg)
                    , FieldDirection.y, FieldDirection.x * Mathf.Sin(YAngle / Mathf.Rad2Deg) + FieldDirection.z * Mathf.Sin((YAngle + 90) / Mathf.Rad2Deg));
                NormVector = NormVector.normalized;
            }
        }
    }

}
