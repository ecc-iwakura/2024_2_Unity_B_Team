using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ScoreManager score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        LifeManager lifePoint = FindObjectOfType<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Any enemy-specific logic can go here
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hit box")
        {
            score.AddScore(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy_deathBox")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            LifeManager.lifePoint--;
        }
    }
}

