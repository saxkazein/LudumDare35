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
		
	}


	/**
	 * Módulo para realizar los cálculos necesarios para el cambio de turno
	 */ 
	public void calcularTurno(ref DatosTurno datosTurno){
		if(datosTurno.flagExpedicionActiva==true){							// Si hay expedición activa
			
			if (datosTurno.turnosRestantesExpedicion == 0) {			// Si se ha terminado la expedición
				datosTurno.flagExpedicionActiva = false;

				// Se calcula la muerte de los robots
				float muerteRobot = 0;
				for (int i=0;i<Mathf.RoundToInt(datosTurno.numeroRobotsExpedicion*maximoPorcentajeMuertesRobots);i++) {
					muerteRobot = Random.Range (0F, 1F);
					if(muerteRobot < posibilidadMuerteRobot-datosTurno.bonificadorResistenciaRobot)
						datosTurno.numeroRobotsPerdidosExpedicion++;
				}


				for(int i=0;i<datosTurno.numeroRobotsExpedicion-datosTurno.numeroRobotsPerdidosExpedicion;i++){
					
					// Número de recursos recuperados
					datosTurno.recursosRecuperadosExpedicion += Random.Range(0,numeroMaximoRecursoRecuperado);	

					// Número de población reclutada
					int ciudadanosReclutados = Random.Range(0,numeroMaximoCiudadanosRecuperados);
					datosTurno.poblacionRecuperadaExpedicion += ciudadanosReclutados;

					// Número de cambiaformas reclutados
					for(int j=0;j<Mathf.RoundToInt(ciudadanosReclutados*maximoPorcentajeCambiaformas);j++){
						if (Random.Range (0F, 1F) < posibilidadCambiaformas) {
							datosTurno.numeroCambiaformasInicial++;
						}
					}
				}


		}

		datosTurno.turnosRestantesExpedicion--;
	}
		
}
