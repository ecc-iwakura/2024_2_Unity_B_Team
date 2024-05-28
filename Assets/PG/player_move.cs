using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// using UnityEngine.Windows;

public class player_move : MonoBehaviour
{
    private int idx;
    public GameObject[] positions = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        idx = 1;
        MoveByIndex(idx);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (idx > 0)
            {
                idx--;
                MoveByIndex(idx);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (idx < 2)
            {
                idx++;
                MoveByIndex(idx);
            }
        }

    }

    void MoveByIndex(int index)
    {
        transform.position = positions[index].transform.position;
    }
}
