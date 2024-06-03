using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxSpawnNew : MonoBehaviour
{
    public GameObject hitBox;
    public Transform Position;

    float reloadTime; // �����[�h�ɂ����鎞��
    int bullets;
    // Start is called before the first frame update
    void Start()
    {
        bullets = 1;
        reloadTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadTime <= 0.0f)
        {
            // �}�E�X���N���b�N
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(hitBox, Position.position, Position.rotation);
   
             // �����[�h���ԃZ�b�g
             reloadTime = 1.0f;
            }
        }
        else
        // �����[�h��
        {
            // �����[�h���ԃJ�E���g�_�E��
            reloadTime -= Time.deltaTime;

            // �����[�h���Ԃ��O�b�ȉ��ɂȂ�����
            if (reloadTime <= 0.0f)
            {
                // �e���[
                bullets = 1;
            }
        }
    }
}

