using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject hitBox;
    public Transform FirePosition;

    float etime;
    // Start is called before the first frame update
    void Start()
    {
        etime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        etime += Time.deltaTime;

        if (etime > 0.25f)
        {
            Instantiate(Bullet, FirePosition.position, FirePosition.rotation);
            Instantiate(Bullet, FirePosition2.position, FirePosition2.rotation);
            Instantiate(Bullet, FirePosition3.position, FirePosition3.rotation);
            etime = 0;
        }
    }
}
