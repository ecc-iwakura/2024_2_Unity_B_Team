using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ScoreManager score;
    // Start is called before the first frame update
    void Start()
    {
        score=FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-5 * Time.deltaTime, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hit box")
        {
            score.AddScore(1);
            Destroy(gameObject);
        }
    }
}
