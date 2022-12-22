using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Test : MonoBehaviour
{
    private Renderer _Renderer;
    [SerializeField]
    private Color color;
    private void Awake() {
        _Renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        _Renderer.sharedMaterials[0].SetColor("_BaseColor", color);
    }
}
