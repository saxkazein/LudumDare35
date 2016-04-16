using System.Collections;


[System.Serializable]
public class DatosConfiguracion {

	public float aumentoBonificacionMejoraResistenciaRobots;
	public float aumentoBonificacionMejoraCosteRobots;
	public float aumentoBonificacionMejoraTorreta;
	public float aumentoBonificacionMejoraAlimentos;
	public float aumentoBonificacionCostePorPoblacion;

	public float ciudadanosPorAlimentoTurno;
	public float limiteInferiorPerdidaPorHambre;
	public float limiteSuperiorPerdidaPorHambre;

	public float danoBasePatos;
	public float aumentoDanoPatosPorTurno;
	public float varianzaDanoPatos;
	public float defensaTorreta;
	public float porcentajeDanoPoblacion;

	public float recursosBasePorExpedicion;
	public float poblacionBasePorExpedicion;
	public float probabilidadInfiltradoExpedicion;
	public float maximoPorcentajeInfiltradoExpedicion;
	public float probabilidadBasePerderRobotExpedicion;
	public float maximoPorcentajePerdidasRobotExpedicion;
	public float aumentoRecompensaExpedicionPorTurnos;

	public float poblacionCubiertaPorRobot;
	public float probabilidadBaseInfiltracion;
	public float aumentoProbabilidadInfiltracion;
	public float cambiaformasPorRobot;
	public float probabilidadBasePerderRobotInfiltracion;
	public float maximoPorcentajePerdidasRobotInfiltracion;
	public float porcentajePerdidasPorCambiaformas;

	public float costeBaseAlimento;
	public float costeBaseRobot;
	public float[] costeBaseMejoraRobot;
	public float[] costeBaseMejoraTorreta;
	public float[] costeBaseMejoraAlimento;
	public float costeBaseCohete;

}
