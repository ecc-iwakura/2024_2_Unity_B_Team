using System.Collections;
using UnityEngine;

public class FadeOutPrefab : MonoBehaviour
{
    public float fadeDuration = 1.5f; // フェードアウトにかかる時間（秒）

    private Renderer objRenderer;
    private Color originalColor;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
        if (objRenderer == null)
        {
            Debug.LogError("Rendererコンポーネントが見つかりません。");
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

        // フェードアウト完了後にオブジェクトを非表示にする
        gameObject.SetActive(false);
    }
}
