using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeSkey : MonoBehaviour
{
    // Start is called before the first frame update
    //===== 定義領域 =====
    private Animator anime;  //Animatorをanimという変数で定義する

    //===== 初期処理 =====
    void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anime = GetComponent<Animator>();
    }

    //===== 主処理 =====
    void Update()
    {
        //もし、スペースキーが押されたらなら
        if (Input.GetKey(KeyCode.S)) anime.SetBool("attack", true);

    }
    void Func1()
    {
        anime.SetBool("attack", false);
    }
}
