using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConstantStart : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private Vector3 myVector,OriginPos;
    private Collider BallCollider;
    

    public Camera myCam;
    public UnityEngine.UI.Image Myarrow, ArrPointer;
    Vector2 BallPos;
    RectTransform arrowRB, PointerRB;
    ManageViapoint script;
    TestBoxPhase MovePhaseScript;

    [HeaderAttribute("Parameter Setting")]
    public float Angle;
    public float ForceScale;
    //Random rnd = new Random();
    //public Text text;
    //private int count;
    private Collider[] BoxBallColliders;
    public GameObject[] AllBoxBalls;
    public Rigidbody[] boxball_rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        OriginPos = transform.position;
        arrowRB = Myarrow.GetComponent<RectTransform>();
            PointerRB = ArrPointer.GetComponent<RectTransform>();
            script = this.GetComponent<ManageViapoint>();
            //canvas;
            Myarrow.enabled = true;
            ArrPointer.enabled = false;

            //set rolling angle
            myVector = new Vector3(Mathf.Cos(Angle / Mathf.Rad2Deg), 0, Mathf.Sin(Angle / Mathf.Rad2Deg));
            myVector = Vector3.Normalize(myVector);
            //rb.AddForce(myVector * force_scale);

            //set arrow
            BallPos = myCam.WorldToScreenPoint(transform.position);
            //float tilt_angle = Mathf.Atan2(offset_y, offset_x) * Mathf.Rad2Deg;

            Myarrow.transform.position = (new Vector3(BallPos.x - 75 * Mathf.Cos(Angle / Mathf.Rad2Deg), BallPos.y - 75 * Mathf.Sin(Angle / Mathf.Rad2Deg), 0));

            Myarrow.transform.rotation = Quaternion.Euler(0, 0, Angle);
        //test phase
        MovePhaseScript = GameObject.Find("Court").GetComponent<TestBoxPhase>();

        //prevent the bug before shooting the ball
        BallCollider = GameObject.Find("BasketBall").GetComponent<Collider>();

        AllBoxBalls = GameObject.FindGameObjectsWithTag("Boxball");
        boxball_rb = new Rigidbody[AllBoxBalls.Length];
        BoxBallColliders = new Collider[AllBoxBalls.Length];
        for (int i = 0 ; i < boxball_rb.Length; ++i)
        {
            boxball_rb[i] = AllBoxBalls[i].GetComponent<Rigidbody>();
            BoxBallColliders[i] = AllBoxBalls[i].GetComponent<Collider>();
        }
        ChangeBallColliderEnable(false);
        //BallCollider.attachedRigidbody.useGravity = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude <= 2)
        {
            ChangeBallColliderEnable(true);
            Myarrow.enabled = false;
            rb.AddForce(myVector * ForceScale);
            Debug.Log("球被射出 速度 : ");
            MovePhaseScript.MovedTime += 1;
            
        }
        if (Input.GetKeyDown(KeyCode.R) )
        {
            script.reset_color();
            Myarrow.enabled = true;
            transform.position = OriginPos;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
            ChangeBallColliderEnable(false);
        }


    }
    public void ChangeBallColliderEnable(bool towhat)
    {
        BallCollider.enabled = towhat;
        rb.useGravity = towhat;
        for (int i = 0; i < boxball_rb.Length; ++i)
        {
            boxball_rb[i].useGravity = towhat;
            BoxBallColliders[i].enabled = towhat;
        }
    }
    
}
