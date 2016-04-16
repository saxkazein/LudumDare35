using UnityEngine;
using System.Collections;

public class ModuloPoblacion  {


    private int poblacionInicial;
    private int numeroComidaInicial;
    private int bonificadorAlimentos;
    private int numeroComidaConsumida;
    private int numeroMuertesPorHambre;

    private Core core;

    //Cálculos referentes al control de población por turno
    void calculaTurno(ref DatosTurno datosTurno) {

        //Cargamos datos de archivo de configuracion
        float limiteInferior = core.configuracion.limiteInferiorPerdidaPorHambre;
        float limiteSuperior = core.configuracion.limiteSuperiorPerdidaPorHambre;

        //Población, bonificador y comida inicial del turno actual
        poblacionInicial = datosTurno.numeroPoblacionInicial;
        numeroComidaInicial = datosTurno.numeroComidaInicial;
        bonificadorAlimentos = datosTurno.bonificadorAlimentos;

        //////////////////////////


        numeroComidaConsumida =Mathf.RoundToInt((poblacionInicial / (core.configuracion.ciudadanosPorAlimentoTurno * bonificadorAlimentos)));

        //Si se consume más comida de la que se dispone
        if (numeroComidaInicial - numeroComidaConsumida < 0) {

           
            float probabilidadMuertes = Random.Range(core.configuracion.limiteInferiorPerdidaPorHambre, core.configuracion.limiteSuperiorPerdidaPorHambre + 1);

            numeroMuertesPorHambre = Mathf.RoundToInt((probabilidadMuertes * poblacionInicial) / 100);

        }



        //////////////////////////

        datosTurno.numeroComidaConsumida = numeroComidaConsumida;
        datosTurno.numeroMuertesPorHambre = numeroMuertesPorHambre;

    }

}
