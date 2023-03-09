using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButtonEnter : MonoBehaviour
{
    [SerializeField] public int SceneToLoad;
    [SerializeField] GameObject Info_UI;
    // private GameObject Joysticks;

    public void EnterSceneButton()
    {
        SceneManager.LoadSceneAsync(SceneToLoad, LoadSceneMode.Additive);//LoadSceneMode.Additive);
        Info_UI.SetActive(false);
        // Joysticks.SetActive(false);
    }

    // public GameObject JoystickSet
    // {
    //     set
    //     {
    //         Joysticks = value;
    //     }
    // }
}