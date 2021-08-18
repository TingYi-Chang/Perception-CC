using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedNunControl : MonoBehaviour
{
    private GameObject[] Boxs;
    private BoxAdjust[] BoxScripts;
    private bool Locked;
    BallManage ballManage;
    ManageViapoint viapointManage;

    [HeaderAttribute("Parameter Setting")]
    public int BoxesAbleToMove;
    // Start is called before the first frame update
    void Start()
    {
        Boxs = GameObject.FindGameObjectsWithTag("Box");
        BoxScripts = new BoxAdjust[Boxs.Length];
        for (int i = 0; i < Boxs.Length; i++)
        {
            BoxScripts[i] = Boxs[i].GetComponent<BoxAdjust>();
        }
        Locked = false;
        ballManage = GameObject.Find("Court").GetComponent<BallManage>();
        viapointManage = GameObject.Find("BasketBall").GetComponent<ManageViapoint>();

    }

    // Update is called once per frame
    void Update()
    {
        Checkboxes();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetAllBoxes();
            ballManage.ResetAllBall();
            viapointManage.reset_color();
        }
    }
    public void Checkboxes()
    {
        int count = 0;
        for (int i = 0; i < Boxs.Length; i++)
        {
            if (BoxScripts[i].beenmoved == true)
                count += 1;
        }
        if (count >= BoxesAbleToMove)
        {
            if(!Locked)
                LockOtherBoxes();
        }
    }
    void LockOtherBoxes()
    {
        for (int i = 0; i < Boxs.Length; i++)
        {
            if(BoxScripts[i].beenmoved == false)
            {
                BoxScripts[i].CanMove = false;
                BoxScripts[i].CanRotate = false;
            }
        }
        Locked = true;
        Debug.Log("鎖住其他箱子");
    }
    public void ResetAllBoxes()
    {
        for (int i = 0; i < Boxs.Length; i++)
        {
            BoxScripts[i].CanMove = true;
            BoxScripts[i].CanRotate = true;
            BoxScripts[i].beenmoved = false;
            BoxScripts[i].ResetPos();
        }
        Locked = false;
    }

}
