using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
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
            r = Random.Range(1, 6); // 1から5までのランダムな整数を生成
            spawnIndex = Random.Range(0, spawnPoints.Length); // 生成場所のランダムなインデックスを生成

            if (r == 2)
            {
                Instantiate(Enemy, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            }
            else if (r == 3)
            {
                Instantiate(Enemy2, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            }
            else if (r == 4)
            {
                Instantiate(Enemy3, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // 新しいゲームオブジェクトを生成
            }
            else
            {
                // rが2, 3, 4以外の場合は何もしない
            }

            yield return new WaitForSeconds(1f); // 1.5秒待機
        }
    }
}
