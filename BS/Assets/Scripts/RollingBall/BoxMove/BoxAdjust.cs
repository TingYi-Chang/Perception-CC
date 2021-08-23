using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAdjust: MonoBehaviour
{
    MouseLook script; //creates that script data type
    public Camera myCam;
    Color originalcolor;
    public bool beenmoved;
    private Vector3 OriginPos;
    private float OriginAngle;
    public int MovedTimes;
    TestBoxPhase MovePhaseScript;

    [HeaderAttribute("Parameter Setting")]
    public bool CanMove;
    public bool CanRotate;
    public bool dsetting;
    public float Resolution;
    public float LastClickTime;


    private float CameraZDistance;
    // Start is called before the first frame update
    void Start()
    {
        script = this.GetComponent<MouseLook>();
        script.enabled = false;
        originalcolor = GetComponent<Renderer>().material.color;
        beenmoved = false;
        OriginPos = transform.position;
        OriginAngle = transform.localRotation.eulerAngles.y;
        MovePhaseScript = GameObject.Find("Court").GetComponent<TestBoxPhase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && script.enabled==true)
        {
            Debug.Log(name.ToString() + "結束旋轉");
            script.enabled = false;
            GetComponent<Renderer>().material.color = originalcolor;
            LastClickTime = Time.time;
            //MovePhaseScript.MovedTime += 1;
        }

    }
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    void OnMouseUp()
    {
        Debug.Log(name.ToString() + "左鍵起來");
        
        if (dsetting && CanMove)//鎖點
        {
            transform.position = new Vector3(transform.position.x - transform.position.x % Resolution,
                transform.position.y - transform.position.y % Resolution,
                transform.position.z -transform.position.z % Resolution);
        }
        //MovePhaseScript.MovedTime += 1;
    }
    void OnMouseDown()
    {
        CameraZDistance = myCam.WorldToScreenPoint(transform.position).z;
    }
    void OnMouseExit()
    {
        if(script.enabled == false)
            GetComponent<Renderer>().material.color = originalcolor;
    }
    void OnMouseDrag()
    {
        if (CanMove)
        {
            Vector3 ScreenPosition =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
            Vector3 NewWorldPosition =
                myCam.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point

            transform.position = new Vector3(NewWorldPosition.x, -11.5f, NewWorldPosition.z);
            GetComponent<Renderer>().material.color = Color.red;
            BeenMoved();
        }
        
    }
    void OnMouseOver()
    {
        if (CanRotate && Input.GetMouseButtonUp(1) && script.enabled == false && Time.time - LastClickTime > 0.1)
        {
            Debug.Log(name.ToString() + "可旋轉");
            script.enabled = true;
            BeenMoved();
        }

    }
    public void ResetPos()
    {
        transform.position = OriginPos ;
        transform.rotation = Quaternion.Euler(0, OriginAngle , 0);
    }
    void BeenMoved()
    {
        if (!beenmoved)
        {
            beenmoved = true;
        }
    }
}
