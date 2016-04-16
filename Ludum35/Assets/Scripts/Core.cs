using UnityEngine;
using System.Collections;

public class Core : Singleton<Core>
{

    #region VMiembro
    public DatosConfiguracion configuracion;
    private string pathArchivoConfiguracion = "configuracion";
    #endregion

    #region Init
    void Start()
    {
        CargaDatosConfiguracion();

    }
    #endregion Init

    #region CargaDeDatos
    void CargaDatosConfiguracion()
    {
        TextAsset textAsset = Resources.Load(pathArchivoConfiguracion) as TextAsset;
        configuracion = JsonUtility.FromJson<DatosConfiguracion>(textAsset.text);
        Debug.Log(configuracion.danoBasePatos);
    }
    #endregion CargaDeDatos

    #region GestionTurnos
    #endregion GestionTurnos

    void Update()
    {

    }
}
