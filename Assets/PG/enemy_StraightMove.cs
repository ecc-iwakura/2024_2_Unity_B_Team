using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_StraightMove : MonoBehaviour
{
    private float moveSpeed;

    void Start()
    {
        // -3から-7の範囲でランダムな速度を設定する
        moveSpeed = Random.Range(-7f, -4f);
    }

    void Update()
    {
        // 設定されたランダムな速度で移動する
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
}