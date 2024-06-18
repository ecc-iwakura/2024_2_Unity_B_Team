using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpwn : MonoBehaviour
{
    public GameObject Enemy1, Enemy2, Enemy3, Enemy4, Enemy5, Enemy6;
    public Transform[] spawnPoints; // �����ꏊ�̔z��

    private int r;
    private int spawnIndex;


    public float waitTime = 1.0f;//�����̃f�B���C
    public float ShortenTime = 1.0f;//waitTime��Z�k����
    public float minimum =1.0f;//�����Ԋu�̍ŏ��l
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawningWithDelay(3.0f)); // 3�b�̒x����ǉ�
    }

    private IEnumerator StartSpawningWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // �w�肵���b���ҋ@
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            r = Random.Range(1, 7); // 1����6�܂ł̃����_���Ȑ����𐶐�
            spawnIndex = Random.Range(0, spawnPoints.Length); // �����ꏊ�̃����_���ȃC���f�b�N�X�𐶐�

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

            waitTime -= ShortenTime; // waitTime���񂾂��Z�k����

            if (waitTime < minimum) waitTime = minimum;

            yield return new WaitForSeconds(waitTime);//�����̃f�B���C
        }
    }
}