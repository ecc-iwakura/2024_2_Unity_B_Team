using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeSkey : MonoBehaviour
{
    // Start is called before the first frame update
    //===== ��`�̈� =====
    private Animator anime;  //Animator��anim�Ƃ����ϐ��Œ�`����

    //===== �������� =====
    void Start()
    {
        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anime = GetComponent<Animator>();
    }

    //===== �又�� =====
    void Update()
    {
        //�����A�X�y�[�X�L�[�������ꂽ��Ȃ�
        if (Input.GetKey(KeyCode.S)) anime.SetBool("attack", true);

    }
    void Func1()
    {
        anime.SetBool("attack", false);
    }
}
