using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class ModalPanel : MonoBehaviour
{

    public Text question;
    public Image iconImage;

    public Button botonSi;
    public Button botonNo;
    public Button botonOk;
    
    public Text cantidad;
    public Slider slider;
    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;

    private int valorSlider = 0;

    //Controla las ventanas emergentes
    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("Se necesita un Modal Panel activo en la escena");
        }

        return modalPanel;
    }

    //Primera sobrecarga del metodo emergente: crea una ventana con una pregunta, un boton de Si y un boton de No.
    public void Emergente(string question, UnityAction yesEvent, UnityAction noEvent)
    {

     
            modalPanelObject.SetActive(true);

            botonSi.onClick.RemoveAllListeners();
            botonSi.onClick.AddListener(yesEvent);
            botonSi.onClick.AddListener(ClosePanel);

            botonNo.onClick.RemoveAllListeners();
            botonNo.onClick.AddListener(noEvent);
            botonNo.onClick.AddListener(ClosePanel);

            this.question.text = question;

            this.iconImage.gameObject.SetActive(false);
            botonSi.gameObject.SetActive(true);
            botonNo.gameObject.SetActive(true);
            botonOk.gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
            cantidad.gameObject.SetActive(false);
     

        }

    //Segunda sobrecarga: crea una ventana emergente con una pregunta, un slider y un boton de confirmar
      public void Emergente(string question, UnityAction<int> confirmEvent, int min, int max){
            
            modalPanelObject.SetActive(true);
            

            botonOk.onClick.RemoveAllListeners();
            botonOk.onClick.AddListener(delegate { confirmEvent.Invoke(valorSlider); });
            botonOk.onClick.AddListener(ClosePanel);

            slider.value = 0;
            slider.minValue = min;
            slider.maxValue = max;

            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(cambiaValor);

            this.question.text = question;
            this.iconImage.gameObject.SetActive(false);
          
            botonOk.gameObject.SetActive(true);
            slider.gameObject.SetActive(true);
            cantidad.gameObject.SetActive(true);
            botonNo.gameObject.SetActive(false);
            botonSi.gameObject.SetActive(false);

           


    }

      //Tercera sobrecarga: crea una ventana emergente con un texto y un botón de aceptar
      public void Emergente(string question, UnityAction confirmEvent)
      {

          modalPanelObject.SetActive(true);


          botonOk.onClick.RemoveAllListeners();
          botonOk.onClick.AddListener(confirmEvent);
          botonOk.onClick.AddListener(ClosePanel);

          this.question.text = question;
          this.iconImage.gameObject.SetActive(false);

          botonOk.gameObject.SetActive(true);

          botonNo.gameObject.SetActive(false);
          botonSi.gameObject.SetActive(false);
          slider.gameObject.SetActive(false);
          cantidad.gameObject.SetActive(false);




      }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }

    void cambiaValor(float value) {

        valorSlider = Mathf.RoundToInt(value);
        cantidad.text = "Número de robots: " + valorSlider.ToString();
    }
}