using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : MonoBehaviour
{
    public float lifeTime = 0.5f; // �e�ۂ̐�������

    // Update is called once per frame
    void Update()
    {
        // �e�ۂ�j������
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) Destroy(gameObject);
    }
}