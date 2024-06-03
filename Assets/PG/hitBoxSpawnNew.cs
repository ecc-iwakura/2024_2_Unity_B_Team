using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxSpawnNew : MonoBehaviour
{
    public GameObject hitBox;
    public Transform Position;

    float reloadTime; // リロードにかかる時間
    int bullets;
    // Start is called before the first frame update
    void Start()
    {
        bullets = 1;
        reloadTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadTime <= 0.0f)
        {
            // マウス左クリック
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(hitBox, Position.position, Position.rotation);
   
             // リロード時間セット
             reloadTime = 1.0f;
            }
        }
        else
        // リロード中
        {
            // リロード時間カウントダウン
            reloadTime -= Time.deltaTime;

            // リロード時間が０秒以下になったら
            if (reloadTime <= 0.0f)
            {
                // 弾を補充
                bullets = 1;
            }
        }
    }
}

