using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class A1 : MonoBehaviour
{
    //===== ��`�̈� =====
    private Animator anime;  //Animator��anim�Ƃ����ϐ��Œ�`����

    private ScoreManager score;
    public static bool des = false;
    private AudioSource sound1;

    // �������x
    public float initialSpeed = 10f;
    // �d�͂̉����x
    public float gravity = 9.8f;
    // ���Ɉړ����鑬�x
    public float leftSpeed = 5f;

    // ���Ԍo�߂�ǐՂ��邽�߂̕ϐ�
    private float timeElapsed = 0f;

    // �X�^�[�g�ʒu
    private Vector3 startPosition;

    // �t�F�[�Y���Ǘ�����ϐ�
    private bool isParabolicPhase = true;

    // �I�u�W�F�N�g���ړ����邩�ǂ������Ǘ�����t���O
    private bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        LifeManager lifePoint = FindObjectOfType<LifeManager>();

        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anime = GetComponent<Animator>();

        // �I�u�W�F�N�g�̏����ʒu���擾
        startPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            // �i�|�C���g�j�}�C�i�X�������邱�Ƃŋt�����Ɉړ�����B
            transform.Translate(-5 * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(gameObject.tag))
        {
            score.AddScore(1);
            sound1.PlayOneShot(sound1.clip);
            anime.SetBool("apple", true);

            // �I�u�W�F�N�g�̈ړ����~
            isMoving = false;

            if (isParabolicPhase)
            {
                // �o�ߎ��Ԃ��X�V
                timeElapsed += Time.deltaTime;

                // X�������̈ړ�
                float x = initialSpeed * timeElapsed;

                // Y�������̈ړ��i�p���{���^���j
                float y = initialSpeed * timeElapsed - 0.5f * gravity * timeElapsed * timeElapsed;

                // �V�����ʒu���v�Z
                Vector3 newPosition = startPosition + new Vector3(x, y, 0);

                // �I�u�W�F�N�g�̈ʒu���X�V
                transform.position = newPosition;

                // �p���{���^�����I����������iY�������ʒu�ȉ��ɂȂ����Ƃ��j
                if (transform.position.y < startPosition.y)
                {
                    // �p���{���^���t�F�[�Y���I��
                    isParabolicPhase = false;

                    // �I�u�W�F�N�g��Y���������ʒu�Ƀ��Z�b�g
                    transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
                }
            }
            else
            {
                // ���ɒ����ړ�
                transform.position += Vector3.left * leftSpeed * Time.deltaTime;
            }
        }
        else
        {
            // Ignore collision if tags are different
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }

        if (collision.gameObject.CompareTag("Enemy_deathBox"))
        {
            Destroy(gameObject);
        }
    }
}
