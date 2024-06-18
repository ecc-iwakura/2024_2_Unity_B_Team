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
        // �L�[�������ꂽ���ǂ������m�F���Abool�ϐ����X�V����
        isKeyPressed1 = Input.GetKeyDown(KeyCode.Alpha1);
        isKeyPressed2 = Input.GetKeyDown(KeyCode.Alpha2);
        isKeyPressed3 = Input.GetKeyDown(KeyCode.Alpha3);

        // ���ꂼ���bool�ϐ��Ɋ�Â��ăC���X�g��؂�ւ���
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