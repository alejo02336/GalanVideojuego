using UnityEngine;
using System.Collections;

//Decompile by Si Borokokok

public class BillboardScript : MonoBehaviour
{
    public void Main()
    {
    }

    public void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(Vector3.left * -90);
    }
}

