using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ConsoleLog : MonoBehaviour {

    private int i;      //Variable de control para el apilamiento de logs
    RectTransform rectTransform;    

    private Queue<string> logs;

    //Modificable desde editor
    private int logsMinimos; //Numero de logs a imprimir antes de que comiencen a apilarse
    private int logsMaximos; //Máximo número de logs almacenados en consola
    private float offsetDeCrecimiento; //Razón de crecimiento del RectTransform que aloja el texto


    void Start() {

        i = 0;

        rectTransform = this.GetComponent<RectTransform>();
        logs = new Queue<string>();

        GameObject consola = GameObject.Find("Consola");

      /*  consola.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        consola.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width/2, Screen.height/4);
        */

        //Nada de lo siguiente me gusta
      /*  this.GetComponent<Text>().fontSize = Mathf.RoundToInt((Screen.width * 11)/1280);       
*/
        logsMinimos = 4;
        logsMaximos = (Screen.width * 24) / 1080;
        offsetDeCrecimiento = (Screen.width * 23) / 1080;
    
        //Hasta aqui

    }


    //Imprime en la consola principal del juego logs de eventos y sucesos. 
    //IMPORTANTE: TODOS LOS LOS TIENEN QUE OCUPAR UNA LINEAS COMO MÍNIMO Y COMO MÁXIMO PARA QUE SE VISUALICE CORRECTAMENTE.
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

    private int x;

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
