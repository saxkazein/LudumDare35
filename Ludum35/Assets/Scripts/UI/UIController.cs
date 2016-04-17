using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIController : MonoBehaviour {

    //Control de la lógica de la interfaz

    //Necesitamos todos los 'Texts' de la interfaz
    
    //Panel superior
    private Text textoRecursos;
    private Text textoPoblacion;
    private Text textoRobots;

    //Modulo robots
    private Text textoNumBunker;
    private Text textoNumExpedicion;
    private Text textoNumEstacionesRestantes;

    //Modulo mejoras
    private Text textoRobotsMejora;
    private Text textoDefensaMejora;
    private Text textoComidaMejora;
    private Text textoProgramaEspacial;

    private Text textoTotalMejorasRobots;
    private Text textoTotalDefensaMejora;
    private Text textoTotalComidaMejora;
    private Text textoTotalProgramaEspacial;

    //Modulo construccion
    private Text textoTotalRobotsAumentar;
    private Text textoTotalComidaAumentar;

    private Text textoAumentarRobots;
    private Text textoAumentarAlimentos;


    //Variables de control
    private int numeroRobotsAContruir = 0;
    private int numeroComidaAConstruir = 0;

    private int nivelDeMejoraDefensasActual;
    private int nivelDeMejoraAlimentosActual;
    private int nivelDeMejoraRobotsActual;
    private int nivelDeMejoraCoheteActual;

    private int robotsEnBunker, robotsEnBunkerAux;
    private int robotsAExpedicion;
        //Auxiliares
    private int nivelMejoraDefensaAux;
    private int nivelMejoraAlimentosAux;
    private int nivelMejoraRobotsAux;
    private int nivelMejoraCoheteAux;


    private bool haSidoAccionTomada = false;
    private int accionTomada = -1;
    private bool seIniciaExpedicion = false;

    private int recursosActuales;

    private bool expedicionActiva;

    private int numNivelesMejoraAlimento;
    private int numNivelesMejoraRobots;
    private int numNivelesMejoraCohete;
    private int numNivelesMejoraDefensa;



    void Start()
    {
       //Panel superior
    textoRecursos = GameObject.Find("TextoRecursos").GetComponent<Text>();
    textoPoblacion = GameObject.Find("TextoPoblacion").GetComponent<Text>();
    textoRobots = GameObject.Find("TextoRobots").GetComponent<Text>();

    //Modulo robots
    textoNumBunker = GameObject.Find("TextoNumBunker").GetComponent<Text>();
    textoNumExpedicion = GameObject.Find("TextoNumExpedicion").GetComponent<Text>();
    textoNumEstacionesRestantes = GameObject.Find("TextoNumEstacionesLeft").GetComponent<Text>();

    //Modulo mejoras
    textoRobotsMejora = GameObject.Find("TextoImagenRobotsMejora").GetComponent<Text>();
    textoDefensaMejora = GameObject.Find("TextoImagenDefensaMejora").GetComponent<Text>();
    textoComidaMejora = GameObject.Find("TextoImagenFoodMejora").GetComponent<Text>();
    textoProgramaEspacial = GameObject.Find("TextoImagenProgramaEspacial").GetComponent<Text>();

    textoTotalMejorasRobots = GameObject.Find("TextoTotalMejoraRobots").GetComponent<Text>();
    textoTotalDefensaMejora = GameObject.Find("TextoTotalDefensaMejora").GetComponent<Text>();
    textoTotalComidaMejora = GameObject.Find("TextoTotalFoodMejora").GetComponent<Text>();
    textoTotalProgramaEspacial = GameObject.Find("TextoTotalProgramaEspacial").GetComponent<Text>();

    //Modulo construccion
    textoTotalRobotsAumentar = GameObject.Find("TextoImagenTotalRobotsAumentar").GetComponent<Text>();
    textoTotalComidaAumentar = GameObject.Find("TextoImagenTotalComidaAumentar").GetComponent<Text>();
   
    textoAumentarRobots = GameObject.Find("TextoAumentarRobots").GetComponent<Text>();
    textoAumentarAlimentos = GameObject.Find("TextoAumentarComida").GetComponent<Text>();

    
        

    }

    public void actualizaTurno(DatosTurno datosTurno) { 
        
        //Actualizamos todos los valores que nos pasan
        expedicionActiva = datosTurno.flagExpedicionActiva;


        //Panel superior
        textoRecursos.text = datosTurno.numeroRecursosInicial.ToString();
        textoPoblacion.text = datosTurno.numeroPoblacionInicial.ToString();
        textoRobots.text = datosTurno.numeroRobotsInicio.ToString();
    
        //Modulo robots
        textoNumBunker.text = datosTurno.numeroRobotsOrdenPublico.ToString();
        textoNumExpedicion.text = datosTurno.numeroRobotsExpedicion.ToString();

        if (expedicionActiva)
        {
            textoNumEstacionesRestantes.gameObject.SetActive(true);
            textoNumEstacionesRestantes.text = datosTurno.turnosRestantesExpedicion.ToString(); //No mostrar si 0
        }
        else {
            textoNumEstacionesRestantes.gameObject.SetActive(false);
            
        }
        //Modulo mejoras
        int nivelMejoraRoboticaInicialAux = datosTurno.nivelMejoraRoboticaInicial + 1;
        int nivelMejoraDefensaInicialAux = datosTurno.nivelMejoraDefensaInicial + 1;
        int nivelMejoraComidaInicialAux = datosTurno.nivelMejoraAlimentoInicial + 1;
        int nivelMejoraProframaEspacialAux = datosTurno.nivelMejoraCoheteInicial + 1;



        textoRobotsMejora.text = "Lv." + nivelMejoraRoboticaInicialAux.ToString();  
        textoDefensaMejora.text = "Lv." + nivelMejoraDefensaInicialAux.ToString();
        textoComidaMejora.text = "Lv." + nivelMejoraComidaInicialAux.ToString();
        textoProgramaEspacial.text = "Lv." + nivelMejoraProframaEspacialAux.ToString();

        textoTotalMejorasRobots.text = datosTurno.precioActualMejoraRobots.ToString();
        textoTotalDefensaMejora.text = datosTurno.precioActualMejoraDefensa.ToString();
        textoTotalComidaMejora.text = datosTurno.precioActualMejoraAlimentos.ToString();
        textoTotalProgramaEspacial.text = datosTurno.precioActualCohete.ToString();

        //Construccion
        textoTotalRobotsAumentar.text = datosTurno.precioActualRobot.ToString();
        textoTotalComidaAumentar.text = datosTurno.precioActualAlimento.ToString();

        //Variables
        nivelDeMejoraDefensasActual = datosTurno.nivelMejoraDefensaInicial;
        nivelDeMejoraAlimentosActual = datosTurno.nivelMejoraAlimentoInicial;
        nivelDeMejoraRobotsActual = datosTurno.nivelMejoraRoboticaInicial;
        nivelDeMejoraCoheteActual = datosTurno.nivelMejoraCoheteInicial;

            //Auxiliares
        nivelMejoraDefensaAux = nivelDeMejoraDefensasActual;
        nivelMejoraAlimentosAux = nivelDeMejoraAlimentosActual;
        nivelMejoraRobotsAux = nivelDeMejoraRobotsActual;
        nivelMejoraCoheteAux = nivelDeMejoraCoheteActual;

        robotsEnBunker = datosTurno.numeroRobotsInicio;
        robotsEnBunkerAux = robotsEnBunker;

        robotsAExpedicion = 0;

        recursosActuales = datosTurno.numeroRecursosInicial;

        numNivelesMejoraAlimento = Core.Instance.configuracion.costeBaseMejoraAlimento.Length;
        numNivelesMejoraCohete = Core.Instance.configuracion.costeBaseCohete.Length;
        numNivelesMejoraDefensa = Core.Instance.configuracion.costeBaseMejoraTorreta.Length;
        numNivelesMejoraRobots = Core.Instance.configuracion.costeBaseMejoraRobot.Length;


        
    }


    public void aumentarComida()
    {

        if (!haSidoAccionTomada || accionTomada == 0)
        {

            if (recursosActuales >= int.Parse(textoTotalComidaAumentar.text))
            {

                haSidoAccionTomada = true;
                accionTomada = 0;

                numeroComidaAConstruir++;
                textoAumentarAlimentos.text = numeroComidaAConstruir.ToString();
            }
            }
    }

    public void aumentarRobots() {

        if (!haSidoAccionTomada || accionTomada == 1)
        {
            if (recursosActuales >= int.Parse(textoTotalRobotsAumentar.text))
            {

                haSidoAccionTomada = true;
                accionTomada = 1;

                numeroRobotsAContruir++;
                textoAumentarRobots.text = numeroRobotsAContruir.ToString();
            }
        }
    }



    public void resetConstruccion()
    {

        if (haSidoAccionTomada && (accionTomada == 0 || accionTomada == 1))
        {

            haSidoAccionTomada = false;
            accionTomada = -1;

            numeroComidaAConstruir = 0;
            numeroRobotsAContruir = 0;

            textoAumentarRobots.text = "+1";
            textoAumentarAlimentos.text = "+1";
        }
    }

    public void mejoraComida()
    {

        if (!haSidoAccionTomada)
        {
            if (recursosActuales >= int.Parse(textoTotalComidaMejora.text))
            {
                if (nivelMejoraAlimentosAux == numNivelesMejoraAlimento)
                {
                    textoComidaMejora.text = "Max level";

                }
                else
                {

                    haSidoAccionTomada = true;
                    accionTomada = 2;


                    nivelMejoraAlimentosAux++;
                    textoComidaMejora.text = "Lv." + nivelMejoraAlimentosAux.ToString();
                }
                }
             }
    }

    public void mejoraDefensa()
    {

        if (!haSidoAccionTomada)
        {
            if (recursosActuales >= int.Parse(textoTotalDefensaMejora.text))
            {
                if (nivelMejoraDefensaAux == numNivelesMejoraDefensa)
                {
                    textoComidaMejora.text = "Max level";

                }
                else
                {

                    haSidoAccionTomada = true;
                    accionTomada = 3;

                    nivelMejoraDefensaAux++;
                    textoDefensaMejora.text = "Lv." + nivelMejoraDefensaAux.ToString();
                }
                     }
             }
    }

    public void mejoraRobots() {

        if (!haSidoAccionTomada)
        {
            if (recursosActuales >= int.Parse(textoRobotsMejora.text))
            {

                if (nivelMejoraRobotsAux == numNivelesMejoraRobots)
                {
                    textoComidaMejora.text = "Max level";

                }
                else
                {
                    haSidoAccionTomada = true;
                    accionTomada = 4;

                    nivelMejoraRobotsAux++;
                    textoRobotsMejora.text = "Lv." + nivelMejoraRobotsAux.ToString();
                }
                     }
             }
    }
 
 
    public void mejoraCohete() {

        if (!haSidoAccionTomada)
        {
            if (recursosActuales >= int.Parse(textoTotalProgramaEspacial.text))
            {
                if (nivelMejoraCoheteAux == numNivelesMejoraRobots)
                {
                    textoComidaMejora.text = "Max level";

                }
                else
                {

                    haSidoAccionTomada = true;
                    accionTomada = 5;

                    nivelMejoraCoheteAux++;
                    textoProgramaEspacial.text = "Lv." + nivelMejoraCoheteAux.ToString();
                }
                     }
             }
    }

    public void resetMejoras() {

        if (haSidoAccionTomada && (accionTomada == 2 || accionTomada == 3 || accionTomada == 4 || accionTomada == 5)) { 

            haSidoAccionTomada = false;
            accionTomada = -1;

            nivelMejoraAlimentosAux = nivelDeMejoraAlimentosActual;
            nivelMejoraCoheteAux = nivelDeMejoraCoheteActual;
            nivelMejoraDefensaAux = nivelDeMejoraDefensasActual;
            nivelMejoraRobotsAux = nivelDeMejoraRobotsActual;

            textoRobotsMejora.text = "Lv." + nivelMejoraRobotsAux.ToString();
            textoDefensaMejora.text = "Lv." + nivelMejoraDefensaAux.ToString();
            textoComidaMejora.text = "Lv." + nivelMejoraAlimentosAux.ToString();
            textoProgramaEspacial.text = "Lv." + nivelMejoraCoheteAux.ToString();
        }
    
    }


    public void pasarRobotsABunker() {

        if (!haSidoAccionTomada ||accionTomada == 6)
        {

            if (robotsAExpedicion > 0 && !expedicionActiva)
            {

                haSidoAccionTomada = true;
                accionTomada = 6;

                robotsEnBunkerAux++;
                robotsAExpedicion--;

                textoNumBunker.text = robotsEnBunkerAux.ToString();
                textoNumExpedicion.text = robotsAExpedicion.ToString();
            }
        }
    }

    public void pasarRobotsAExpedicion()
    {

        if (!haSidoAccionTomada || accionTomada == 6)
        {

            if (robotsEnBunkerAux > 0 && !expedicionActiva)
            {

                haSidoAccionTomada = true;
                accionTomada = 6;
                seIniciaExpedicion = true;

                robotsEnBunkerAux--;
                robotsAExpedicion++;

                textoNumBunker.text = robotsEnBunkerAux.ToString();
                textoNumExpedicion.text = robotsAExpedicion.ToString();
            }
        }

    }

    public void resetTraspaso() {

        if (haSidoAccionTomada && (accionTomada == 6))
        {
            haSidoAccionTomada = false;
            accionTomada = -1;
            seIniciaExpedicion = false;

            robotsEnBunkerAux = robotsEnBunker;
            robotsAExpedicion = 0;

            textoNumBunker.text = robotsEnBunkerAux.ToString();
            textoNumExpedicion.text = robotsAExpedicion.ToString();


        }

    }

    public DatosInterfaz siguienteTurno() {

        DatosInterfaz datos = new DatosInterfaz();

        //Modulo construccion
        datos.robotsNuevos = int.Parse(textoAumentarRobots.text);
        datos.alimentosNuevos = int.Parse(textoAumentarAlimentos.text);

        datos.accionTomada = accionTomada;
        datos.seIniciaExpedicion = seIniciaExpedicion;

        //Modulo robots
        datos.robotsEnBunker = int.Parse(textoNumBunker.text);
        datos.robotsAExpedicion = int.Parse(textoNumExpedicion.text);

        switch (accionTomada) { 
            
            case 0:
                datos.recursosGastados = int.Parse(textoTotalComidaAumentar.text) * numeroComidaAConstruir;
                break;

            case 1:
                datos.recursosGastados = int.Parse(textoTotalRobotsAumentar.text) * numeroRobotsAContruir;
                break;

            case 2:
                datos.recursosGastados = int.Parse(textoComidaMejora.text);
                break;

            case 3:
                datos.recursosGastados = int.Parse(textoDefensaMejora.text);
                break;

            case 4:
                datos.recursosGastados = int.Parse(textoRobotsMejora.text);
                break;

            case 5:
                datos.recursosGastados = int.Parse(textoProgramaEspacial.text);
                break;
        
        
        }

        return datos;

    
    }

    public void generaVentanaEmergenteSiNo(string texto, UnityAction accion){

        ModalPanel.Instance().Emergente(texto, accion);
    }

    public void generaVentanaEmergenteSlider(string texto, UnityAction<int> accion, int min, int max)
    {
        ModalPanel.Instance().Emergente(texto, accion, min, max);
    }

}
