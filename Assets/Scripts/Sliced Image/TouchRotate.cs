using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TouchRotate : MonoBehaviour
{
    [SerializeField] private InputAction pressed, axis, screenPos;
    public Camera GameCamera;
    private Vector2 rotation;
    // private bool rotateAllowed;
    private Vector3 curScreenPos;

    private void Awake()
    {
        screenPos.performed += context => { curScreenPos = context.ReadValue<Vector2>(); };
		//pressed.performed += _ => { if(isClickedOn) StartCoroutine(Rotate()); };
        pressed.performed += _ => { Rotate(); };
        screenPos.Enable();
		pressed.Enable();
		// pressed.canceled += _ => { rotateAllowed = false; };
		axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
		axis.Enable();
    }

    private void Rotate(){
        Debug.Log("Rotating1");
        Vector3 mousePos = GameCamera.ScreenToWorldPoint(curScreenPos);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, LayerMask.GetMask("ImageUI"));

        if(hit.collider == null)
        {
            return;
        }
        var x = hit.collider.GetComponent<RotateSprite>();
        Debug.Log("Rotatin2: " + x);
        if(x)
        {
            x.Rotate();
        }
    }

    private void OnDisable()
    {
        screenPos.Disable();
        pressed.Disable();
        axis.Disable();
    }
}