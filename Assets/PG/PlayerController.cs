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
        // 1～3のキーを押したら対応する武器を切り替える
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
            // スペースキーを押したら選択している武器を生成する
            //if (Input.GetKeyDown(KeyCode.Space)) GenerateCurrentWeapon();
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
        // 現在選択されている武器を生成する
        if (weapon != null)
        {
            GameObject obj = Instantiate(weapon.prefab, WeaponPositions.position, Quaternion.identity);
            obj.tag = weapon.tag;
        }
    }
    //private void GenerateCurrentWeapon()
    //{
    //    // 現在選択されている武器を生成する
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