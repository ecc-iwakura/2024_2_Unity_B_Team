using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_WaveMove: MonoBehaviour
{ 
    public float amplitude = 1f; // ウェーブの振幅
    private float startY; // 初期位置
    public float speed = 2f;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // 前に進む移動
        transform.Translate(-5 * Time.deltaTime, 0, 0);

        // ウェーブする動きを実装
        float newY = startY + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector2(transform.position.x, newY);
    }
}