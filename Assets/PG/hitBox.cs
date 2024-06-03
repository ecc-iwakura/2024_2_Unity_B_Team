using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : MonoBehaviour
{
    public float lifeTime = 0.5f; // ’eŠÛ‚Ì¶‘¶ŠÔ

    // Update is called once per frame
    void Update()
    {
        // ’eŠÛ‚ğ”jŠü‚·‚é
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    // “–‚½‚è”»’è
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ƒvƒŒƒCƒ„[‚É“–‚½‚Á‚½ê‡
        {
            Destroy(gameObject); // ’eŠÛ‚ğ”jŠü
        }
    }
}
