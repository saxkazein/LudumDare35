using System.Collections;

/**
 * 
 * Módulo que calcula las bonificaciones correspondientes
 * 
 */ 
public class ModuloBonificador {

	private float aumentoBonificacionResistenciaRobots;
	private float aumentoBonificacionCosteRobots;
	private float aumentoBonificacionMejoraTorreta;
	private float aumentoBonificacionMejoraAlimentos;
	private float aumentoBonificacionCostePoblacion;

	/**
	 * Método que realiza la inicialización del módulo
	 */ 
	public void Start (DatosConfiguracion datosConfig) {
		aumentoBonificacionResistenciaRobots = datosConfig.aumentoBonificacionMejoraResistenciaRobots;
		aumentoBonificacionCosteRobots = datosConfig.aumentoBonificacionMejoraCosteRobots;
		aumentoBonificacionMejoraTorreta = datosConfig.aumentoBonificacionMejoraTorreta;
		aumentoBonificacionMejoraAlimentos = datosConfig.aumentoBonificacionMejoraAlimentos;
		aumentoBonificacionCostePoblacion = datosConfig.aumentoBonificacionCostePorPoblacion;
	}


	/**
	 * Módulo que realiza los cálculos necesarios para las bonificaciones
	 */ 
	public void calcularTurno(DatosTurno datosTurno){
		
	}

}
