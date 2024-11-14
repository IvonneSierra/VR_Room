using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateRetricle : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación en grados por segundo
    public float scaleSpeed = 1f;     // Velocidad de cambio de tamaño
    public float maxScale = 1f;       // Tamaño máximo
    public float minScale = 0.5f;     // Tamaño mínimo

    private bool scalingUp = true;

    void Update()
    {
        // Asegurarse de que la rotación esté aplicada correctamente
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Cambiar el tamaño del objeto
        float newScale = transform.localScale.x + (scalingUp ? scaleSpeed : -scaleSpeed) * Time.deltaTime;
        
        // Ajustar el tamaño y detectar el cambio de dirección
        if (newScale > maxScale)
        {
            newScale = maxScale;
            scalingUp = false;
        }
        else if (newScale < minScale)
        {
            newScale = minScale;
            scalingUp = true;
        }
        
        // Aplicar el nuevo tamaño
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}