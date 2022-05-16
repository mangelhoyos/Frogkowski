using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeBehaviour : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private bool fadeOnStart;
    [SerializeField] private float fadeSpeed = 0.5f;

    void Start()
    {
        if(fadeOnStart)
        {
            StartCoroutine(FadeOutCycle());
        }
    }

    public void FadeIn(string sceneName)
    {
        StartCoroutine(FadeInCycle(sceneName));
    }

    IEnumerator FadeInCycle(string sceneName)
    {
        float alpha = 0;
        while(canvasGroup.alpha != 1)
        {   
            canvasGroup.alpha = alpha;
            alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeOutCycle()
    {
        float alpha = 1;
        while(canvasGroup.alpha != 0)
        {   
            canvasGroup.alpha = alpha;
            alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }
}
