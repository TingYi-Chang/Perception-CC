using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public bool PassGame;
    public bool Reorder;
    /*void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }*/
    void Start()
    {
        if (GameData.SceneCount == 0)//如果是開始的scene 避免不是從tutorial 開始
        {
            Debug.Log("起始scene");
            for (int i = 1; i <= GameData.SceneOrder.Length; i++)//位置0~5 數字1~6
            {
                GameData.SceneOrder[i - 1] = i;
            }
            GameData.SceneCount = SceneManager.GetActiveScene().buildIndex;
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)//如果是從tutorail 開始
        {
            Debug.Log("從教學開始");
            if (Reorder)
            {
                ReorderScenes();
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
    void ReorderScenes()
    {
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
    public void LoadNextScene()
    {
        Time.timeScale = 1.0f;
        PassGame = false;
        SceneManager.LoadScene(GameData.SceneOrder[GameData.SceneCount]);
        GameData.SceneCount += 1;
    }

}
