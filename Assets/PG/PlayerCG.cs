using UnityEngine;
using UnityEngine.UI;

public class PlayerCG : MonoBehaviour
{
    public GameObject illustration1;
    public GameObject illustration2;
    public GameObject illustration3;

    private bool isKeyPressed1;
    private bool isKeyPressed2;
    private bool isKeyPressed3;

    void Start()
    {
        illustration1.gameObject.SetActive(true);
        illustration2.gameObject.SetActive(false);
        illustration3.gameObject.SetActive(false);
    }
    void Update()
    {
        // キーが押されたかどうかを確認し、bool変数を更新する
        isKeyPressed1 = Input.GetKeyDown(KeyCode.Alpha1);
        isKeyPressed2 = Input.GetKeyDown(KeyCode.Alpha2);
        isKeyPressed3 = Input.GetKeyDown(KeyCode.Alpha3);

        // それぞれのbool変数に基づいてイラストを切り替える
        if (isKeyPressed1)
        {
            illustration1.gameObject.SetActive(true);
            illustration2.gameObject.SetActive(false);
            illustration3.gameObject.SetActive(false);
        }
        else if (isKeyPressed2)
        {
            illustration1.gameObject.SetActive(false);
            illustration2.gameObject.SetActive(true);
            illustration3.gameObject.SetActive(false);
        }
        else if (isKeyPressed3)
        {
            illustration1.gameObject.SetActive(false);
            illustration2.gameObject.SetActive(false);
            illustration3.gameObject.SetActive(true);
        }

    }
}