using System.Collections;

[System.Serializable]
public class DatosTurnoIniciales{
    public int nivelMejoraRoboticaInicial;
    public int nivelMejoraAlimentoInicial;
    public int nivelMejoraDefensaInicial;
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
}
