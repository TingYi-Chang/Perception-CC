using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageViapoint : MonoBehaviour
{
    public GameObject[] ViaPoints;
    public Material UntouchedMaterial;
    public Material TouchedMaterial;
    private BallConstantStart ballstart_script;
    // Start is called before the first frame update
    void Start()
    {
        //if (ViaPoints == null)
        ViaPoints = GameObject.FindGameObjectsWithTag("ViaPoint");

        Debug.Log("總共有" + ViaPoints.Length + "個中繼點");
        ballstart_script = GameObject.Find("BasketBall").GetComponent<BallConstantStart>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CheckCondition()
    {
        Debug.Log("檢查中繼點");
        
        for (int i = 0; i < ViaPoints.Length; i++)
        {
            //Debug.Log(i + " point = " + ViaPoints[i].GetComponent<MeshRenderer>().sharedMaterial);
            if (ViaPoints[i].GetComponent<MeshRenderer>().sharedMaterial == UntouchedMaterial)
            {
                reset_color();
                Debug.Log("檢查回傳 false");
                return false;
            }
        }
        Debug.Log("檢查回傳true");
        return true;
    }
    public void reset_color()
    {
        for (int i = 0; i < ViaPoints.Length; ++i)
        {
            ViaPoints[i].GetComponent<MeshRenderer>().material = UntouchedMaterial;
        }
        ballstart_script.ChangeBallColliderEnable(false);


    }
}
