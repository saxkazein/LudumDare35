using UnityEngine;
using System.Collections;

public class ModuloConstruccion {

	public void calcularTurno(ref DatosTurno datosTurno) {

        int numComidaConstruida = 0;
        int numRobotsConstruidos = 0;
        int nvMejoraTorretaResultante = datosTurno.nivelMejoraDefensaInicial;
        int nvMejoraRobotResultante = datosTurno.nivelMejoraRoboticaInicial;
        int nvMejoraAlimentoResultante = datosTurno.nivelMejoraAlimentoInicial;
        int nvCoheteResultante = datosTurno.nivelMejoraCoheteInicial;

        switch(datosTurno.numeroConstruccionElegida)
        {
            //Alimento
            case 0:
                numComidaConstruida = Mathf.FloorToInt(datosTurno.numeroRecursosInvertidosConstruccion / datosTurno.precioActualAlimento);
                break;
            //Robots
            case 1:
                numRobotsConstruidos = Mathf.FloorToInt(datosTurno.numeroRecursosInvertidosConstruccion / datosTurno.precioActualRobot);
                break;
            //Mejora Alimento
            case 2:
                nvMejoraAlimentoResultante++;
                break;
            //Mejora Defensa
            case 3:
                nvMejoraTorretaResultante++;
                break;
            //Mejora Robot
            case 4:
                nvMejoraRobotResultante++;
                break;
            //Mejora Cohete
            case 5:
                nvCoheteResultante++;
                break;

            default:
                break;
        }

        datosTurno.numeroComidaConstruida = numComidaConstruida;
        datosTurno.numeroRobotsConstruidos = numRobotsConstruidos;
        datosTurno.nivelMejoraAlimentoResultante = nvMejoraAlimentoResultante;
        datosTurno.nivelMejoraDefensaResultante = nvMejoraTorretaResultante;
        datosTurno.nivelMejoraRoboticaResultante = nvMejoraRobotResultante;
        datosTurno.nivelMejoraCoheteResultante = nvCoheteResultante;
	}
}
