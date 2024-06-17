using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ScoreManager score;
    public static bool des = false;
    public GameObject ObjectZan;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        LifeManager lifePoint = FindObjectOfType<LifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(gameObject.tag))
        {
            score.AddScore(1);
            Destroy(gameObject);
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

    private void OnDestroy()
    {
        if (ObjectZan != null)
        {
            Instantiate(ObjectZan, transform.position, transform.rotation);
        }
    }
}

