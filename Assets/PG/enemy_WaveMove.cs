using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_WaveMove : MonoBehaviour
{
    public float amplitude = 1f; // �E�F�[�u�̐U��
    public float speed = 2f; // �E�F�[�u�̑���
    public float minimumDistance = 2.0f; // �O�̓G�ƕێ�����ŏ�����
    public float moveSpeed = -5f; // �O�i���鑬�x

    private float startY;

    void Start()
    {
        startY = transform.position.y;

        // �G�̃��X�g�Ɏ�����o�^
        EnemyManager.RegisterEnemy(transform);
    }

    void Update()
    {
        float adjustedSpeed = moveSpeed;

        // �������O�̓G�����݂���ꍇ�A���x�𒲐�
        int enemyIndex = EnemyManager.allEnemies.IndexOf(transform);
        if (enemyIndex > 0)
        {
            Transform previousEnemy = EnemyManager.allEnemies[enemyIndex - 1];
            float distanceToPrevious = Vector3.Distance(transform.position, previousEnemy.position);

            if (distanceToPrevious < minimumDistance)
            {
                // �O�̓G�ɋ߂Â������Ȃ��悤�ɑ��x������
                adjustedSpeed = Mathf.Lerp(0, moveSpeed, distanceToPrevious / minimumDistance);
            }
        }

        // �O�ɐi�ވړ��i�������ꂽ���x�Łj
        transform.Translate(adjustedSpeed * Time.deltaTime, 0, 0);

        // �E�F�[�u���铮��������
        float newY = startY + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector2(transform.position.x, newY);
    }

    void OnDestroy()
    {
        // �G�̃��X�g���玩�����폜
        EnemyManager.DeregisterEnemy(transform);
    }
}
