using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAdjust: MonoBehaviour
{
    MouseLook script; //creates that script data type
    public Vector3 mouseoffset;
    public float myCoor_Z, myCoor_X;
    public Camera myCam;
    private float CameraZDistance;
    // Start is called before the first frame update
    void Start()
    {
        script = this.GetComponent<MouseLook>();
        script.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && script.enabled==true)
        {
            Debug.Log(name.ToString() + "我被點了一");
            script.enabled = false;
            GetComponent<Renderer>().material.color = Color.black;
        }   
    }
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    void OnMouseUp()
    {
        Debug.Log(name.ToString() + "我被點了一下");
        script.enabled = true;
    }
    void OnMouseDown()
    {
        CameraZDistance = myCam.WorldToScreenPoint(transform.position).z;
    }
    void OnMouseExit()
    {
        if(script.enabled == false)
            GetComponent<Renderer>().material.color = Color.black;
    }
    void OnMouseDrag()
    {
        Vector3 ScreenPosition =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
        Vector3 NewWorldPosition =
            myCam.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point

        transform.position = new Vector3(NewWorldPosition.x , -11.5f , NewWorldPosition.z);
        GetComponent<Renderer>().material.color = Color.red;
        script.enabled = false;
    }
}
