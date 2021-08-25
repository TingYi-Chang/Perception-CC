using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageViapoint : MonoBehaviour
{
    private GameObject[] ViaPoints;
    public Material UntouchedMaterial;
    public Material TouchedMaterial;
    private BallConstantStart ballstart_script;
    private MySceneManager script_scenemanager;
    private RawImage MenuImage;

    // Start is called before the first frame update
    void Start()
    {
        //if (ViaPoints == null)
        ViaPoints = GameObject.FindGameObjectsWithTag("ViaPoint");

        Debug.Log("總共有" + ViaPoints.Length + "個中繼點");
        ballstart_script = GameObject.Find("BasketBall").GetComponent<BallConstantStart>();

        script_scenemanager = GameObject.Find("MySceneManager").GetComponent<MySceneManager>();

        MenuImage = GameObject.Find("Menu").GetComponent<RawImage>();
        MenuImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CheckCondition()
    {
        Debug.Log("檢查中繼點");
        if (script_scenemanager.PassGame == true)
            return true;

        for (int i = 0; i < ViaPoints.Length; i++)
        {
            //Debug.Log(i + " point = " + ViaPoints[i].GetComponent<MeshRenderer>().sharedMaterial);
            if (ViaPoints[i].GetComponent<MeshRenderer>().sharedMaterial == UntouchedMaterial)
            {
                
                Debug.Log("檢查回傳 false");
                return false;
            }
        }
        Debug.Log("檢查回傳true");
        script_scenemanager.PassGame = true;
        //show the menu
        Time.timeScale = 0;
        MenuImage.enabled = true;
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
    public void CloseMenu()
    {
        MenuImage.enabled = false;
    }
    
}
