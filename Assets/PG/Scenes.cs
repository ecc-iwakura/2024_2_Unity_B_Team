using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{ 
    public string sceneName; // 遷移先のシーン名
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);

            ScoreManager.score_num = 0;

            LifeManager.lifePoint = 3;
        }
    }
}

