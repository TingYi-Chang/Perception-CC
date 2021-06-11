using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class produce_ball : MonoBehaviour
{
    public GameObject Instantiate_Position;
    public GameObject NewBall, MyBall;
    void Start()
    {
        //MyBall =  Instantiate(NewBall, Instantiate_Position.transform.position, Instantiate_Position.transform.rotation) ;
        //MyBall.transform.scale = new Vector3(1, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyBall = Instantiate(NewBall, new Vector3(17.04195f, -5.080949f, 3.543301f), Instantiate_Position.transform.rotation) as GameObject;
            


        }
    }
}
