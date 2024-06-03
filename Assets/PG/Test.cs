using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject hitBox;
    public Transform Position;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(hitBox, Position.position, Position.rotation);
        }
    }
}
