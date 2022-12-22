using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField, Range(0,5)] private float maxDistance = 2.5f;
    [SerializeField] private Color color;

    private Transform _selection;

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance,LayerMask.GetMask("Selectable")))
        {
            _selection = hit.transform;
            Debug.Log("Selection: " + _selection);
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material.SetColor("_BaseColor", color);
            }
        }else if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.SetColor("_BaseColor", new Color(1, 1, 1, 1));
            _selection = null;
        }
    }

    void OnDrawGizmos() {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward , Color.cyan);
    }
}
