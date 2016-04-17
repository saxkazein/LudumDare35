using UnityEngine;
using System.Collections;

//Información básica de cada turno
public class DatosTurno
{
    public int nivelMejoraRoboticaInicial;
    public int nivelMejoraAlimentoInicial;
    public int nivelMejoraDefensaInicial;
    public int nivelMejoraCoheteInicial;

    public int numeroPoblacionInicial;
    public int numeroRobotsOrdenPublico;
	public float bonificadorConstruccionRobots;
	public float bonificadorConstruccionPoblacion;
	public float bonificadorAlimentos;
    public float bonificadorResistenciaRobot;
	public float bonificadorTorretas;
	public float bonificadorInfiltracion;

    public int numeroRecursosInicial;
    public int numeroConstruccionElegida;
    public int numeroRecursosInvertidosConstruccion;
    public int numeroComidaConstruida;
    public int numeroRobotsConstruidos;
    public int nivelMejoraRoboticaResultante;
    public int nivelMejoraAlimentoResultante;
    public int nivelMejoraDefensaResultante;
    public int nivelMejoraCoheteResultante;

    public int numeroCambiaformasInicial;
    public int numeroRobotsInicio;
    public int numeroComidaInicial;
    public int numeroComidaConsumida;
    public int numeroMuertesPorHambre;

    public bool flagExpedicionActiva;
    public int turnosDuracionExpedicionActiva;
    public int turnosRestantesExpedicion;
    public int numeroRobotsExpedicion;
    public int recursosRecuperadosExpedicion;
    public int poblacionRecuperadaExpedicion;
    public int numeroCambiaformasRecuperadosExpedicion;
    public int numeroRobotsPerdidosExpedicion;

    public int numeroRobotsPerdidosInfiltracion;
    public int numeroRecursosPerdidosInfiltracion;
    public int numeroPoblacionPerdidaInfiltracion;

    public int numeroTurno;
    public int numeroPoblacionPerdidaAtaque;

    public int tipoEncuentro;
    public int numeroPoblacionEncuentro;
    public int numeroRobotsEncuentro;
    public int numeroRecursosEncuentro;
    public int numeroComidaEncuentro;

    public int precioActualRobot;
    public int precioActualAlimento;
    public int precioActualMejoraDefensa;
    public int precioActualMejoraRobots;
    public int precioActualMejoraAlimentos;
    public int precioActualCohete;
    public void ResetDatosTurno(DatosTurnoIniciales datosTurnoIniciales)
    {
        nivelMejoraRoboticaInicial = datosTurnoIniciales.nivelMejoraRoboticaInicial; 
    	nivelMejoraAlimentoInicial = datosTurnoIniciales.nivelMejoraAlimentoInicial;
    	nivelMejoraDefensaInicial = datosTurnoIniciales.nivelMejoraDefensaInicial;
    	nivelMejoraCoheteInicial = datosTurnoIniciales.nivelMejoraCoheteInicial;

    	numeroPoblacionInicial = datosTurnoIniciales.numeroPoblacionInicial;
    	numeroRobotsOrdenPublico= datosTurnoIniciales.numeroRobotsOrdenPublico;
		bonificadorConstruccionRobots = datosTurnoIniciales.bonificadorConstruccionRobots;
		bonificadorConstruccionPoblacion = datosTurnoIniciales.bonificadorConstruccionPoblacion;
		bonificadorAlimentos = datosTurnoIniciales.bonificadorAlimentos;
    	bonificadorResistenciaRobot = datosTurnoIniciales.bonificadorResistenciaRobot;
		bonificadorTorretas = datosTurnoIniciales.bonificadorTorretas;
		bonificadorInfiltracion = datosTurnoIniciales.bonificadorInfiltracion;

    	numeroCambiaformasInicial = datosTurnoIniciales.numeroCambiaformasInicial;
    	numeroRobotsInicio = datosTurnoIniciales.numeroRobotsInicio;
    	numeroRecursosInicial = datosTurnoIniciales.numeroRecursosInicial;
    	numeroConstruccionElegida = datosTurnoIniciales.numeroConstruccionElegida;
    	numeroRecursosInvertidosConstruccion = datosTurnoIniciales.numeroRecursosInvertidosConstruccion;
    	numeroComidaConstruida = datosTurnoIniciales.numeroComidaConstruida;
    	numeroRobotsConstruidos = datosTurnoIniciales.numeroRobotsConstruidos;
    	nivelMejoraRoboticaResultante = datosTurnoIniciales.nivelMejoraRoboticaResultante;
    	nivelMejoraAlimentoResultante = datosTurnoIniciales.nivelMejoraAlimentoResultante;
    	nivelMejoraDefensaResultante = datosTurnoIniciales.nivelMejoraDefensaResultante;
    	nivelMejoraCoheteResultante = datosTurnoIniciales.nivelMejoraCoheteResultante;

    	numeroComidaInicial = datosTurnoIniciales.numeroComidaInicial;
    	numeroComidaConsumida = datosTurnoIniciales.numeroComidaConsumida;
    	numeroMuertesPorHambre = datosTurnoIniciales.numeroMuertesPorHambre;

    	flagExpedicionActiva = datosTurnoIniciales.flagExpedicionActiva;
    	turnosDuracionExpedicionActiva = datosTurnoIniciales.turnosDuracionExpedicionActiva;
    	turnosRestantesExpedicion = datosTurnoIniciales.turnosRestantesExpedicion;
    	numeroRobotsExpedicion = datosTurnoIniciales.numeroRobotsExpedicion;
    	recursosRecuperadosExpedicion = datosTurnoIniciales.recursosRecuperadosExpedicion;
    	poblacionRecuperadaExpedicion = datosTurnoIniciales.poblacionRecuperadaExpedicion;
        numeroCambiaformasRecuperadosExpedicion = datosTurnoIniciales.numeroCambiaformasRecuperadosExpedicion;
    	numeroRobotsPerdidosExpedicion = datosTurnoIniciales.numeroRobotsPerdidosExpedicion;

    	numeroRobotsPerdidosInfiltracion = datosTurnoIniciales.numeroRobotsPerdidosInfiltracion;
    	numeroRecursosPerdidosInfiltracion = datosTurnoIniciales.numeroRecursosPerdidosInfiltracion;
    	numeroPoblacionPerdidaInfiltracion = datosTurnoIniciales.numeroPoblacionPerdidaInfiltracion;

    	numeroTurno = datosTurnoIniciales.numeroTurno;
    	numeroPoblacionPerdidaAtaque = datosTurnoIniciales.numeroPoblacionPerdidaAtaque;

    	tipoEncuentro = datosTurnoIniciales.tipoEncuentro;
    	numeroPoblacionEncuentro = datosTurnoIniciales.numeroPoblacionEncuentro;
    	numeroRobotsEncuentro = datosTurnoIniciales.numeroRobotsEncuentro;
    	numeroRecursosEncuentro = datosTurnoIniciales.numeroRecursosEncuentro;
        numeroComidaEncuentro = datosTurnoIniciales.numeroComidaEncuentro;

        precioActualRobot = datosTurnoIniciales.precioActualRobot;
    	precioActualAlimento = datosTurnoIniciales.precioActualAlimento;
    	precioActualMejoraDefensa = datosTurnoIniciales.precioActualMejoraDefensa;
    	precioActualMejoraRobots = datosTurnoIniciales.precioActualMejoraRobots;
    	precioActualMejoraAlimentos = datosTurnoIniciales.precioActualMejoraAlimentos;
    	precioActualCohete = datosTurnoIniciales.precioActualCohete;
    }
}