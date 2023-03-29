using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ExitMiniGame : MonoBehaviour
{
    public int SceneToUnload;

    public void ExitSceneButton()
    {
         SceneManager.UnloadSceneAsync(SceneToUnload);
    }
}
