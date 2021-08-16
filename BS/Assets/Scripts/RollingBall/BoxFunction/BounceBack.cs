using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    public GameObject Basketball;
    private Rigidbody rb;

    [HeaderAttribute("Parameter Setting")]
    public bool SpeedUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = Basketball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "BasketBall") //如果aaa碰撞事件的物件名稱是CubeA
        {
            rb.velocity = -1*rb.velocity;
            Debug.Log("回彈");

        }
    }
}
