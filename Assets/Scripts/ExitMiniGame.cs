using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ExitMiniGame : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressText;

    public void UnloadLevel (string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously (string sceneName)
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneName);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = (progress * 100f) + "%";

            yield return null;
        }
    }
}
