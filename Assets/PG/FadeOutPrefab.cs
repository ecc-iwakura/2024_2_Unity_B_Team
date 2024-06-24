using System.Collections;
using UnityEngine;

public class FadeOutPrefab : MonoBehaviour
{
    public float fadeDuration = 1.5f; // �t�F�[�h�A�E�g�ɂ����鎞�ԁi�b�j

    private Renderer objRenderer;
    private Color originalColor;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
        if (objRenderer == null)
        {
            Debug.LogError("Renderer�R���|�[�l���g��������܂���B");
            return;
        }
        originalColor = objRenderer.material.color;
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1.0f - elapsedTime / fadeDuration);
            Color newColor = originalColor;
            newColor.a = alpha;
            objRenderer.material.color = newColor;
            yield return null;
        }

        // �t�F�[�h�A�E�g������ɃI�u�W�F�N�g���\���ɂ���
        gameObject.SetActive(false);
    }
}
