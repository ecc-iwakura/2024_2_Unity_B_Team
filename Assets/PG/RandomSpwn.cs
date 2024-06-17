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
    public Transform[] spawnPoints; // �����ꏊ�̔z��

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
            r = Random.Range(1, 7); // 1��3�܂ł̃����_���Ȑ����𐶐�
            spawnIndex = Random.Range(0, spawnPoints.Length); // �����ꏊ�̃����_���ȃC���f�b�N�X�𐶐�

            switch (r)
            {
                case 1:
                    Instantiate(Enemy, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

                    break;
                case 2:
                    Instantiate(Enemy2, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

                    break;
                case 3:
                    Instantiate(Enemy3, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // �V�����Q�[���I�u�W�F�N�g�𐶐�

                    break;
                case 4:
                    Instantiate(Enemy4, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // �V�����Q�[���I�u�W�F�N�g�𐶐�

                    break;
                case 5:
                    Instantiate(Enemy5, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // �V�����Q�[���I�u�W�F�N�g�𐶐�

                    break;
                case 6:
                    Instantiate(Enemy6, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // �V�����Q�[���I�u�W�F�N�g�𐶐�

                    break;
            }
            yield return new WaitForSeconds(waitTime); // x�b�ҋ@
        }
    }
}
