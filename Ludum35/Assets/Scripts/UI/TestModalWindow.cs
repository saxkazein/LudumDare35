using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class TestModalWindow : MonoBehaviour
{
    private ModalPanel modalPanel;


    private UnityAction accionSi;
    private UnityAction accionNo;
    private UnityAction accionAceptar;

    private UnityAction<int> accionOk;


    //EJEMPLO DE USO DE VENTANA EMERGENTE
    void Awake()
    {
        modalPanel = ModalPanel.Instance();

        accionSi = new UnityAction(TestFuncionSi);
        accionNo = new UnityAction(TestFuncionNo);
        accionOk = new UnityAction<int>(TestFuncionOk);
        accionAceptar = new UnityAction(TestFuncionAceptar);


    }

   
    public void TestYNC(string pregunta)
    {
        modalPanel.Emergente("¿Deseas aceptar a estas personas en tu refugio?", accionSi, accionNo);
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.J))
        {

            modalPanel.Emergente("Deseas aceptar a estas personas?", accionSi, accionNo);

        }
        else if (Input.GetKeyDown(KeyCode.K))
        {

            modalPanel.Emergente("Cuantos robots quieres destinar?", accionOk, 0, 25);

        }
        else if (Input.GetKeyDown(KeyCode.L))
        {

            modalPanel.Emergente("Tus robots han desubierto su lado sexy y se estan untando aceite. Has perdido 20 robots", accionAceptar);

        }
    }

    void TestFuncionSi()
    {
        Debug.Log("YES");
    }

    void TestFuncionNo()
    {
        Debug.Log("NO");
    }
    void TestFuncionAceptar()
    {
        Debug.Log("MMM VENGA OC");
    }

    void TestFuncionOk(int valor)
    {
        
        Debug.Log("OK" + valor.ToString());
    }


}