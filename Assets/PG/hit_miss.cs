using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_miss : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public Transform spawnLocation;

    void Start()
    {
        // 初期化処理があればここに記述
    }

    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            // 他のオブジェクトが境界線に侵入したときに呼び出される
            if (other.CompareTag("Enemy1"))
            {
                Instantiate(prefab1, spawnLocation.position, spawnLocation.rotation);
            }
            else if (other.CompareTag("Enemy2"))
            {
                Instantiate(prefab2, spawnLocation.position, spawnLocation.rotation);
            }
        }
       
    }
}
