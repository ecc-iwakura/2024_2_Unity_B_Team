using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpwn : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    public Transform[] spawnPoints; // 生成場所の配列

    private int r;
    private int spawnIndex;
    public float waitTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            r = Random.Range(1, 7); // 1か3までのランダムな整数を生成
            spawnIndex = Random.Range(0, spawnPoints.Length); // 生成場所のランダムなインデックスを生成

            switch (r)
            {
                case 1:
                    Instantiate(Enemy, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

                    break;
                case 2:
                    Instantiate(Enemy2, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

                    break;
                case 3:
                    Instantiate(Enemy3, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // 新しいゲームオブジェクトを生成

                    break;
                case 4:
                    Instantiate(Enemy4, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // 新しいゲームオブジェクトを生成

                    break;
                case 5:
                    Instantiate(Enemy5, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // 新しいゲームオブジェクトを生成

                    break;
                case 6:
                    Instantiate(Enemy6, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // 新しいゲームオブジェクトを生成

                    break;
            }
            yield return new WaitForSeconds(waitTime); // x秒待機
        }
    }
}
