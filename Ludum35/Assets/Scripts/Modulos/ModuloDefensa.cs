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


    //Cálculos referentes a un evento de ataque por parte de los patos
    public void calculaEvento(ref DatosTurno datosTurno)
    {


        //Recuperamos datos del turno actual
		bonificadorTorreta = Mathf.RoundToInt(datosTurno.bonificadorTorretas);
        numeroTurno = datosTurno.numeroTurno;

        //Recuperamos datos de archivo de configuración
        ataqueBaseCambiaforma = Core.Instance.configuracion.danoBasePatos;
        aumentoDanoPatosPorTurno = Core.Instance.configuracion.aumentoDanoPatosPorTurno;
        varianzaDanoPatos = Core.Instance.configuracion.varianzaDanoPatos;
        defensaDeTorreta = Core.Instance.configuracion.defensaTorreta;
        porcentajeDanoPoblacion = Core.Instance.configuracion.porcentajeDanoPoblacion;


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
