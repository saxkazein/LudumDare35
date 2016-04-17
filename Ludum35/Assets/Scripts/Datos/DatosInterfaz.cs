using UnityEngine;
using System.Collections;

public class DatosInterfaz  {


    //Modulo construccion
    public int robotsNuevos;
    public int alimentosNuevos;

    //Modulo mejoras
    public int accionTomada;
    public bool seIniciaExpedicion;

    //Modulo robots
    public int robotsEnBunker;
    public int robotsAExpedicion;
    public int estacionesRestantesActual;

    public DatosInterfaz()
    {
        robotsNuevos = 0;
        alimentosNuevos = 0;

        accionTomada = -1;
        seIniciaExpedicion = false;

        robotsEnBunker = 0;
        robotsAExpedicion = 0;
        estacionesRestantesActual = 0;

    }

    


}
