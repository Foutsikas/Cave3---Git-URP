using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInformation : MonoBehaviour
{
    [SerializeField] private string Name;
    [SerializeField] private string Info;
    [SerializeField] private Sprite Image;

    public string N_name
    {
        get { return this.Name; }

        set { this.Name = value; }
    }

    public string N_Info
    {
        get { return this.Info; }

        set { this.Info = value; }
    }

    public Sprite N_Image
    {
        get { return this.Image; }

        set { this.Image = value; }
    }
}
