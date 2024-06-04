using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpwn : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public Transform[] spawnPoints; // �����ꏊ�̔z��

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
            r = Random.Range(1, 3); // 1��4�܂ł̃����_���Ȑ����𐶐�
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
            }
            yield return new WaitForSeconds(1.5f); // 1.5�b�ҋ@
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
        //                Instantiate(Enemy3, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation); // �V�����Q�[���I�u�W�F�N�g�𐶐�
        //            }
        //            yield return new WaitForSeconds(1f); // 1�b�ҋ@
        //        }
    }
}
