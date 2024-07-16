using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public static int lifePoint = 3;
    public static GameObject[] lifeArray = new GameObject[3];

    void Start()
    {

    }
    private void Update()
    {
        if (Enemy1.des== true)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
            Enemy1.des = false;

            if (lifePoint <= 0)
            {
                SceneManager.LoadScene("Lesult");
            }
        }
        if (Enemy2.des == true)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
            Enemy2.des = false;

            if (lifePoint <= 0)
            {
                SceneManager.LoadScene("Lesult");
            }
        }
        if (Enemy3.des == true)
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;
            Enemy3.des = false;

            if (lifePoint <= 0)
            {
                SceneManager.LoadScene("Lesult");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy1" ||
            collision.gameObject.tag == "Enemy2" || 
            collision.gameObject.tag == "Enemy3")
        {
            lifeArray[lifePoint - 1].SetActive(false);
            lifePoint--;

            if (lifePoint <= 0) SceneManager.LoadScene("Lesult");
            
        }
    }
}