using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (!GameControllerSlice.youWin)
            transform.Rotate(0, 0, -90);
    }
}