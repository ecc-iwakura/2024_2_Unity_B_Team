using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Enemy;
    public Transform Position;
    public Transform Position2;
    public Transform Position3;

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
            Instantiate(Enemy, Position.position, Position.rotation);
            Instantiate(Enemy, Position2.position, Position2.rotation);
            Instantiate(Enemy, Position3.position, Position3.rotation);
            etime = 0;
        }
    }
}