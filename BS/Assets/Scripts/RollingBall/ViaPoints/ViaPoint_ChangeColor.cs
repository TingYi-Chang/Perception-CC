using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViaPoint_ChangeColor : MonoBehaviour
{
    public Material UntouchedMaterial;
    public Material TouchedMaterial;
    static public bool TouchCondition;
    ManageViapoint Script_manage_point;
    // Start is called before the first frame update
    void Start()
    {
        Script_manage_point = GameObject.Find("BasketBall").GetComponent<ManageViapoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.tag == "Basketball" || col.gameObject.tag == "Boxball") //如果aaa碰撞事件的物件名稱是CubeA
        {
            print("碰到中繼點"); //在除錯視窗中顯示OK
            ChangeToTouchColor();
        }
    }
    public void ChangeToTouchColor()
    {
        this.GetComponent<MeshRenderer>().material = TouchedMaterial;
        Script_manage_point.CheckCondition();
    }
    public void ChangeToUntouchColor()
    {
        this.GetComponent<MeshRenderer>().material = UntouchedMaterial;
    }

}
