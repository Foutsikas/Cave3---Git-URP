using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TouchRotate : MonoBehaviour
{
    [SerializeField] private InputAction pressed, axis, screenPos;
    public Camera GameCamera;
    private Vector2 rotation;
    private Vector3 curScreenPos;
    private bool isRotating = false; // Add a flag to prevent multiple rotations

    private void Awake()
    {
        screenPos.performed += context => { curScreenPos = context.ReadValue<Vector2>(); };
        pressed.performed += _ => { StartRotation(); };
        screenPos.Enable();
        pressed.Enable();
        axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
        axis.Enable();
    }

    private void StartRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateCoroutine());
        }
    }

    private IEnumerator RotateCoroutine()
    {
        isRotating = true;
        Debug.Log("Rotating1");
        Vector3 mousePos = GameCamera.ScreenToWorldPoint(curScreenPos);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, LayerMask.GetMask("ImageUI"));

        if (hit.collider != null)
        {
            var x = hit.collider.GetComponent<RotateSprite>();
            if (x)
            {
                x.Rotate();
            }
        }

        // Wait for a short duration to prevent multiple rotations on a single touch
        yield return new WaitForSeconds(0.2f); // Adjust the duration as needed

        isRotating = false;
    }

    private void OnDisable()
    {
        screenPos.Disable();
        pressed.Disable();
        axis.Disable();
    }
}
