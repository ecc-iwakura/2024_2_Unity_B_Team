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
        // ����������������΂����ɋL�q
    }

    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            // ���̃I�u�W�F�N�g�����E���ɐN�������Ƃ��ɌĂяo�����
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
