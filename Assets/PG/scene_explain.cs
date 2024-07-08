using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_explain : MonoBehaviour
{
    public string explain1; // ‘JˆÚæ‚ÌƒV[ƒ“–¼
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(explain1);

            ScoreManager.score_num = 0;

            LifeManager.lifePoint = 3;
        }
    }
}

