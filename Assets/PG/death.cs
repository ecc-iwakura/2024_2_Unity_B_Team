using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class death : MonoBehaviour
{
    public float lifeTime = 0;

    void Update()
    {
        // （ポイント）マイナスをかけることで逆方向に移動する。
        transform.Translate(-5 * Time.deltaTime, 0, 0);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Destroy(gameObject);
    }
}
