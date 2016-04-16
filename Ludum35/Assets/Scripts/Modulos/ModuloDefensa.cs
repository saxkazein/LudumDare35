using UnityEngine;
using System.Collections;



public class ModuloDefensa {

    private int bonificadorTorreta;
    private int numeroTurno;

    private int numeroPoblacionPerdidaAtaque;

    private int ataqueBaseCambiaforma;

    void calculaEvento(DatosTurno datosTurno)
    {

        bonificadorTorreta = datosTurno.bonificadorTorretas;
        numeroTurno = datosTurno.numeroTurno;

        ataqueBaseCambiaforma = core.Configuracion.danoBasePatos;



        

    }

}
