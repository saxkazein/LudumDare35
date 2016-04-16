using UnityEngine;
using System.Collections;

/**
 * 
 * Módulo para la gestión de la expedición.
 * 
 */
public class ModuloExpedicion {


	private int numeroMaximoRecursoRecuperado;
	private int numeroMaximoCiudadanosRecuperados;
	private float posibilidadCambiaformas;
	private float maximoPorcentajeCambiaformas;
	private float posibilidadMuerteRobot;
	private float maximoPorcentajeMuertesRobots;
	private float bonificadorPorTurnosRecurso;



	/**
	 *  Método para la inicialización del módulo
	 */ 
	public void Start(DatosConfiguracion datosConfiguracion){
		numeroMaximoRecursoRecuperado = Mathf.RoundToInt(datosConfiguracion.recursosBasePorExpedicion);
		numeroMaximoCiudadanosRecuperados = Mathf.RoundToInt(datosConfiguracion.poblacionBasePorExpedicion);
		posibilidadCambiaformas = datosConfiguracion.probabilidadInfiltradoExpedicion;
		maximoPorcentajeCambiaformas = datosConfiguracion.maximoPorcentajeInfiltradoExpedicion;
		posibilidadMuerteRobot = datosConfiguracion.probabilidadBasePerderRobotExpedicion;
		maximoPorcentajeMuertesRobots = datosConfiguracion.maximoPorcentajePerdidasRobotExpedicion;
		bonificadorPorTurnosRecurso = datosConfiguracion.aumentoRecompensaExpedicionPorTurnos;
	}


	/**
	 * Módulo para realizar los cálculos necesarios para el cambio de turno
	 */ 
	public void calcularEvento(ref DatosTurno datosTurno){
        int numeroRobotsPerdidos = 0;
        int numeroPoblacionRecuperada = 0;
        int numeroCambiaformasRecuperados = 0;
        int numeroRecursosRecuperados = 0;

        float bonificadorTurnos = Mathf.Log(datosTurno.turnosDuracionExpedicionActiva * bonificadorPorTurnosRecurso);

        float rng = 0;
        int muerte = 0;
        int recurso = 0;
        int poblador = 0;
        int limit = Mathf.RoundToInt(datosTurno.numeroRobotsExpedicion*maximoPorcentajeMuertesRobots);
        for(int i = 0; i <= datosTurno.numeroRobotsExpedicion; i++)
        {
            rng = Random.Range(0f, 1f);
            recurso += Mathf.RoundToInt(rng * (numeroMaximoRecursoRecuperado * bonificadorTurnos));
            poblador += Mathf.RoundToInt(rng * (numeroMaximoCiudadanosRecuperados*bonificadorTurnos));
            if (rng <= posibilidadMuerteRobot - datosTurno.bonificadorResistenciaRobot)
            {
               muerte++;
            }
        }

        numeroRobotsPerdidos = muerte > limit ? -limit : -muerte;
        numeroPoblacionRecuperada = poblador;
        numeroRecursosRecuperados = recurso;

        int cambiaforma = 0;
        limit = Mathf.RoundToInt(poblador * maximoPorcentajeCambiaformas);
        for(int i = 0; i <= poblador; i++)
        {
            rng = Random.Range(0f, 1f);
            if (rng <= posibilidadCambiaformas)
            {
                cambiaforma++;
            }
            if (cambiaforma > limit)
                break;
        }
        numeroCambiaformasRecuperados = cambiaforma;

        //Desactivamos expedicion
        datosTurno.flagExpedicionActiva = false;
        datosTurno.numeroRobotsExpedicion = 0;
        datosTurno.turnosDuracionExpedicionActiva = 0;

        datosTurno.recursosRecuperadosExpedicion = numeroRecursosRecuperados;
        datosTurno.poblacionRecuperadaExpedicion = numeroPoblacionRecuperada;
        datosTurno.numeroRobotsPerdidosExpedicion = numeroRobotsPerdidos;
        datosTurno.numeroCambiaformasRecuperadosExpedicion = numeroCambiaformasRecuperados;
	}
}


