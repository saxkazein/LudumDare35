using System.Collections;

/**
 * 
 * Módulo para la gestión de la expedición.
 * 
 */ 
public class ModuloExpedicion {


	private int numeroRobotsExpedicion;
	private float bonificadorResistenciaRobot;
	private int turnosDuracionExpedicionActiva;
	private int recursosRecuperadosExpedicion;
	private int poblacionRecuperadaExpedicion;
	private int numeroRobotsPerdidosExpedicion;
	private bool flagExpedicionActiva;


	/**
	 *  Método para la inicialización del módulo
	 */ 
	public void Start(){
	}


	/**
	 * Módulo para realizar los cálculos necesarios para el cambio de turno
	 */ 
	public void calcularTurno(DatosConfiguracion datosConfig){
		if(flagExpedicionActiva==true){							// Si hay expedición activa




			turnosDuracionExpedicionActiva--;
			if (turnosDuracionExpedicionActiva == 0) {			// Si se ha terminado la expedición
				flagExpedicionActiva = false;
			}
		}
	}
		
}
