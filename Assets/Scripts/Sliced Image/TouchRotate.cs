using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameControllerSlice.youWin)
            transform.Rotate(0f, 0f, -90);
    }
}