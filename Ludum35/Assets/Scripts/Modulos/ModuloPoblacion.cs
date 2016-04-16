using UnityEngine;
using System.Collections;

public class ModuloPoblacion  {


    private int poblacionInicial;
    private int numeroComidaInicial;
    private int bonificadorAlimentos;
    private int numeroComidaConsumida;
    private int numeroMuertesPorHambre;


    //Cálculos referentes al control de población por turno
    void calculaTurno(ref DatosTurno datosTurno) {

        //Población, bonificador y comida inicial del turno actual
        poblacionInicial = datosTurno.numeroPoblacionInicial;
        numeroComidaInicial = datosTurno.numeroComidaInicial;
        bonificadorAlimentos = datosTurno.bonificadorAlimentos;

        //Cargamos datos de archivo de configuracion
        float limiteInferior = Core.Instance.configuracion.limiteInferiorPerdidaPorHambre;
        float limiteSuperior = Core.Instance.configuracion.limiteSuperiorPerdidaPorHambre;
        float ciudadanosPorAlimento = Core.Instance.configuracion.ciudadanosPorAlimentoTurno * bonificadorAlimentos;
        

        //////////////////////////


        numeroComidaConsumida = Mathf.RoundToInt((poblacionInicial / (ciudadanosPorAlimento * bonificadorAlimentos)));

        //Si se consume más comida de la que se dispone
        if (numeroComidaInicial - numeroComidaConsumida < 0) {

           
            float probabilidadMuertes = Random.Range(limiteInferior, limiteSuperior + 1);

            numeroMuertesPorHambre = Mathf.RoundToInt((probabilidadMuertes * poblacionInicial) / 100)* (numeroComidaInicial - numeroComidaConsumida);

        }



        //////////////////////////

        datosTurno.numeroComidaConsumida = numeroComidaConsumida;
        datosTurno.numeroMuertesPorHambre = numeroMuertesPorHambre;

    }

}
