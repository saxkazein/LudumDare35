﻿using UnityEngine;
using System.Collections;

public class Core : Singleton<Core>
{

    #region VMiembro
    public DatosConfiguracion configuracion;

    private DatosTurnoIniciales datosTurnoIniciales;
    private DatosTurno datosTurno;

    private string pathArchivoConfiguracion = "configuracion";
    private string pathArchivoDatosIniciales = "datosIniciales";

    private ModuloDefensa moduloDefensa;
    private ModuloExpedicion moduloExpedicion;
    private ModuloInfiltracion moduloInfiltracion;
    private ModuloPoblacion moduloPoblacion;
    #endregion

    #region Init
    /*
     * Carga las configuraciones, inicializa los módulos y comienza el primer turno de la partida
     */
    void Start()
    {
        CargaDatosConfiguracion();
        InicializaModulos();
        IniciaDatosPartida();
    }

    void InicializaModulos()
    {
        moduloDefensa = new ModuloDefensa();
        moduloExpedicion = new ModuloExpedicion();
        moduloExpedicion.Start(configuracion);
        moduloInfiltracion = new ModuloInfiltracion();
        moduloInfiltracion.Start(configuracion);
        moduloPoblacion = new ModuloPoblacion();
    }
    #endregion Init

    #region CargaDeDatos

    /*
     * Recupera los datos de los archivos JSON y genera sus clases 
     */
    void CargaDatosConfiguracion()
    {
        TextAsset textAsset = Resources.Load(pathArchivoConfiguracion) as TextAsset;
        configuracion = JsonUtility.FromJson<DatosConfiguracion>(textAsset.text);
        textAsset = Resources.Load(pathArchivoDatosIniciales) as TextAsset;
        datosTurnoIniciales = JsonUtility.FromJson<DatosTurnoIniciales>(textAsset.text);
    }
    #endregion CargaDeDatos

    #region GestionTurnos

    /* 
     * Inicia los datos del primer turno de la partida
     */
    void IniciaDatosPartida()
    {
        datosTurno = new DatosTurno();
        datosTurno.ResetDatosTurno(datosTurnoIniciales);
    }

    /*
     * Llama a los modulos para que hagan sus calculos respectivos
     */
    void CalculaTurno()
    {
        moduloPoblacion.calculaTurno(ref datosTurno);
    }

    /*
     * Recupera los datos calculados y obtiene los resultados de las operaciones para el siguiente turno
     */
    void ProcesaDatosTurno()
    {
        int _nivelMejoraRoboticaResultante = datosTurno.nivelMejoraRoboticaResultante;
        int _nivelMejoraAlimentoResultante = datosTurno.nivelMejoraAlimentoResultante;
        int _nivelMejoraDefensaResultante = datosTurno.nivelMejoraDefensaInicial;
        int _numeroPoblacionResultante = datosTurno.numeroPoblacionInicial + datosTurno.numeroPoblacionEncuentro + datosTurno.numeroPoblacionPerdidaAtaque + datosTurno.numeroPoblacionPerdidaInfiltracion;

        int _numeroRobotsExpedicionResultante = datosTurno.numeroRobotsExpedicion;
        int _numeroRobotsResultante = datosTurno.numeroRobotsInicio + datosTurno.numeroRobotsEncuentro + datosTurno.numeroRobotsConstruidos + datosTurno.numeroRobotsPerdidosExpedicion + datosTurno.numeroRobotsPerdidosInfiltracion;
        int _numeroRobotsOrdenPublicoResultante = _numeroRobotsResultante - _numeroRobotsExpedicionResultante;

        int _numeroRecursosResultante = datosTurno.numeroRecursosInicial + datosTurno.numeroRecursosEncuentro + datosTurno.recursosRecuperadosExpedicion + datosTurno.numeroRecursosInvertidosConstruccion;
        int _numeroComidaResultante = datosTurno.numeroComidaInicial + datosTurno.numeroComidaEncuentro + datosTurno.numeroComidaConsumida + datosTurno.numeroComidaConstruida;
        int _numeroCambiaformasResultante = datosTurno.numeroCambiaformasInicial + datosTurno.numeroCambiaformasRecuperadosExpedicion + datosTurno.numeroPoblacionPerdidaInfiltracion;
        int _numeroTurnoResultante = datosTurno.numeroTurno+1;

        bool _flagExpedicionActivaResultante = datosTurno.flagExpedicionActiva;
        int _turnosDuracionExpedicionActivaResultante = datosTurno.turnosDuracionExpedicionActiva;
        int _turnosRestantesExpedicionResultante = datosTurno.turnosRestantesExpedicion;

        datosTurno.ResetDatosTurno(datosTurnoIniciales);

        datosTurno.nivelMejoraRoboticaInicial = _nivelMejoraRoboticaResultante;
        datosTurno.nivelMejoraAlimentoInicial = _nivelMejoraAlimentoResultante;
        datosTurno.nivelMejoraDefensaInicial = _nivelMejoraDefensaResultante;

        datosTurno.numeroPoblacionInicial = _numeroPoblacionResultante;

        datosTurno.numeroRobotsInicio = _numeroRobotsResultante;
        datosTurno.numeroRobotsExpedicion = _numeroRobotsExpedicionResultante;
        datosTurno.numeroRobotsOrdenPublico = _numeroRobotsOrdenPublicoResultante;

        datosTurno.numeroRecursosInicial = _numeroRecursosResultante;
        datosTurno.numeroComidaInicial = _numeroComidaResultante;
        datosTurno.numeroCambiaformasInicial = _numeroCambiaformasResultante;

        datosTurno.numeroTurno = _numeroTurnoResultante;

        datosTurno.flagExpedicionActiva = _flagExpedicionActivaResultante;
        datosTurno.turnosDuracionExpedicionActiva = _turnosDuracionExpedicionActivaResultante;
        datosTurno.turnosRestantesExpedicion = _turnosRestantesExpedicionResultante;
    }

    /*
     * Confirma las acciones del jugador e inicia la expedicion cuando toque
     */
    void ConfirmaTurno()
    {

    }

    /*
     * Confirma si el jugador desea quedarse con los pobladores que ha encontrado en la expedicion
     */
    void ConsultaDecisiones()
    {

    }

    /*
     * Inicia el proceso de pasar turno cuando el jugador pulsa el botón en la interfaz
     */
    public void PasaTurno()
    {
        ConfirmaTurno();
        CalculaTurno();
        ConsultaDecisiones();
        ProcesaDatosTurno();
    }
    #endregion GestionTurnos
}
