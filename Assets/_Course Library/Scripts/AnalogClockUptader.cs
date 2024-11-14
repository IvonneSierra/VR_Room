using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClockUptader : MonoBehaviour
{
    public GameObject Clock_Analog_A_Hour;
    public GameObject Clock_Analog_A_Minute;
    public GameObject Clock_Analog_A_Second;

    public int Hora;
    public int Minuto;
    public int Segundo;

    // Start is called before the first frame update
   /* void Start()
    {
     
    }*/

    // Update is called once per frame
    void Update()
    {
        Hora = System.DateTime.Now.Hour;
        Minuto = System.DateTime.Now.Minute;
        Segundo = System.DateTime.Now.Second;

        ActulizarManecillas();
    }

    void ActulizarManecillas() 
    {
        // Calcula el ángulo para los segundos (360 grados / 60 segundos = 6 grados por segundo)
        float segundoAngulo = Segundo * 6f;
        Clock_Analog_A_Second.transform.eulerAngles = new Vector3(segundoAngulo, 0, 0);

        // Calcula el ángulo para los minutos (360 grados / 60 minutos = 6 grados por minuto)
        // También toma en cuenta los segundos para ajustar la posición de la manecilla de minutos
        float minutoAngulo = Minuto * 6f + (Segundo / 10f);
        Clock_Analog_A_Minute.transform.eulerAngles = new Vector3(minutoAngulo, 0, 0);

        // Calcula el ángulo para las horas (360 grados / 12 horas = 30 grados por hora)
        // También toma en cuenta los minutos y segundos para ajustar la posición de la manecilla de horas
        float horaAngulo = (Hora % 12) * 30f + (Minuto / 2f) + (Segundo / 120f);
        Clock_Analog_A_Hour.transform.eulerAngles = new Vector3(horaAngulo, 0, 0);
    }
}
