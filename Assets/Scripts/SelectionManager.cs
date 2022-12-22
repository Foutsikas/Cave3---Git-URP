using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField, Range(0,5)] private float maxDistance = 2f;
    private Renderer selectionRenderer;
    private Material tempMat;

    private Transform _selection;

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, LayerMask.GetMask("Selectable")))
        {
            _selection = hit.transform;
            selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.materials[1].SetFloat("_Alpha", 1);
            }
        }else if (_selection != null)
        {
            selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.materials[1].SetFloat("_Alpha", 0);
            _selection = null;
        }
    }

    void OnDrawGizmos() {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward , Color.cyan);
    }
}
