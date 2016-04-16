using System.Collections;

/**
 * 
 * Módulo para la gestión de la infiltración
 * 
 */ 
public class ModuloInfiltracion  {


	private int numeroCambiaformas;
	private int numeroRobotsOrdenPublico;
	private float bonificacionResistenciaRobot;
	private int numeroRobotsPerdidosInfiltracion;
	private int numeroRecursosPerdidosInfiltracion;


	/**
	 *  Método para la inicialización del módulo
	 */ 
	public void Start(){
	}


	/**
	 * Módulo para realizar los cálculos necesarios para el cambio de turno
	 */ 
	public void calcularTurno(DatosConfiguracion datosConfig){
		numeroRobotsPerdidosInfiltracion = 0;
		numeroRecursosPerdidosInfiltracion = 0;
	}

}
