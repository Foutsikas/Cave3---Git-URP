using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    public void Rotate()
    {
                // rotation *= speed;
        transform.Rotate(Vector3.forward * 90f, Space.World);
                // transform.Rotate(-cam.forward, rotation.y + 90f, Space.World);
                // yield return null;
    }
}
