using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_WaveMove : MonoBehaviour
{
    public float amplitude = 1f; // ウェーブの振幅
    public float speed = 2f; // ウェーブの速さ
    public float minimumDistance = 2.0f; // 前の敵と保持する最小距離
    public float moveSpeed = -5f; // 前進する速度

    private float startY;

    void Start()
    {
        startY = transform.position.y;

        // 敵のリストに自分を登録
        EnemyManager.RegisterEnemy(transform);
    }

    void Update()
    {
        float adjustedSpeed = moveSpeed;

        // 自分より前の敵が存在する場合、速度を調整
        int enemyIndex = EnemyManager.allEnemies.IndexOf(transform);
        if (enemyIndex > 0)
        {
            Transform previousEnemy = EnemyManager.allEnemies[enemyIndex - 1];
            float distanceToPrevious = Vector3.Distance(transform.position, previousEnemy.position);

            if (distanceToPrevious < minimumDistance)
            {
                // 前の敵に近づきすぎないように速度を減少
                adjustedSpeed = Mathf.Lerp(0, moveSpeed, distanceToPrevious / minimumDistance);
            }
        }

        // 前に進む移動（調整された速度で）
        transform.Translate(adjustedSpeed * Time.deltaTime, 0, 0);

        // ウェーブする動きを実装
        float newY = startY + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector2(transform.position.x, newY);
    }

    void OnDestroy()
    {
        // 敵のリストから自分を削除
        EnemyManager.DeregisterEnemy(transform);
    }
}
