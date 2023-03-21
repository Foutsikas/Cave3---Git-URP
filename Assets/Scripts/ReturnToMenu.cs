using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] public int SceneToLoad;
    // [SerializeField] public int ScenetoUnload;

    public void ReturnMenu()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
