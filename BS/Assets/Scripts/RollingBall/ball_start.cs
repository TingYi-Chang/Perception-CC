using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_start : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public Vector3 myVector;
    public float force_scale ;
    public Camera myCam;
    public UnityEngine.UI.Image Myarrow, ArrPointer;
    Vector2 BallPos;
    RectTransform arrowRB, PointerRB;
    bool dragging;
    float offset_x, offset_y;
    //Random rnd = new Random();
    //public Text text;
    //private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        arrowRB = Myarrow.GetComponent<RectTransform>();
        PointerRB = ArrPointer.GetComponent<RectTransform>();
        dragging = false;
        //count = 0;
        Myarrow.enabled = false;
        ArrPointer.enabled = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && dragging == true)
        {
            dragging = false;
            Myarrow.enabled = false;
            ArrPointer.enabled = false;
            Debug.Log("球被射出 速度 : ");
            myVector = new Vector3(offset_x, 0, offset_y);
            myVector = Vector3.Normalize(myVector);
            float magnitude = Mathf.Sqrt(offset_x * offset_x + offset_y * offset_y);
            rb.AddForce(myVector * force_scale* magnitude);
        }


    }
    void OnMouseDown()
    {
        BallPos = myCam.WorldToScreenPoint(transform.position);
        Debug.Log(transform.position);
        Debug.Log(BallPos);
    }
    void OnMouseDrag()
    {
        dragging = true;
        Myarrow.enabled = true;
        ArrPointer.enabled = true;
        //count tan
        offset_x = BallPos.x - Input.mousePosition.x;
        offset_y = BallPos.y - Input.mousePosition.y;
        float tilt_angle = Mathf.Atan2(offset_y, offset_x) * Mathf.Rad2Deg;
        //arrow
        arrowRB.sizeDelta = new Vector2(Mathf.Sqrt(offset_x * offset_x + offset_y * offset_y), 30);
        
        Myarrow.transform.position = Input.mousePosition + (new Vector3(offset_x / 2, offset_y / 2, 0));

        Myarrow.transform.rotation = Quaternion.Euler(0, 0, tilt_angle);

        //pointer
        PointerRB.sizeDelta = new Vector2(Mathf.Sqrt(offset_x * offset_x + offset_y * offset_y)*2, 5);

        ArrPointer.transform.position = Input.mousePosition + (new Vector3(offset_x * 2, offset_y * 2, 0));

        ArrPointer.transform.rotation = Quaternion.Euler(0, 0, tilt_angle);
    }
}
