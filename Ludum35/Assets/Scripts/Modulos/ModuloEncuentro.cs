using UnityEngine;
using System.Collections;

public class ModuloEncuentro
{

    float[] tipo2;
    float[] tipo3;
    float[] tipo4;
    float[] tipo5;
    float[] tipo6;
    float[] tipo7;
    float[] tipo8;
    float[] tipo9;
    float[] tipo10;
    float[] tipo11;
    float[] tipo12;

    void Start()
    {

        tipo2 = new float[4] { 0f, 0f, 0f, 0f };
        tipo3 = new float[4] { 0f, 0f, 0f, 0f };
        tipo4 = new float[4] { 0f, 0f, 0f, 0f };
        tipo5 = new float[4] { 0f, 0f, 0f, 0f };
        tipo6 = new float[4] { 0f, 0f, 0f, 0f };
        tipo7 = new float[4] { 0f, 0f, 0f, 0f };
        tipo8 = new float[4] { 0f, 0f, 0f, 0f };
        tipo9 = new float[4] { 0f, 0f, 0f, 0f };
        tipo10 = new float[4] { 0f, 0f, 0f, 0f };
        tipo11 = new float[4] { 0f, 0f, 0f, 0f };
        tipo12 = new float[4] { 0f, 0f, 0f, 0f };

    }

    public void calculaEvento(ref DatosTurno datosTurno)
    {
        int numTipo = datosTurno.tipoEncuentro;
        float[] afeccion = { 0f, 0f, 0f, 0f };
        switch (numTipo)
        {
            case 2:
                afeccion = tipo2;
                break;
            case 3:
                afeccion = tipo3;
                break;
            case 4:
                afeccion = tipo4;
                break;
            case 5:
                afeccion = tipo5;
                break;
            case 6:
                afeccion = tipo6;
                break;
            case 7:
                afeccion = tipo7;
                break;
            case 8:
                afeccion = tipo8;
                break;
            case 9:
                afeccion = tipo9;
                break;
            case 10:
                afeccion = tipo10;
                break;
            case 11:
                afeccion = tipo11;
                break;
            case 12:
                afeccion = tipo12;
                break;
            default:
                break;
        }
        int numeroPoblacionEncuentro = Mathf.RoundToInt(datosTurno.numeroPoblacionInicial * afeccion[3]);
        int numeroRobotsEncuentro = Mathf.RoundToInt(datosTurno.numeroRobotsInicio * afeccion[2]);
        int numeroAlimentosEncuentro = Mathf.RoundToInt(datosTurno.numeroComidaInicial * afeccion[1]);
        int numeroRecursosEncuentro = Mathf.RoundToInt(datosTurno.numeroRecursosInicial * afeccion[0]);

        datosTurno.numeroRecursosEncuentro = numeroRecursosEncuentro;
        datosTurno.numeroPoblacionEncuentro = numeroPoblacionEncuentro;
        datosTurno.numeroRobotsEncuentro = numeroRobotsEncuentro;
        datosTurno.numeroComidaEncuentro = numeroAlimentosEncuentro;
    }
}
