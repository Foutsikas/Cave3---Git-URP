using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    private GameObject UI;

    void OnAwake()
    {
        GetComponent<SceneButtonEnter>().InfoUI = UI;
    }
}
