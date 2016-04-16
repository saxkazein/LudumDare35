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
		numeroMaximoRecursoRecuperado = datosConfiguracion.recursosBasePorExpedicion;
		numeroMaximoCiudadanosRecuperados = datosConfiguracion.poblacionBasePorExpedicion;
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




			datosTurno.turnosDuracionExpedicionActiva--;
			if (datosTurno.turnosDuracionExpedicionActiva == 0) {			// Si se ha terminado la expedición
				datosTurno.flagExpedicionActiva = false;
			}
		}
	}
		
}
