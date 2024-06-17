using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxSpawnNew : MonoBehaviour
{
    public GameObject hitBox1;
    public Transform Position;

    float reloadTime; // リロードにかかる時間
    // Start is called before the first frame update
    void Start()
    {
        reloadTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadTime <= 0.0f)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(hitBox1, Position.position, Position.rotation);
             // リロード時間セット
             reloadTime = 1.0f;
            }
        }
        else
        // リロード中
        {
            // リロード時間カウントダウン
            reloadTime -= Time.deltaTime;
        }
    }
}

