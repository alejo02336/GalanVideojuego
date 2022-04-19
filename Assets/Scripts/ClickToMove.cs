using UnityEngine;
using System.Collections;

//Decompile by Si Borokokok

public class ClickToMove : MonoBehaviour
{
    public int smooth;
    private Vector3 targetPosition;

    public void Main()
    {
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter = 0;
            if (plane.Raycast(ray, out enter))
            {
                Vector3 point = ray.GetPoint(enter);
                targetPosition = ray.GetPoint(enter);
                Quaternion quaternion = Quaternion.LookRotation(point - transform.position);
                transform.rotation = quaternion;
            }
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
    }
}

