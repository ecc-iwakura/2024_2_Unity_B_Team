using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class enemy_move : MonoBehaviour
{
 

    void Update()
    {
    

        // （ポイント）マイナスをかけることで逆方向に移動する。
        transform.Translate(-5* Time.deltaTime, 0,0);

      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}