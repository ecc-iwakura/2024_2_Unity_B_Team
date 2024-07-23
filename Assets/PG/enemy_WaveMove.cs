using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_WaveMove: MonoBehaviour
{ 
    public float amplitude = 1f; // �E�F�[�u�̐U��
    private float startY; // �����ʒu
    public float speed = 2f;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // �O�ɐi�ވړ�
        transform.Translate(-5 * Time.deltaTime, 0, 0);

        // �E�F�[�u���铮��������
        float newY = startY + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector2(transform.position.x, newY);
    }
}