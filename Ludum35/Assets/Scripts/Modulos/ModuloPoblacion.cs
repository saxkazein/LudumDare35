using UnityEngine;
using System.Collections;

public class ModuloPoblacion  {


    private int poblacionInicial;
    private int numeroComidaInicial;
    private int bonificadorAlimentos;
    private int numeroComidaConsumida;
    private int numeroMuertesPorHambre;

    //Cálculos referentes al control de población por turno
    void calculaTurno(DatosTurno datosTurno) {

        //Población, bonificador y comida inicial del turno actual
        poblacionInicial = datosTurno.numeroPoblacionInicial;
        numeroComidaInicial = datosTurno.numeroComidaInicial;
        bonificadorAlimentos = datosTurno.bonificadorAlimentos;

        //////////////////////////


        numeroComidaConsumida = (poblacionInicial / (core.Configuracion.ciudadanosPorAlimentoTurno * bonificadorAlimentos));

        //Si se consume más comida de la que se dispone
        if (numeroComidaInicial - numeroComidaConsumida < 0) {

            int probabilidadMuertes = Random.Range(core.Configuracion.limiteInferiorPerdidaPorHambre, core.configuracion.limiteSuperiorPerdidaPorHambre + 1);

            numeroMuertesPorHambre = (probabilidadMuertes * poblacionInicial) / 100;

        }



        //////////////////////////

        datosTurno.numeroComidaConsumida = numeroComidaConsumida;
        datosTurno.numeroMuertesPorHambre = numeroMuertesPorHambre;

    }

}
