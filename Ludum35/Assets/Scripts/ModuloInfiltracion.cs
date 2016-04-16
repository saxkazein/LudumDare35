using System.Collections;

/**
 * 
 * Módulo para la gestión de la infiltración
 * 
 */ 
public class ModuloInfiltracion  {


	private int ciudadanosCubiertosPorRobot;
	private int aumentoProbabilidadInfiltracionCiudadanosNoCubiertos;



	private int numeroRobotsPerdidosInfiltracion;
	private int numeroRecursosPerdidosInfiltracion;


	/**
	 *  Método para la inicialización del módulo
	 */ 
	public void Start(DatosConfiguracion datosConfiguracion){
	}


	/**
	 * Módulo para realizar los cálculos necesarios para el cambio de turno
	 */ 
	public void calcularTurno(ref DatosTurno datosTurno){
		numeroRobotsPerdidosInfiltracion = 0;
		numeroRecursosPerdidosInfiltracion = 0;



	}

}
