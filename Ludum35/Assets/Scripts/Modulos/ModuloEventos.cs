using UnityEngine;
using System.Collections;

public class ModuloEventos
{

    float probabilidadAtaque;
    // Use this for initialization
    void Start()
    {
        probabilidadAtaque = Core.Instance.configuracion.probabilidadAtaquePatos;
    }

    // Update is called once per frame
    public void calculaTurno(ref DatosTurno datosTurno)
    {
        bool lanzaExpedicion = false;
        bool lanzaEncuentro = false;
        int tipoEncuentro = -1;
        if (datosTurno.flagExpedicionActiva)
        {
            int numTurnosRestantes;
            numTurnosRestantes = datosTurno.turnosRestantesExpedicion - 1;

            lanzaExpedicion = numTurnosRestantes <= 0;

            datosTurno.turnosRestantesExpedicion = numTurnosRestantes;
        }

        float rng = Random.Range(0f, 1f);

        if (rng < datosTurno.bonificadorInfiltracion)
        {
            lanzaEncuentro = true;
            tipoEncuentro = 0;
        }
        else
        {
            rng = Random.Range(0f, 1f);
            if (rng < probabilidadAtaque)
            {
                lanzaEncuentro = true;
                tipoEncuentro = 1;

            }
            else
            {
                lanzaEncuentro = true;
                int tiporng = Random.Range(2, 12);
                tipoEncuentro = tiporng;
            }
        }

        if (lanzaExpedicion)
        {
            Core.Instance.CalculaExpedicion();
        }
        if (lanzaEncuentro)
        {
            switch (tipoEncuentro)
            {
                case 0:
                    Core.Instance.CalculaInfiltracion();
                    break;
                case 1:
                    Core.Instance.CalculaAtaque();
                    break;
                default:
                    Core.Instance.CalculaEvento(tipoEncuentro);
                    break;
            }
        }
    }
}
