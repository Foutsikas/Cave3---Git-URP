using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TouchRotate : MonoBehaviour
{
    [SerializeField] private InputAction pressed, axis;
    private Vector2 rotation;
    private bool rotateAllowed;

    private void Awake()
    {
        pressed.Enable();
        axis.Enable();
        pressed.performed += _ => { StartCoroutine(Rotate()); };
        pressed.canceled += _ => { rotateAllowed = false; };
        axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
    }

    private IEnumerator Rotate()
    {
        rotateAllowed = true;
        if (rotateAllowed)
        {
            transform.Rotate(Vector3.forward, this.rotation.x + 90f);
            yield return null;
        }
    }
}