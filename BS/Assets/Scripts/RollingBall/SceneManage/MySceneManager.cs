using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public bool PassGame;
    public bool HaveTsetPhase;

    [HeaderAttribute("Fill 1~3")]
    public int Sequence1;
    public int Sequence2, Sequence3;

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
            OrderWhiteScenes();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 11)//如果是從demo 開始 ->3關
        {
            Debug.Log("從demo scene開始");
            OrderBlackScenes(false);
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
            GameData.SceneOrder[0] = Sequence1; GameData.SceneOrder[1] = Sequence1+3;
            GameData.SceneOrder[2] = Sequence2; GameData.SceneOrder[3] = Sequence2 + 3;
            GameData.SceneOrder[4] = Sequence3; GameData.SceneOrder[5] = Sequence3 + 3;
        }
        else
        {
            GameData.SceneOrder[0] = Sequence1+3; GameData.SceneOrder[3] = Sequence1 + 3;
            GameData.SceneOrder[1] = Sequence2+3; GameData.SceneOrder[4] = Sequence2 + 3;
            GameData.SceneOrder[2] = Sequence3+3; GameData.SceneOrder[5] = Sequence3 + 3;
        }
        
    }
    void OrderWhiteScenes()
    { // 0-->tutoria black 
      //1~3 test black 
      //4~6 play black
      //7 -->tutorial white
      //8~10 play white
        GameData.SceneOrder[0] = Sequence1 + 7; GameData.SceneOrder[3] = Sequence1 + 7;
        GameData.SceneOrder[1] = Sequence2 + 7; GameData.SceneOrder[4] = Sequence2 + 7;
        GameData.SceneOrder[2] = Sequence3 + 7; GameData.SceneOrder[5] = Sequence3 + 7;

    }
    public void LoadNextScene()
    {
        Time.timeScale = 1.0f;
        PassGame = false;
        SceneManager.LoadScene(GameData.SceneOrder[GameData.SceneCount]);
        GameData.SceneCount += 1;
    }

}
