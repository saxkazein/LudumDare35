using UnityEngine;
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

    private float pBaseInfiltracion;
    private float aumentoInfiltracion;
    private int ciudadanosPorRobot;

	/**
	 * Método que realiza la inicialización del módulo
	 */ 
	public void Start (DatosConfiguracion datosConfig) {
		aumentoBonificacionResistenciaRobots = datosConfig.aumentoBonificacionMejoraResistenciaRobots;
		aumentoBonificacionCosteRobots = datosConfig.aumentoBonificacionMejoraCosteRobots;
		aumentoBonificacionMejoraTorreta = datosConfig.aumentoBonificacionMejoraTorreta;
		aumentoBonificacionMejoraAlimentos = datosConfig.aumentoBonificacionMejoraAlimentos;
		aumentoBonificacionCostePoblacion = datosConfig.aumentoBonificacionCostePorPoblacion;

        pBaseInfiltracion = datosConfig.probabilidadBaseInfiltracion;
        aumentoInfiltracion = datosConfig.aumentoProbabilidadInfiltracion;
        ciudadanosPorRobot = (int)(datosConfig.poblacionCubiertaPorRobot);
	}


	/**
	 * Módulo que realiza los cálculos necesarios para las bonificaciones
	 */ 
	public void calcularTurno(DatosTurno datosTurno){
        float bonificadorAlimentos = 1 - datosTurno.nivelMejoraAlimentoInicial*aumentoBonificacionMejoraAlimentos;
        float bonificadorResistenciaRobot = datosTurno.nivelMejoraRoboticaInicial*aumentoBonificacionResistenciaRobots;
        float bonificadorDefensa = datosTurno.nivelMejoraDefensaInicial*aumentoBonificacionMejoraTorreta;

        int poblacionSinCubrir = datosTurno.numeroPoblacionInicial - (datosTurno.numeroRobotsOrdenPublico * ciudadanosPorRobot);
        poblacionSinCubrir = poblacionSinCubrir > 0 ? poblacionSinCubrir : 0;
        float bonificadorInfiltracion = pBaseInfiltracion + (Mathf.Floor(poblacionSinCubrir/ciudadanosPorRobot)*aumentoInfiltracion);

        int precioRobot;
        int precioAlimento;
        int precioMejoraDefensa;
        int precioMejoraRobot;
        int precioMejoraAlimento;
        int precioCohete;
	}

}
