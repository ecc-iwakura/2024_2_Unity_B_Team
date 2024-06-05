using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class enemy_StraightMove : MonoBehaviour
{
    public float lifeTime = 1f;

    void Update()
    {
        // （ポイント）マイナスをかけることで逆方向に移動する。
        transform.Translate(-5 * Time.deltaTime, 0, 0);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}