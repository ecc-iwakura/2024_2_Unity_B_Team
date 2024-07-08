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

    //Start is called before the first frame update
    void Start()
    {
        SwitchWeapon(0);

        idx = 1;
        MoveByIndex(idx);
    }

    // Update is called once per frame
    void Update()
    {
        // 1�`3�̃L�[����������Ή����镐���؂�ւ���
        {
            if (Input.GetKeyDown(KeyCode.A) && weaponDataes.Length >= 1) SwitchWeapon(0);

            if (Input.GetKeyDown(KeyCode.S) && weaponDataes.Length >= 2) SwitchWeapon(1);

            if (Input.GetKeyDown(KeyCode.D) && weaponDataes.Length >= 3) SwitchWeapon(2);

            // �X�y�[�X�L�[����������I�����Ă��镐��𐶐�����
            if (Input.GetKeyDown(KeyCode.Space)) GenerateCurrentWeapon();
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
    }
    private void GenerateCurrentWeapon()
    {
        // ���ݑI������Ă��镐��𐶐�����
        if (weapon!= null)
        {
            GameObject obj=Instantiate(weapon.prefab, WeaponPositions.position, Quaternion.identity);
            obj.tag = weapon.tag;
        }
    }
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