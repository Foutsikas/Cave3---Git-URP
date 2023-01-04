using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    private GameObject UI;
    public void CloseUIButton()
    {
        GetComponent<SceneButtonEnter>().InfoUI = UI;
        UI.SetActive(false);
    }
}
