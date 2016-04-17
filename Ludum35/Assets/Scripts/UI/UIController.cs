using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    private int robotsEnBunker;
    private int robotsAExpedicion;
        //Auxiliares
    private int nivelMejoraDefensaAux;
    private int nivelMejoraAlimentosAux;
    private int nivelMejoraRobotsAux;
    private int nivelMejoraCoheteAux;


    private bool haSidoAccionTomada = false;
    private int accionTomada = -1;
    private bool seIniciaExpedicion = false;

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

        //Panel superior
        textoRecursos.text = datosTurno.numeroRecursosInicial.ToString();
        textoPoblacion.text = datosTurno.numeroPoblacionInicial.ToString();
        textoRobots.text = datosTurno.numeroRobotsInicio.ToString();
    
        //Modulo robots
        textoNumBunker.text = datosTurno.numeroRobotsOrdenPublico.ToString();
        textoNumExpedicion.text = datosTurno.numeroRobotsExpedicion.ToString();
        textoNumEstacionesRestantes.text = datosTurno.turnosRestantesExpedicion.ToString(); //No mostrar si 0

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
        robotsAExpedicion = 0;
        
    }


    public void aumentarComida()
    {

        if (!haSidoAccionTomada || accionTomada == 0)
        {
            haSidoAccionTomada = true;
            accionTomada = 0;

            numeroComidaAConstruir++;
            textoAumentarAlimentos.text = numeroComidaAConstruir.ToString();
        }
    }

    public void aumentarRobots() {

        if (!haSidoAccionTomada || accionTomada == 1)
        {
            haSidoAccionTomada = true;
            accionTomada = 1;

            numeroRobotsAContruir++;
            textoAumentarRobots.text = numeroRobotsAContruir.ToString();
        }
    }



    public void resetConstruccion()
    {
        haSidoAccionTomada = false;
        accionTomada = -1;

        numeroComidaAConstruir = 0;
        numeroRobotsAContruir = 0;

        textoAumentarRobots.text = "+1";
        textoAumentarAlimentos.text = "+1";
    }

    public void mejoraComida()
    {

        if (!haSidoAccionTomada || accionTomada == 2)
        {
            haSidoAccionTomada = true;
            accionTomada = 2;


            nivelMejoraAlimentosAux++;
            textoComidaMejora.text = "Lv." + nivelMejoraAlimentosAux.ToString();
        }
    }

    public void mejoraDefensa()
    {

        if (!haSidoAccionTomada || accionTomada == 3)
        {
            haSidoAccionTomada = true;
            accionTomada = 3;

            nivelMejoraDefensaAux++;
            textoDefensaMejora.text = "Lv." + nivelMejoraDefensaAux.ToString();
        }
    }

    public void mejoraRobots() {

        if (!haSidoAccionTomada || accionTomada == 4)
        {
            haSidoAccionTomada = true;
            accionTomada = 4;

            nivelMejoraRobotsAux++;
            textoRobotsMejora.text = "Lv." + nivelMejoraRobotsAux.ToString();
        }
    }
 
 
    public void mejoraCohete() {

        if (!haSidoAccionTomada || accionTomada == 5)
        {
            haSidoAccionTomada = true;
            accionTomada = 5;

            nivelMejoraCoheteAux++;
            textoProgramaEspacial.text = "Lv." + nivelMejoraCoheteAux.ToString();
        }
    }

    public void resetMejoras() {

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


    public void pasarRobotsABunker() {

        if (!haSidoAccionTomada ||accionTomada == 6)
        {
            haSidoAccionTomada = true;
            accionTomada = 6;

            robotsEnBunker++;
            robotsAExpedicion--;

            textoNumBunker.text = robotsEnBunker.ToString();
            textoNumExpedicion.text = robotsAExpedicion.ToString();
        }
    }

    public void pasarRobotsAExpedicion()
    {

        if (!haSidoAccionTomada || accionTomada == 6)
        {
            haSidoAccionTomada = true;
            accionTomada = 6;
            seIniciaExpedicion = true;

            robotsEnBunker--;
            robotsAExpedicion++;

            textoNumBunker.text = robotsEnBunker.ToString();
            textoNumExpedicion.text = robotsAExpedicion.ToString();
        }

    }

    public DatosInterfaz siguienteTurno() {

        DatosInterfaz datos = new DatosInterfaz();

        //Modulo construccion
        datos.robotsNuevos = int.Parse(textoAumentarRobots.text);
        datos.alimentosNuevos = int.Parse(textoAumentarAlimentos.text);

        //Necesita recursos que se han gastado y el tipo de construccion
        datos.accionTomada = accionTomada;
        datos.seIniciaExpedicion = seIniciaExpedicion;

      

        //Modulo robots
        datos.robotsEnBunker = int.Parse(textoNumBunker.text);
        datos.robotsAExpedicion = int.Parse(textoNumExpedicion.text);


        return datos;

    
    }

}
