using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpwn : MonoBehaviour
{
    public GameObject[] enemies; // 敵のプレハブの配列
    public Transform[] spawnPoints; // 生成場所の配列

    private int spawnIndex;
    public float waitTime = 1.0f; // 生成のディレイ
    public float shortenTime = 1.0f; // waitTimeを短縮する
    public float minimum = 1.0f; // 生成間隔の最小値

    void Start()
    {
        StartCoroutine(StartSpawningWithDelay(3.0f)); // 3秒の遅延を追加
    }

    private IEnumerator StartSpawningWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 指定した秒数待機
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int r = Random.Range(0, enemies.Length); // 0から配列の長さ-1までのランダムな整数を生成
            spawnIndex = Random.Range(0, spawnPoints.Length); // 生成場所のランダムなインデックスを生成

            Instantiate(enemies[r], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

            waitTime -= shortenTime; // waitTimeを短縮する

            if (waitTime < minimum) waitTime = minimum;

            yield return new WaitForSeconds(waitTime); // 生成のディレイ
        }
    }
}
