using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButtonEnter : MonoBehaviour
{
    [SerializeField]
    Object SceneToLoad;
    private GameObject UI;
    private GameObject Joysticks;

    public void EnterSceneButton()
    {
        SceneManager.LoadSceneAsync(SceneToLoad.name, LoadSceneMode.Additive);//LoadSceneMode.Additive);
        UI.SetActive(false);
        Joysticks.SetActive(false);
    }

    public GameObject JoystickSet
    {
        set
        {
            Joysticks = value;
        }
    }

    public GameObject  InfoUI
    {
        set
        {
            UI = value;
        }
    }
}