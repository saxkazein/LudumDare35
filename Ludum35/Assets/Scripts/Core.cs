using UnityEngine;
using System.Collections;

public class Core : Singleton<Core>
{

    #region VMiembro
    public DatosConfiguracion configuracion;

    private DatosTurnoIniciales datosTurnoIniciales; 

    private string pathArchivoConfiguracion = "configuracion";
    private string pathArchivoDatosIniciales = "datosIniciales";

    private ModuloDefensa moduloDefensa;
    private ModuloExpedicion moduloExpedicion;
    private ModuloInfiltracion moduloInfiltracion;
    private ModuloPoblacion moduloPoblacion;

    #endregion

    #region Init
    void Start()
    {
        CargaDatosConfiguracion();
        moduloDefensa = new ModuloDefensa();
        moduloExpedicion = new ModuloExpedicion();
        moduloExpedicion.Start(configuracion);
        moduloInfiltracion = new ModuloInfiltracion();
        moduloInfiltracion.Start(configuracion);
        moduloPoblacion = new ModuloPoblacion();
    }
    #endregion Init

    #region CargaDeDatos
    void CargaDatosConfiguracion()
    {
        TextAsset textAsset = Resources.Load(pathArchivoConfiguracion) as TextAsset;
        configuracion = JsonUtility.FromJson<DatosConfiguracion>(textAsset.text);
        textAsset = Resources.Load(pathArchivoDatosIniciales) as TextAsset;
        datosTurnoIniciales = JsonUtility.FromJson<DatosTurnoIniciales>(textAsset.text);
    }
    #endregion CargaDeDatos

    #region GestionTurnos
    void IniciaDatosPartida()
    {

    }

    
    #endregion GestionTurnos

    void Update()
    {

    }
}
