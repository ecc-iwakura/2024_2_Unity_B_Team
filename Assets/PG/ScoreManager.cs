using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null; // Text�I�u�W�F�N�g
    public static int score_num = 0; // �X�R�A�ϐ�
    
    //������
    void Start()
    {
        //�V�[���J�ڂ̃C�x���g���X�i�[��o�^
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // �X�V
    void Update()
    {
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text score_text = score_object.GetComponent<Text>();
        // �e�L�X�g�̕\�������ւ���
        score_text.text = "Score:" + score_num;
    }

    // �X�R�A��ǉ����郁�\�b�h
    public void AddScore(int score)
    {
        score_num += score;
    }
}