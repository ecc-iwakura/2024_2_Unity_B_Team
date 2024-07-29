using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : MonoBehaviour
{
    public float lifeTime = 0.5f; // 弾丸の生存時間
    public GameObject missPrefab; // miss プレファブをインスペクタから設定する
    private bool destroyed = false; // 破棄されたかどうかのフラグ

    // Update is called once per frame
    void Update()
    {
        // 弾丸を破棄する
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0 && !destroyed)
        {
            destroyed = true; // フラグを設定して二重生成を防止
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // miss プレファブを表示させる
        if (missPrefab != null && destroyed)
        {
            Instantiate(missPrefab, transform.position, Quaternion.identity);
        }
        if (lifeTime <= 0) Destroy(gameObject);
    }
}