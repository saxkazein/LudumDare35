using UnityEngine;
using System.Collections;



public class ModuloDefensa {

    private int bonificadorTorreta;
    private int numeroTurno;
    private int numeroPoblacionInicial;
    private int numeroPoblacionPerdidaAtaque;

    private float ataqueBaseCambiaforma;
    private float aumentoDanoPatosPorTurno;
    private float varianzaDanoPatos;
    private float defensaDeTorreta;
    private float porcentajeDanoPoblacion;

    private Core core;

    //Cálculos referentes a un evento de ataque por parte de los patos
    void calculaEvento(ref DatosTurno datosTurno)
    {
        //Recuperamos datos de archivo de configuración
        ataqueBaseCambiaforma = core.configuracion.danoBasePatos;
        aumentoDanoPatosPorTurno = core.configuracion.aumentoDanoPatosPorTurno;
        varianzaDanoPatos = core.configuracion.varianzaDanoPatos;
        defensaDeTorreta = core.configuracion.defensaTorreta;
        porcentajeDanoPoblacion = core.configuracion.porcentajeDanoPoblacion;

        //Recuperamos datos del turno actual
        bonificadorTorreta = datosTurno.bonificadorTorretas;
        numeroTurno = datosTurno.numeroTurno;

        //Calculamos el daño infligido por los patos
        float varianzaDanoFinal = Random.Range(-varianzaDanoPatos, varianzaDanoPatos + 1)/100;
        float danoFijo = ataqueBaseCambiaforma + (numeroTurno * aumentoDanoPatosPorTurno);

        int danoFinalDePatos = Mathf.RoundToInt(danoFijo + ( danoFijo * varianzaDanoFinal));

        int cantidadDefensa = Mathf.RoundToInt(bonificadorTorreta * defensaDeTorreta);

        //Calculamos resultado final del intercambio
        int resultadoIntercambio = cantidadDefensa - danoFinalDePatos;

        if (resultadoIntercambio < 0)   //Si el intercambio ha resultado negativo para las defensas se sufren daños en la población
        {

            datosTurno.numeroPoblacionPerdidaAtaque = Mathf.RoundToInt( Mathf.Abs(resultadoIntercambio) * porcentajeDanoPoblacion * numeroPoblacionInicial);

        }

    }

}
