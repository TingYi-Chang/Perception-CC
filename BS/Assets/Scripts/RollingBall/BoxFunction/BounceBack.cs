using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    private Rigidbody rb;

    [HeaderAttribute("Parameter Setting")]
    public bool SpeedUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Basketball" || col.gameObject.tag == "Boxball") //如果aaa碰撞事件的物件名稱是CubeA
        {
            rb = col.gameObject.GetComponent<Rigidbody>();
            rb.velocity = -1*rb.velocity;
            if(SpeedUp)
                rb.velocity *=1.5f;
            Debug.Log("回彈");

        }
    }
}
