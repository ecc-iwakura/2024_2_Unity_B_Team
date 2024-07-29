using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : MonoBehaviour
{
    public float lifeTime = 0.5f; // �e�ۂ̐�������
    public GameObject missPrefab; // miss �v���t�@�u���C���X�y�N�^����ݒ肷��
    private bool destroyed = false; // �j�����ꂽ���ǂ����̃t���O

    // Update is called once per frame
    void Update()
    {
        // �e�ۂ�j������
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0 && !destroyed)
        {
            destroyed = true; // �t���O��ݒ肵�ē�d������h�~
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // miss �v���t�@�u��\��������
        if (missPrefab != null && destroyed)
        {
            Instantiate(missPrefab, transform.position, Quaternion.identity);
        }
        if (lifeTime <= 0) Destroy(gameObject);
    }
}