using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField, Range(0, 5)] private float maxDistance = 2f;
    [SerializeField] private GameObject CollectButton;
    private Renderer selectionRenderer;
    public Color color, highlightColor;
    private Transform _selection;
    [SerializeField] private GameObject Joysticks;

    [SerializeField] private float selectionRadius = 5f; // new field to define selection radius
    private HashSet<Collider> highlightedObjects = new HashSet<Collider>(); // new hashset to keep track of highlighted objects

    // Update is called once per frame
    void Update()
    {
        CollectButton.SetActive(false);
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, LayerMask.GetMask("Selectable")))
        {
            _selection = hit.transform;
            selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer?.materials[1].SetFloat("_Alpha", 1);
            selectionRenderer?.materials[1].SetColor("_Color", highlightColor);
            CollectButton.SetActive(true);
        }
        else if (_selection != null)
        {
            selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.materials[1].SetColor("_Color", color);
            _selection = null;
        }

        // Check for objects in selection radius 
        Collider[] colliders = Physics.OverlapSphere(transform.position, selectionRadius);
        HashSet<Collider> newHighlightedObjects = new HashSet<Collider>(); // new hashset to keep track of new highlighted objects
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Selectable"))
            {
                if (!highlightedObjects.Contains(collider))
                {
                    Renderer renderer = collider.GetComponent<Renderer>();
                    renderer?.materials[1].SetFloat("_Alpha", 1);
                    renderer?.materials[1].SetColor("_Color", color);
                }
                newHighlightedObjects.Add(collider);
            }
        }
        // De-highlight objects that are no longer in the selection radius
        foreach (Collider collider in highlightedObjects)
        {
            if (!newHighlightedObjects.Contains(collider))
            {
                Renderer renderer = collider.GetComponent<Renderer>();
                renderer?.materials[1].SetFloat("_Alpha", 0);
            }
        }
        highlightedObjects = newHighlightedObjects;
    }

    void OnDrawGizmos()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.cyan);
        Gizmos.DrawWireSphere(transform.position, selectionRadius); // visualize selection radius
    }

    public void DestroyThis()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, LayerMask.GetMask("Selectable")))
        {
            BoxCollider bc = hit.collider as BoxCollider;
            if (bc != null)
            {
                Destroy(bc.gameObject);
                ObjectSpawner.itemCounter++;
            }
        }
    }
}