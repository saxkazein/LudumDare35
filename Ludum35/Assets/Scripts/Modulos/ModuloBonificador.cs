using UnityEngine;
using System.Collections;

/**
 * 
 * Módulo que calcula las bonificaciones correspondientes
 * 
 */
public class ModuloBonificador {

    private float aumentoBonificacionResistenciaRobots;
    //private float aumentoBonificacionCosteRobots;
    private float aumentoBonificacionMejoraTorreta;
    private float aumentoBonificacionMejoraAlimentos;
    private float aumentoBonificacionCostePoblacion;

    private float pBaseInfiltracion;
    private float aumentoInfiltracion;
    private int ciudadanosPorRobot;

    private int poblacionInicial;

    private int precioBaseRobot;
    private int precioBaseAlimento;
    private int[] precioBaseMejoraDefensa;
    private int[] precioBaseMejoraRobot;
    private int[] precioBaseMejoraAlimento;
    private int[] precioBaseCohete;
    /**
	 * Método que realiza la inicialización del módulo
	 */
    public void Start(DatosConfiguracion datosConfig) {
        aumentoBonificacionResistenciaRobots = datosConfig.aumentoBonificacionMejoraResistenciaRobots;
        //aumentoBonificacionCosteRobots = datosConfig.aumentoBonificacionMejoraCosteRobots;
        aumentoBonificacionMejoraTorreta = datosConfig.aumentoBonificacionMejoraTorreta;
        aumentoBonificacionMejoraAlimentos = datosConfig.aumentoBonificacionMejoraAlimentos;
        aumentoBonificacionCostePoblacion = datosConfig.aumentoBonificacionCostePorPoblacion;

        poblacionInicial = datosConfig.poblacionInicial;

        pBaseInfiltracion = datosConfig.probabilidadBaseInfiltracion;
        aumentoInfiltracion = datosConfig.aumentoProbabilidadInfiltracion;
        ciudadanosPorRobot = (int)(datosConfig.poblacionCubiertaPorRobot);

        precioBaseRobot = datosConfig.costeBaseRobot;
        precioBaseAlimento = datosConfig.costeBaseAlimento;
        precioBaseMejoraAlimento = datosConfig.costeBaseMejoraAlimento;
        precioBaseMejoraDefensa = datosConfig.costeBaseMejoraTorreta;
        precioBaseMejoraRobot = datosConfig.costeBaseMejoraRobot;
        precioBaseCohete = datosConfig.costeBaseCohete;
	}


    /**
	 * Módulo que realiza los cálculos necesarios para las bonificaciones
	 */
    public void calcularTurno(DatosTurno datosTurno) {
        float bonificadorAlimentos = 1 - datosTurno.nivelMejoraAlimentoInicial * aumentoBonificacionMejoraAlimentos;
        float bonificadorResistenciaRobot = datosTurno.nivelMejoraRoboticaInicial * aumentoBonificacionResistenciaRobots;
        float bonificadorDefensa = datosTurno.nivelMejoraDefensaInicial * aumentoBonificacionMejoraTorreta;

        int poblacionSinCubrir = datosTurno.numeroPoblacionInicial - (datosTurno.numeroRobotsOrdenPublico * ciudadanosPorRobot);
        poblacionSinCubrir = poblacionSinCubrir > 0 ? poblacionSinCubrir : 0;
        float bonificadorInfiltracion = pBaseInfiltracion + (Mathf.Floor(poblacionSinCubrir / ciudadanosPorRobot) * aumentoInfiltracion);

        float bonificadorPrecio = 1f - (Mathf.Log(datosTurno.numeroPoblacionInicial / poblacionInicial) * aumentoBonificacionCostePoblacion);

        bonificadorPrecio = bonificadorPrecio > 1.25f ? 1.25f : bonificadorPrecio;

        int precioRobot = Mathf.RoundToInt(precioBaseRobot * bonificadorPrecio);
        int precioAlimento = Mathf.RoundToInt(precioBaseAlimento * bonificadorPrecio);
        int precioMejoraDefensa = Mathf.RoundToInt(precioBaseMejoraDefensa[datosTurno.nivelMejoraDefensaInicial] * bonificadorPrecio);
        int precioMejoraRobot = Mathf.RoundToInt(precioBaseMejoraRobot[datosTurno.nivelMejoraRoboticaInicial] * bonificadorPrecio);
        int precioMejoraAlimento = Mathf.RoundToInt(precioBaseMejoraAlimento[datosTurno.nivelMejoraAlimentoInicial] * bonificadorPrecio);
        int precioCohete = Mathf.RoundToInt(precioBaseCohete[datosTurno.nivelMejoraCoheteInicial] * bonificadorPrecio);

        datosTurno.precioActualRobot = precioRobot;
        datosTurno.precioActualAlimento = precioAlimento;
        datosTurno.precioActualMejoraDefensa = precioMejoraDefensa;
        datosTurno.precioActualMejoraAlimentos = precioMejoraAlimento;
        datosTurno.precioActualMejoraRobots = precioMejoraRobot;
        datosTurno.precioActualCohete = precioCohete;

        datosTurno.bonificadorAlimentos = bonificadorAlimentos;
        datosTurno.bonificadorResistenciaRobot = bonificadorResistenciaRobot;
        datosTurno.bonificadorTorretas = bonificadorDefensa;
        datosTurno.bonificadorInfiltracion = bonificadorInfiltracion;
        datosTurno.bonificadorConstruccionPoblacion = bonificadorPrecio;
        datosTurno.bonificadorConstruccionRobots = bonificadorPrecio;
    }
}
