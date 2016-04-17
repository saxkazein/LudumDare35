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
	private float perdidasPorEnemigo;

	private float numeroRobotsPerdidosInfiltracion;


	/**
	 *  Método para la inicialización del módulo
	 */ 
	public void Start(DatosConfiguracion datosConfiguracion){
		enemigosMuertosPorRobot = Mathf.RoundToInt(datosConfiguracion.cambiaformasPorRobot);
		probabilidadRobotMuerto = datosConfiguracion.probabilidadBasePerderRobotInfiltracion;
		maximoPorcentajeRobotsMuertos = datosConfiguracion.maximoPorcentajePerdidasRobotInfiltracion;
		perdidasPorEnemigo = datosConfiguracion.porcentajePerdidasPorCambiaformas;
	}


    /**
	 * Módulo para realizar los cálculos necesarios para el cambio de turno
	 */
    public void calcularEvento(ref DatosTurno datosTurno)
    {
        int numeroRobotsPerdidosInfiltracion = 0;
        int numeroRecursosPerdidosInfiltracion = 0;
        int numeroPoblacionPerdidaInfiltracion = -datosTurno.numeroCambiaformasInicial;

        int cambiaformasSupervivientes = datosTurno.numeroCambiaformasInicial - (datosTurno.numeroRobotsOrdenPublico * enemigosMuertosPorRobot);

        float rng = 0;

        if(cambiaformasSupervivientes > 0)
        {
            rng = Random.Range(0.5f, 1.0f);

            int recursos = 0;
            for(int i = 0; i <= cambiaformasSupervivientes; i++)
            {
                recursos += Mathf.RoundToInt(rng * (perdidasPorEnemigo * datosTurno.numeroRecursosInicial));
            }
            numeroRecursosPerdidosInfiltracion = -recursos;
        }

        int muerte = 0;
        int limit = Mathf.RoundToInt(datosTurno.numeroRobotsOrdenPublico * maximoPorcentajeRobotsMuertos);
        for (int i = 0; i <= datosTurno.numeroRobotsOrdenPublico; i++)
        {
            rng = Random.Range(0f, 1f);
            if (rng <= probabilidadRobotMuerto - datosTurno.bonificadorResistenciaRobot)
            {
                muerte++;
            }
        }
        numeroRobotsPerdidosInfiltracion = muerte > limit ? -limit : -muerte;

        datosTurno.numeroRobotsPerdidosInfiltracion = numeroRobotsPerdidosInfiltracion;
        datosTurno.numeroRecursosPerdidosInfiltracion = numeroRecursosPerdidosInfiltracion;
        datosTurno.numeroPoblacionPerdidaInfiltracion = numeroPoblacionPerdidaInfiltracion;
    }
}
