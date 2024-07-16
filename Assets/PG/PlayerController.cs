using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public GameObject prefab;
    public string tag;
}

public class PlayerController : MonoBehaviour
{
    public Transform WeaponPositions;
    private Weapon weapon; // ����̃C���X�^���X��z��ŊǗ�
    public Weapon[] weaponDataes = new Weapon[3]; // ����̃^�O��z��ŊǗ� ����̃v���n�u
    private int currentWeaponIndex = 0; // ���݂̕���̃C���f�b�N�X

    private int idx;
    public GameObject[] PlayerPositions = new GameObject[3];

    public GameObject illustration1;
    public GameObject illustration2;
    public GameObject illustration3;

    private bool isKeyPressed1;
    private bool isKeyPressed2;
    private bool isKeyPressed3;
    //Start is called before the first frame update
    void Start()
    {
        SwitchWeapon(0);

        idx = 1;
        MoveByIndex(idx);

        illustration1.gameObject.SetActive(true);
        illustration2.gameObject.SetActive(false);
        illustration3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isKeyPressed1 = Input.GetKeyDown(KeyCode.A);
        isKeyPressed2 = Input.GetKeyDown(KeyCode.S);
        isKeyPressed3 = Input.GetKeyDown(KeyCode.D);
        // 1�`3�̃L�[����������Ή����镐���؂�ւ���
        {
            if (Input.GetKeyDown(KeyCode.A) && weaponDataes.Length >= 1)
            {
                SwitchWeapon(0);

                illustration1.gameObject.SetActive(true);
                illustration2.gameObject.SetActive(false);
                illustration3.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.S) && weaponDataes.Length >= 2)
            {
                SwitchWeapon(1);

                illustration1.gameObject.SetActive(false);
                illustration2.gameObject.SetActive(true);
                illustration3.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.D) && weaponDataes.Length >= 3)
            {
                SwitchWeapon(2);
                illustration1.gameObject.SetActive(false);
                illustration2.gameObject.SetActive(false);
                illustration3.gameObject.SetActive(true);
            }
            // �X�y�[�X�L�[����������I�����Ă��镐��𐶐�����
            //if (Input.GetKeyDown(KeyCode.Space)) GenerateCurrentWeapon();
        }

        //�v���C���[�̈ړ�����
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (idx > 0)
                {
                    idx--;
                    MoveByIndex(idx);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (idx < 2)
                {
                    idx++;
                    MoveByIndex(idx);
                }
            }
        }
    }
    private void SwitchWeapon(int index)
    {
        // �w�肳�ꂽ������A�N�e�B�u�ɂ���
        weapon = weaponDataes[index];
        // ���݂̕���̃C���f�b�N�X���X�V
        currentWeaponIndex = index;
        // ���ݑI������Ă��镐��𐶐�����
        if (weapon != null)
        {
            GameObject obj = Instantiate(weapon.prefab, WeaponPositions.position, Quaternion.identity);
            obj.tag = weapon.tag;
        }
    }
    //private void GenerateCurrentWeapon()
    //{
    //    // ���ݑI������Ă��镐��𐶐�����
    //    if (weapon!= null)
    //    {
    //        GameObject obj=Instantiate(weapon.prefab, WeaponPositions.position, Quaternion.identity);
    //        obj.tag = weapon.tag;
    //    }
    //}
    void DestroyWithTag(string tagToDestroy)
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tagToDestroy);

        foreach (GameObject obj in objectsToDestroy) Destroy(obj); 
    }

    void MoveByIndex(int index)
    {
        transform.position = PlayerPositions[index].transform.position;
    }
}