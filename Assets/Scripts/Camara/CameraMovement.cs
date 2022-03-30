using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraMovement : MonoBehaviour {
 
    public Transform Target;
 
    public float Distancia = 10;
    public float Altura = 5;
    public float CambioDeAltura = 2;
    public float CambioDeRotacion = 0;
 
    public bool LookAtPlayer;
 
    void LateUpdate () {
        if (!Target)
            return;
 
        float RotacionDeseada = Target.eulerAngles.y;
        float AlturaDeseada = Target.position.y + Altura;
        float rotacionActual = transform.eulerAngles.y;
        float alturaActual = transform.position.y;
 
        rotacionActual = Mathf.LerpAngle(rotacionActual, RotacionDeseada, CambioDeRotacion * Time.deltaTime);
        alturaActual = Mathf.LerpAngle(alturaActual, AlturaDeseada, CambioDeAltura*Time.deltaTime);
 
        Quaternion rotacion = Quaternion.Euler(0,rotacionActual,0);
 
        transform.position = Target.position;
        transform.position -= rotacion * Vector3.forward * Distancia;
        transform.position = new Vector3(transform.position.x , alturaActual, transform.position.z);
        if(LookAtPlayer)
            transform.LookAt(Target);
    }
 
}