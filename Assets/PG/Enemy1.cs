using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private ScoreManager score;
    public static bool des = false;
    public GameObject ObjectZan;
    public GameObject hitPrefab;
    private AudioSource sound1;

    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        LifeManager lifePoint = FindObjectOfType<LifeManager>();
        sound1 = GetComponent<AudioSource>(); // AudioSource を取得する
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hitBox1"))
        {
            score.AddScore(1);
            Destroy(gameObject);
<<<<<<< HEAD:Assets/PG/Enemy.cs
            Destroy(collision.gameObject);
            if (sound1 != null && sound1.clip != null)
            {
                sound1.PlayOneShot(sound1.clip); // 音声を再生する
            }

            // Hit プレファブを表示させる
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, collision.transform.position, Quaternion.identity);
=======
            if (ObjectZan != null)
            {
                Instantiate(ObjectZan, transform.position, transform.rotation);
>>>>>>> 2fd6b0a7f545e1beb41e5a5cb49d76d51caacc0a:Assets/PG/Enemy1.cs
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
