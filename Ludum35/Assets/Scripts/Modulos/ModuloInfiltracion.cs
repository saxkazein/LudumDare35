using UnityEngine;
using System.Collections;

/**
 * 
 * Módulo para la gestión de la infiltración
 * 
 */ 
public class ModuloInfiltracion  {


	private int ciudadanosCubiertosPorRobot;
	private int aumentoProbabilidadInfiltracionCiudadanosNoCubiertos;
	private int enemigosMuertosPorRobot;
	private float probabilidadRobotMuerto;
	private float maximoPorcentajeRobotsMuertos;
	private float probabilidadInfiltracion;
	private float perdidasPorEnemigo;

	private float numeroRobotsPerdidosInfiltracion;


	/**
	 *  Método para la inicialización del módulo
	 */ 
	public void Start(DatosConfiguracion datosConfiguracion){
		ciudadanosCubiertosPorRobot = Mathf.RoundToInt(datosConfiguracion.poblacionCubiertaPorRobot);
		aumentoProbabilidadInfiltracionCiudadanosNoCubiertos = Mathf.RoundToInt(datosConfiguracion.aumentoProbabilidadInfiltracion);
		enemigosMuertosPorRobot = Mathf.RoundToInt(datosConfiguracion.cambiaformasPorRobot);
		probabilidadRobotMuerto = datosConfiguracion.probabilidadBasePerderRobotInfiltracion;
		maximoPorcentajeRobotsMuertos = datosConfiguracion.maximoPorcentajePerdidasRobotInfiltracion;
		probabilidadInfiltracion = datosConfiguracion.probabilidadBaseInfiltracion;
		perdidasPorEnemigo = datosConfiguracion.porcentajePerdidasPorCambiaformas;
	}


	/**
	 * Módulo para realizar los cálculos necesarios para el cambio de turno
	 */ 
	public void calcularTurno(ref DatosTurno datosTurno){
		numeroRobotsPerdidosInfiltracion = 0;

		int indicePoblacionSobrante = 0;
		float probabilidadAnadidaInfiltracion = 0;

		if (datosTurno.numeroPoblacionInicial > (datosTurno.numeroRobotsOrdenPublico * ciudadanosCubiertosPorRobot)) {	// Si no tenemos suficientes robots para cubrir a toda la población
			indicePoblacionSobrante = Mathf.RoundToInt((datosTurno.numeroPoblacionInicial-(datosTurno.numeroRobotsOrdenPublico * ciudadanosCubiertosPorRobot))/ciudadanosCubiertosPorRobot);

			probabilidadAnadidaInfiltracion = indicePoblacionSobrante * aumentoProbabilidadInfiltracionCiudadanosNoCubiertos;
		}
	
		// Se obtiene el porcentaje de posibilidad de infiltración total
		probabilidadInfiltracion += probabilidadAnadidaInfiltracion;

		float infiltracionValorProbabilidad = Random.Range(0F,1F);

		if(infiltracionValorProbabilidad<=probabilidadInfiltracion){				// Si la infiltracioń tiene lugar

			if(datosTurno.numeroCambiaformasInicial > (datosTurno.numeroRobotsOrdenPublico*enemigosMuertosPorRobot)){				// Si el número de enemigos excede la capacidad de defensa de los robots
				datosTurno.numeroRecursosPerdidosInfiltracion = Mathf.RoundToInt((datosTurno.numeroCambiaformasInicial - (datosTurno.numeroRobotsOrdenPublico*enemigosMuertosPorRobot))*perdidasPorEnemigo);
			}
				
			//Cálculo de la posibilidad de muerte de robot
			float muerteRobot = 0;
			int numeroMaximoRobotsMuertos = Mathf.RoundToInt(datosTurno.numeroRobotsOrdenPublico*maximoPorcentajeRobotsMuertos);
			for (int i = 0; i < numeroMaximoRobotsMuertos; i++) {						// Efectuamos las comprobaciones para el % de los robots que se quiera
				muerteRobot = Random.Range(0F,1F);
				if (muerteRobot < (probabilidadRobotMuerto-datosTurno.bonificadorResistenciaRobot)) {			// Si tiene que morir un robot
					datosTurno.numeroRobotsOrdenPublico--;
				}
			}

		}

	}


}
