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
    private Weapon weapon; // 武器のインスタンスを配列で管理
    public Weapon[] weaponDataes = new Weapon[3]; // 武器のタグを配列で管理 武器のプレハブ
    private int currentWeaponIndex = 0; // 現在の武器のインデックス

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
        // 1～3のキーを押したら対応する武器を切り替える
        {
            if (Input.GetKeyDown(KeyCode.A) && weaponDataes.Length >= 1) SwitchWeapon(0);

            if (Input.GetKeyDown(KeyCode.S) && weaponDataes.Length >= 2) SwitchWeapon(1);

            if (Input.GetKeyDown(KeyCode.D) && weaponDataes.Length >= 3) SwitchWeapon(2);

            // スペースキーを押したら選択している武器を生成する
            if (Input.GetKeyDown(KeyCode.Space)) GenerateCurrentWeapon();
        }

        //プレイヤーの移動処理
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
        // 指定された武器をアクティブにする
        weapon = weaponDataes[index];
        // 現在の武器のインデックスを更新
        currentWeaponIndex = index;
    }
    private void GenerateCurrentWeapon()
    {
        // 現在選択されている武器を生成する
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