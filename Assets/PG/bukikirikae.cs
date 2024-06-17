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
    private Weapon weapon; // 武器のインスタンスを配列で管理
    public Weapon[] weaponDataes = new Weapon[3]; // 武器のタグを配列で管理 武器のプレハブ
    private int currentWeaponIndex = 0; // 現在の武器のインデックス

    // Start is called before the first frame update
    void Start()
    {
        // 武器を生成し、weaponTags に対応するタグを持つものだけを配列に追加する
       
        //for (int i = 0; i < weaponDataes.Length; i++)
        //{
        //    if (!weaponDataes[i].prefab) continue;
        //    GameObject newWeapon = Instantiate(weaponDataes[i].prefab, transform.position, Quaternion.identity);
        //    newWeapon.SetActive(false); // 初期状態ではすべての武器を非アクティブにする
        //    newWeapon.tag = weaponDataes[i].tag; // 武器に適切なタグを割り当てる
            
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // 1～3のキーを押したら対応する武器を切り替える
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponDataes.Length >= 1) SwitchWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponDataes.Length >= 2) SwitchWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponDataes.Length >= 3) SwitchWeapon(2);

        // スペースキーを押したら選択している武器を生成する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateCurrentWeapon();
        }
    }

    private void SwitchWeapon(int index)
    {
        // 現在の武器を非アクティブにする
        //weapons[currentWeaponIndex].SetActive(false);

        // 指定された武器をアクティブにする
        //weapons[index].SetActive(true);
        weapon = weaponDataes[index];
        // 現在の武器のインデックスを更新
        currentWeaponIndex = index;
    }

    //private void UnequipWeapon()
    //{
    //    // 現在の武器を非アクティブにする
    //    weapons[currentWeaponIndex].SetActive(false);
    //}

    private void GenerateCurrentWeapon()
    {
        // 現在選択されている武器を生成する
        if (weapon!= null)
        {
            GameObject obj=Instantiate(weapon.prefab, Position.position, Quaternion.identity);
            obj.tag = weapon.tag;
        }
    }
}