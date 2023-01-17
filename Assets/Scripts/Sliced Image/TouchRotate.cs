using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TouchRotate : MonoBehaviour
{
    [SerializeField] private InputAction pressed, axis, screenPos;
    private Transform cam;
    private Vector2 rotation;
    private bool rotateAllowed;
    private Vector3 curScreenPos;

    private bool isClickedOn
	{
		get
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(curScreenPos);
                            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                            if (hit.collider != null)
                            {
                                Debug.Log("Clicked");
                                return hit.collider.gameObject == this;
                            }else{
                                  return false;
                            }
		}
	}

    private void Awake()
    {
        cam = Camera.main.transform;
        screenPos.performed += context => { curScreenPos = context.ReadValue<Vector2>(); };
		//pressed.performed += _ => { if(isClickedOn) StartCoroutine(Rotate()); };
        pressed.performed += _ => { Rotate(); };
        screenPos.Enable();
		pressed.Enable();
		pressed.canceled += _ => { rotateAllowed = false; };
		axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
		axis.Enable();
    }


    private void Rotate(){
        Debug.Log("Rotating");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(curScreenPos);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, LayerMask.GetMask("ImageUI"));

        if(hit.collider == null)
            return;
        var x = hit.collider.GetComponent<RotateSprite>();
        if(x)
         x.Rotate();
    }
}