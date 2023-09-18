using System.Collections;
using UnityEngine;
using SingleApp;
using UnityEngine.SceneManagement;
public class SceneLoader : PersistentSingleton<SceneLoader>
{
    public GameObject loadingScreen;
    public CanvasGroup canvasGroup;
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame(string sceneName)
    {
        StartCoroutine(StartLoad(sceneName));
    }
    
    IEnumerator StartLoad(string sceneName)
    {
        loadingScreen.SetActive(true);
        yield return StartCoroutine(FadeLoadingScreen(1, 1));
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }
        yield return StartCoroutine(FadeLoadingScreen(0, 1));
        loadingScreen.SetActive(false);
    }
    IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }
}
