using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public bool PassGame;
    public bool HaveTsetPhase;
    public int Sequence1, Sequence2, Sequence3;
    /*void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }*/
    void Start()
    {
        // 0-->tutoria black 
        //1~3 test black 
        //4~6 play black
        //7 -->tutorial white
        //8~10 play white
        if (SceneManager.GetActiveScene().buildIndex == 0)//如果是從tutorail black 開始
        {
            Debug.Log("從black box 教學開始");
            OrderBlackScenes(HaveTsetPhase);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)//如果是從tutorail white 開始
        {
            Debug.Log("從white box 教學開始");

        }
        else if(GameData.SceneCount == 0)//如果是開始的scene 避免不是從tutorial 開始
        {
            Debug.Log("起始scene");
            for (int i = 0; i < GameData.SceneOrder.Length; i++)//不會跳到下一關
            {
                GameData.SceneOrder[i] = SceneManager.GetActiveScene().buildIndex;
            }
        }
        Debug.Log("This is Game " + GameData.SceneCount);
        PassGame = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadNextScene();
        }
    }
    void OrderBlackScenes(bool HaveSixGame)
    { // 0-->tutoria black 
      //1~3 test black 
      //4~6 play black
      //7 -->tutorial white
      //8~10 play white
        if (HaveSixGame)
        {
            for (int i = 0; i < GameData.SceneOrder.Length; i++)//不會跳到下一關
            {
                GameData.SceneOrder[i] = i + 1;
            }
        }
        else
        {
            for (int i = 0; i < GameData.SceneOrder.Length/2; i++)//不會跳到下一關
            {
                GameData.SceneOrder[i] = i + 4;
                GameData.SceneOrder[i+3] = i + 4;
            }
        }
        //shuffle
        for (int i = 0; i < GameData.SceneOrder.Length / 2; i++)//0~2
        {
            int temp = GameData.SceneOrder[i];
            int randomIndex = Random.Range(0, GameData.SceneOrder.Length / 2);
            GameData.SceneOrder[i] = GameData.SceneOrder[randomIndex];
            GameData.SceneOrder[randomIndex] = temp;
            //last three scene would be the order as first three
            temp = GameData.SceneOrder[i+3];
            randomIndex += 3;
            GameData.SceneOrder[i+3] = GameData.SceneOrder[randomIndex];
            GameData.SceneOrder[randomIndex] = temp;
        }
        
    }
    void OrderWhiteScenes(bool HaveSixGame)
    { // 0-->tutoria black 
      //1~3 test black 
      //4~6 play black
      //7 -->tutorial white
      //8~10 play white
        for (int i = 0; i < GameData.SceneOrder.Length; i++)//不會跳到下一關
        {
            GameData.SceneOrder[i] = i + 8;
            GameData.SceneOrder[i+3] = i + 8;
        }
        //shuffle
        for (int i = 0; i < GameData.SceneOrder.Length / 2; i++)//0~2
        {
            int temp = GameData.SceneOrder[i];
            int randomIndex = Random.Range(0, GameData.SceneOrder.Length / 2);
            GameData.SceneOrder[i] = GameData.SceneOrder[randomIndex];
            GameData.SceneOrder[randomIndex] = temp;
        }

    }
    public void LoadNextScene()
    {
        Time.timeScale = 1.0f;
        PassGame = false;
        SceneManager.LoadScene(GameData.SceneOrder[GameData.SceneCount]);
        GameData.SceneCount += 1;
    }

}
