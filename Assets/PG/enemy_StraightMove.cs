using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_StraightMove : MonoBehaviour
{
    private float moveSpeed;

    void Start()
    {
        // -3����-7�͈̔͂Ń����_���ȑ��x��ݒ肷��
        moveSpeed = Random.Range(-7f, -4f);
    }

    void Update()
    {
        // �ݒ肳�ꂽ�����_���ȑ��x�ňړ�����
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
}