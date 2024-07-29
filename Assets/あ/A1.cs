using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class A1 : MonoBehaviour
{
    //===== 定義領域 =====
    private Animator anime;  //Animatorをanimという変数で定義する

    private ScoreManager score;
    public static bool des = false;
    private AudioSource sound1;

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

    // オブジェクトが移動するかどうかを管理するフラグ
    private bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        LifeManager lifePoint = FindObjectOfType<LifeManager>();

        //変数animに、Animatorコンポーネントを設定する
        anime = GetComponent<Animator>();

        // オブジェクトの初期位置を取得
        startPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            // （ポイント）マイナスをかけることで逆方向に移動する。
            transform.Translate(-5 * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(gameObject.tag))
        {
            score.AddScore(1);
            sound1.PlayOneShot(sound1.clip);
            anime.SetBool("apple", true);

            // オブジェクトの移動を停止
            isMoving = false;

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
        else
        {
            // Ignore collision if tags are different
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }

        if (collision.gameObject.CompareTag("Enemy_deathBox"))
        {
            Destroy(gameObject);
        }
    }
}
