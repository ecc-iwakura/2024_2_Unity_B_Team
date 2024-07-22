using UnityEngine;

public class a : MonoBehaviour
{
    // 初期速度
    public float initialSpeed = 10f;
    // 重力の加速度
    public float gravity = 9.8f;
    // 左に移動する速度
    public float leftSpeed = 5f;

    // 時間経過を追跡するための変数
    private float timeElapsed = 0f;

    // スタート位置
    private Vector3 startPosition;

    // フェーズを管理する変数
    private bool isParabolicPhase = true;

    void Start()
    {
        // オブジェクトの初期位置を取得
        startPosition = transform.position;
    }

    void Update()
    {
        if (isParabolicPhase)
        {
            // 経過時間を更新
            timeElapsed += Time.deltaTime;

            // X軸方向の移動
            float x = initialSpeed * timeElapsed;

            // Y軸方向の移動（パラボラ運動）
            float y = initialSpeed * timeElapsed - 0.5f * gravity * timeElapsed * timeElapsed;

            // 新しい位置を計算
            Vector3 newPosition = startPosition + new Vector3(x, y, 0);

            // オブジェクトの位置を更新
            transform.position = newPosition;

            // パラボラ運動が終了する条件（Yが初期位置以下になったとき）
            if (transform.position.y < startPosition.y)
            {
                // パラボラ運動フェーズを終了
                isParabolicPhase = false;

                // オブジェクトのY軸を初期位置にリセット
                transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
            }
        }
        else
        {
            // 左に直線移動
            transform.position += Vector3.left * leftSpeed * Time.deltaTime;
        }
    }
}
