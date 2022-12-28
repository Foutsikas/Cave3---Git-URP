using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButtonEnter : MonoBehaviour
{
    [SerializeField]
    Object SceneToLoad;
    [SerializeField] GameObject UI;

    public void EnterSceneButton()
    {
        SceneManager.LoadSceneAsync(SceneToLoad.name, LoadSceneMode.Additive);//LoadSceneMode.Additive);
        UI.SetActive(false);
    }
}