using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] public int SceneToLoad, SceneToUnload;

    public void ReturnMenu()
    {
        ObjectSpawner.itemCounter = 0; // reset the value of itemCounter
        SceneManager.UnloadSceneAsync(SceneToUnload);
        SceneManager.LoadScene(SceneToLoad);
        Time.timeScale = 1;
    }
}
