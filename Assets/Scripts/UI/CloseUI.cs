using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    public GameObject UI;
    private GameObject Joysticks;
    public void CloseUIButton()
    {
        UI.SetActive(false);
        Joysticks.SetActive(true);
    }

    public GameObject JoystickSet
    {
        set
        {
            Joysticks = value;
        }
    }
}
