using UnityEngine;
using System.Collections;

public class DatosInterfaz  {


    //Modulo construccion
    public int robotsNuevos;
    public int alimentosNuevos;

    //Modulo mejoras
    public int nivelMejoraDefensaAlcanzado;
    public int nivelMejoraAlimentoAlcanzado;
    public int nivelMejoraRobotsAlcanzado;
    public int nivelMejoraCoheteAlcanzado;

    //Modulo robots
    public int robotsEnBunker;
    public int robotsAExpedicion;
    public int estacionesRestantesActual;

    public DatosInterfaz()
    {
        robotsNuevos = 0;
        alimentosNuevos = 0;

        nivelMejoraAlimentoAlcanzado = 0;
        nivelMejoraCoheteAlcanzado = 0;
        nivelMejoraDefensaAlcanzado = 0;
        nivelMejoraRobotsAlcanzado = 0;

        robotsEnBunker = 0;
        robotsAExpedicion = 0;
        estacionesRestantesActual = 0;

    }

    


}
