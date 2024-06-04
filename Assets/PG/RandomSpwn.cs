using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpwn : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public Transform[] spawnPoints; // 生成場所の配列

    private int r;
    private int spawnIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            r = Random.Range(1, 3); // 1か4までのランダムな整数を生成
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
            }
            yield return new WaitForSeconds(1.5f); // 1.5秒待機
        }
        //            if (r == 2)
        //            {
        //                Instantiate(Enemy, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        //            }
        //            else if (r == 3)
        //            {
        //                Instantiate(Enemy2, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        //            }
        //            else if (r == 4)
        //            {
        //                Instantiate(Enemy3, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // 新しいゲームオブジェクトを生成
        //            }
        //            yield return new WaitForSeconds(1f); // 1秒待機
        //        }
    }
}
