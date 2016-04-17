using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ConsoleLog : MonoBehaviour {

    private int i;
    RectTransform rectTransform;    

    private Queue<string> logs;

    public int logsMinimos; //Numero de logs a imprimir antes de que comiencen a apilarse
    public int logsMaximos; //Máximo número de logs almacenados en consola
    public float offsetDeCrecimiento; //Razón de crecimiento del RectTransform que aloja el texto


    void Start() {
        i = 0;
        logsMinimos = 1;
        logsMaximos = 25;
        offsetDeCrecimiento = 32.0f;
        rectTransform = this.GetComponent<RectTransform>();
        logs = new Queue<string>();
    }


    //Imprime en la consola principal del juego logs de eventos y sucesos. 
    //IMPORTANTE: TODOS LOS LOS TIENEN QUE OCUPAR DOS LINEAS COMO MÍNIMO Y COMO MÁXIMO PARA QUE SE VISUALICE CORRECTAMENTE.
    void imprimirEnConsola(string toPrint) {

       
        logs.Enqueue(toPrint);
        
        Rect temp = this.GetComponent<RectTransform>().rect;
        this.GetComponent<Text>().text = "";

        foreach (string log in logs)
        {
            this.GetComponent<Text>().text += "\n" + log +"\n";

        }
      

        if (i > logsMinimos && i < logsMaximos)
        {
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, rectTransform.offsetMax.y + offsetDeCrecimiento);
            i++;
        }
        else if (i == logsMaximos)  //Cuando se alcanza el número máximo de logs se empieza a sobreescribir
        {
            logs.Dequeue();
        }
        else
        {
            i++;
        }

        GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 0.0f;

            
    }

    public int x = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            x++;
            imprimirEnConsola("Hola compañero! Que tal estas como andamos bien ok pues nada aqui estamos" + x.ToString());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            x++;
            imprimirEnConsola("Muy mal, pero hacemos lo que podemos Muy mal, pero hacemos lo que podemo Muy mal, pero hacemos lo que podemoss" + x.ToString());

        }
        
    }
}
