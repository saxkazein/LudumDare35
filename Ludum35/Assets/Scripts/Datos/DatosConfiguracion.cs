using System.Collections;

[System.Serializable]
public class DatosConfiguracion {
	public float aumentoBonificacionMejoraResistenciaRobots;
	public float aumentoBonificacionMejoraCosteRobots;
	public float aumentoBonificacionMejoraTorreta;
	public float aumentoBonificacionMejoraAlimentos;
	public float aumentoBonificacionCostePorPoblacion;

	public float multiplicadorCostePorPoblacion;
    public float limiteInferiorMultiplicadorCostePorPoblacion;

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

	public int costeBaseAlimento;
	public int costeBaseRobot;
	public int[] costeBaseMejoraRobot;
	public int[] costeBaseMejoraTorreta;
	public int[] costeBaseMejoraAlimento;
	public int[] costeBaseCohete;

    public int poblacionInicial;
    public int robotsIniciales;
    public int recursosIniciales;
    public int comidaInicial;

    public float probabilidadAtaquePatos;

    public float[] datosEncuentro1;
    public float[] datosEncuentro2;
    public float[] datosEncuentro3;
    public float[] datosEncuentro4;
    public float[] datosEncuentro5;
    public float[] datosEncuentro6;
    public float[] datosEncuentro7;
    public float[] datosEncuentro8;
    public float[] datosEncuentro9;
    public float[] datosEncuentro10;

    public string fraseEncuentro1;
    public string fraseEncuentro2;
    public string fraseEncuentro3;
    public string fraseEncuentro4;
    public string fraseEncuentro5;
    public string fraseEncuentro6;
    public string fraseEncuentro7;
    public string fraseEncuentro8;
    public string fraseEncuentro9;
    public string fraseEncuentro10;
}
