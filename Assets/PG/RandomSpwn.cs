using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpwn : MonoBehaviour
{
    public GameObject Enemy1, Enemy2, Enemy3, Enemy4, Enemy5, Enemy6;
    public Transform[] spawnPoints; // 生成場所の配列

    private int r;
    private int spawnIndex;


    public float waitTime = 1.0f;//生成のディレイ
    public float ShortenTime = 1.0f;//waitTimeを短縮する
    public float minimum =1.0f;//生成間隔の最小値
    // Start is called before the first frame update
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
            r = Random.Range(1, 7); // 1から6までのランダムな整数を生成
            spawnIndex = Random.Range(0, spawnPoints.Length); // 生成場所のランダムなインデックスを生成

            switch (r)
            {
                case 1:
                    Instantiate(Enemy1, spawnPoints[spawnIndex].position,
                                        spawnPoints[spawnIndex].rotation);
                    break;
                case 2:
                    Instantiate(Enemy2, spawnPoints[spawnIndex].position,
                                        spawnPoints[spawnIndex].rotation);
                    break;
                case 3:
                    Instantiate(Enemy3, spawnPoints[spawnIndex].position,
                                        spawnPoints[spawnIndex].rotation);
                    break;
                case 4:
                    Instantiate(Enemy4, spawnPoints[spawnIndex].position,
                                        spawnPoints[spawnIndex].rotation);
                    break;
                case 5:
                    Instantiate(Enemy5, spawnPoints[spawnIndex].position,
                                        spawnPoints[spawnIndex].rotation);
                    break;
                case 6:
                    Instantiate(Enemy6, spawnPoints[spawnIndex].position,
                                        spawnPoints[spawnIndex].rotation);
                    break;
            }

            waitTime -= ShortenTime; // waitTimeだんだんを短縮する

            if (waitTime < minimum) waitTime = minimum;

            yield return new WaitForSeconds(waitTime);//生成のディレイ
        }
    }
}