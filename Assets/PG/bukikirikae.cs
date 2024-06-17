using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public GameObject prefab;
    public string tag;
}

public class bukikirikae : MonoBehaviour
{
    public Transform Position;
    private Weapon weapon; // ����̃C���X�^���X��z��ŊǗ�
    public Weapon[] weaponDataes = new Weapon[3]; // ����̃^�O��z��ŊǗ� ����̃v���n�u
    private int currentWeaponIndex = 0; // ���݂̕���̃C���f�b�N�X

    // Start is called before the first frame update
    void Start()
    {
        // ����𐶐����AweaponTags �ɑΉ�����^�O�������̂�����z��ɒǉ�����
       
        //for (int i = 0; i < weaponDataes.Length; i++)
        //{
        //    if (!weaponDataes[i].prefab) continue;
        //    GameObject newWeapon = Instantiate(weaponDataes[i].prefab, transform.position, Quaternion.identity);
        //    newWeapon.SetActive(false); // ������Ԃł͂��ׂĂ̕�����A�N�e�B�u�ɂ���
        //    newWeapon.tag = weaponDataes[i].tag; // ����ɓK�؂ȃ^�O�����蓖�Ă�
            
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // 1�`3�̃L�[����������Ή����镐���؂�ւ���
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponDataes.Length >= 1) SwitchWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponDataes.Length >= 2) SwitchWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponDataes.Length >= 3) SwitchWeapon(2);

        // �X�y�[�X�L�[����������I�����Ă��镐��𐶐�����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateCurrentWeapon();
        }
    }

    private void SwitchWeapon(int index)
    {
        // ���݂̕�����A�N�e�B�u�ɂ���
        //weapons[currentWeaponIndex].SetActive(false);

        // �w�肳�ꂽ������A�N�e�B�u�ɂ���
        //weapons[index].SetActive(true);
        weapon = weaponDataes[index];
        // ���݂̕���̃C���f�b�N�X���X�V
        currentWeaponIndex = index;
    }

    //private void UnequipWeapon()
    //{
    //    // ���݂̕�����A�N�e�B�u�ɂ���
    //    weapons[currentWeaponIndex].SetActive(false);
    //}

    private void GenerateCurrentWeapon()
    {
        // ���ݑI������Ă��镐��𐶐�����
        if (weapon!= null)
        {
            GameObject obj=Instantiate(weapon.prefab, Position.position, Quaternion.identity);
            obj.tag = weapon.tag;
        }
    }
}