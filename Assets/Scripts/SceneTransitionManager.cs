using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration;

    void Awake()
    {
        // singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Dont destroy when going into new scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TransitionToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        yield return StartCoroutine(Fade(1)); // fade into black screen
        SceneManager.sceneLoaded += OnSceneLoaded;  // do OnLoadedScene on loaded scene
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // remove OnLoadedScene from loaded scene
        StartCoroutine(Fade(0));    // fade back
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float time = 0;


        while (time < fadeDuration)
        {
            time += Time.deltaTime; // increase time passed time (during a frame)
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration); // calculate new fadeImage.color.a value
            fadeImage.color = new Color(0, 0, 0, alpha);    // new Color to set color
            yield return null; // wait for a frame until next loop
        }
        fadeImage.color = new Color(0, 0, 0, targetAlpha);  // set image complete to targetAlpha
    }
}
