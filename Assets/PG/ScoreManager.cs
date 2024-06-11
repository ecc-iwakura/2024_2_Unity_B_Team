using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public static int score_num = 0; // スコア変数
    public string resetSceneName = "MainScene1"; // スコアをリセットするシーンの名前

    // 初期化
    void Start()
    {
        // シーン遷移のイベントリスナーを登録
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "Score:" + score_num;
    }

    // スコアを追加するメソッド
    public void AddScore(int score)
    {
        score_num += score;
    }

    // シーンがロードされた時に呼び出されるメソッド
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 指定されたシーンに移動したときだけスコアをリセット
        if (scene.name == resetSceneName)
        {
            score_num = 0;
        }
    }

    // オブジェクトが破棄される時に呼び出されるメソッド
    void OnDestroy()
    {
        // シーン遷移のイベントリスナーを解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}