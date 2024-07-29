using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_StraightMove : MonoBehaviour
{
    public float minimumDistance = 2.0f; // ���̓G�ƕێ�����ŏ�����
    private float moveSpeed;

    void Start()
    {
        // -3����-7�͈̔͂Ń����_���ȑ��x��ݒ肷��
        moveSpeed = Random.Range(-7f, -4f);

        // �G�̃��X�g�Ɏ�����o�^
        EnemyManager.RegisterEnemy(transform);
    }

    void Update()
    {
        float adjustedSpeed = moveSpeed;

        // ���̓G�Ƃ̋������`�F�b�N
        foreach (Transform otherEnemy in EnemyManager.allEnemies)
        {
            if (otherEnemy != transform)
            {
                float distanceToOther = Vector3.Distance(transform.position, otherEnemy.position);

                if (distanceToOther < minimumDistance)
                {
                    // ���̓G�ɋ߂Â������Ȃ��悤�ɑ��x������
                    adjustedSpeed = Mathf.Lerp(0, moveSpeed, distanceToOther / minimumDistance);
                }
            }
        }

        // �ݒ肳�ꂽ�i�������ꂽ�j���x�ňړ�����
        transform.Translate(adjustedSpeed * Time.deltaTime, 0, 0);
    }

    void OnDestroy()
    {
        // �G�̃��X�g���玩�����폜
        EnemyManager.DeregisterEnemy(transform);
    }
}
