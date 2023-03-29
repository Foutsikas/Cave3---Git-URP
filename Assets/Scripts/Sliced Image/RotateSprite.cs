using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    public void Rotate()
    {
        transform.Rotate(Vector3.forward, -90f, Space.World);
    }
}
