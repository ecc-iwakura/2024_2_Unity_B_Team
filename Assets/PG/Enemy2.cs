using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private ScoreManager score;
    public static bool des = false;
    public GameObject ObjectZan;
    public GameObject hitPrefab;
    private AudioSource sound1;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        LifeManager lifePoint = FindObjectOfType<LifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hitBox2"))
        {score.AddScore(1);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            if (sound1 != null && sound1.clip != null)
            {
                sound1.PlayOneShot(sound1.clip); // 音声を再生する
            }

            // Hit プレファブを表示させる
            if (hitPrefab != null)
            {
                Instantiate(hitPrefab, collision.transform.position, Quaternion.identity);
            }
            if (ObjectZan != null)
            {
                Instantiate(ObjectZan, transform.position, transform.rotation);
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
