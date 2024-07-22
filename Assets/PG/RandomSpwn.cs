using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpwn : MonoBehaviour
{
    public GameObject[] enemies; // �G�̃v���n�u�̔z��
    public Transform[] spawnPoints; // �����ꏊ�̔z��

    private int spawnIndex;
    public float waitTime = 1.0f; // �����̃f�B���C
    public float shortenTime = 1.0f; // waitTime��Z�k����
    public float minimum = 1.0f; // �����Ԋu�̍ŏ��l

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
            int r = Random.Range(0, enemies.Length); // 0����z��̒���-1�܂ł̃����_���Ȑ����𐶐�
            spawnIndex = Random.Range(0, spawnPoints.Length); // �����ꏊ�̃����_���ȃC���f�b�N�X�𐶐�

            Instantiate(enemies[r], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

            waitTime -= shortenTime; // waitTime��Z�k����

            if (waitTime < minimum) waitTime = minimum;

            yield return new WaitForSeconds(waitTime); // �����̃f�B���C
        }
    }
}
