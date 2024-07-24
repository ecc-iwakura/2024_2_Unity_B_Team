using UnityEngine;

public class a : MonoBehaviour
{
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

    void Start()
    {
        // �I�u�W�F�N�g�̏����ʒu���擾
        startPosition = transform.position;
    }

    void Update()
    {
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
}
