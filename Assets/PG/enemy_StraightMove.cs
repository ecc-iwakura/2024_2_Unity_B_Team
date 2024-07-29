using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_StraightMove : MonoBehaviour
{
    public float minimumDistance = 2.0f; // 他の敵と保持する最小距離
    private float moveSpeed;

    void Start()
    {
        // -3から-7の範囲でランダムな速度を設定する
        moveSpeed = Random.Range(-7f, -4f);

        // 敵のリストに自分を登録
        EnemyManager.RegisterEnemy(transform);
    }

    void Update()
    {
        float adjustedSpeed = moveSpeed;

        // 他の敵との距離をチェック
        foreach (Transform otherEnemy in EnemyManager.allEnemies)
        {
            if (otherEnemy != transform)
            {
                float distanceToOther = Vector3.Distance(transform.position, otherEnemy.position);

                if (distanceToOther < minimumDistance)
                {
                    // 他の敵に近づきすぎないように速度を減少
                    adjustedSpeed = Mathf.Lerp(0, moveSpeed, distanceToOther / minimumDistance);
                }
            }
        }

        // 設定された（調整された）速度で移動する
        transform.Translate(adjustedSpeed * Time.deltaTime, 0, 0);
    }

    void OnDestroy()
    {
        // 敵のリストから自分を削除
        EnemyManager.DeregisterEnemy(transform);
    }
}
