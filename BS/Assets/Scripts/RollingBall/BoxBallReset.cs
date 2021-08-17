using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBallReset : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 OriginPos,ParentOriginPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        OriginPos = transform.position;
        ParentOriginPos = transform.parent.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = OriginPos + transform.parent.gameObject.transform.position - ParentOriginPos;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
