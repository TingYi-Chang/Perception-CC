using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class produce_ball : MonoBehaviour
{
    public GameObject Instantiate_Position;
    public GameObject NewBall, MyBall;
    static public List<List<int>> condition;
    static public int RoundCount ;
    void Start()
    {
        
        condition = new List<List<int>>();
        //進球、球、框震動、聲音
        condition.Add(new List<int>() { 2, 1, 1 , 1 });//2打鐵 1空心 3肉包
        condition.Add(new List<int>() { 2, 1, 1, 0 });
        condition.Add(new List<int>() { 2, 1, 0, 1 });
        condition.Add(new List<int>() { 2, 0, 1, 1 });
        condition.Add(new List<int>() { 2, 1, 0, 0 });
        condition.Add(new List<int>() { 2, 0, 1, 0 });
        condition.Add(new List<int>() { 2, 0, 0, 1 });
        condition.Add(new List<int>() { 2, 0, 0, 0 });
        condition.Add(new List<int>() { 1, 1, 0, 0 });
        condition.Add(new List<int>() { 1, 0, 0, 0 });
        condition.Add(new List<int>() { 3, 1, 0, 0 });
        condition.Add(new List<int>() { 3, 0, 0, 0 });
        RoundCount = 0;
        //shuffle
        for (int i = 0; i < condition.Count-1; ++i)
        {
            var r = UnityEngine.Random.Range(i, condition.Count);
            var tmp = condition[i];
            condition[i] = condition[r];
            condition[r] = tmp;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(NewBall, new Vector3(17.04195f, -5.080949f, 3.543301f), Instantiate_Position.transform.rotation);
            //MyBall = GameObject.Find("Baskitball1");
            //Debug.Log(MyBall.name);
            RoundCount += 1;

        }
    }
}
