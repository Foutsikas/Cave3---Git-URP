using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    public GameObject UI;

    void OnDestroy()
    {
        if (!UI.activeInHierarchy)
        {
            UI.SetActive(true);
        }
    }
}
