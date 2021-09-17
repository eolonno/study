using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    float speedTowerRorate = 0.5f; //скорость поворота башни

    //функция update вызывается раз за кадр. Это главная функция для обновлений кадров.
    void Update()
    { 
        transform.Rotate(0f, 0f,Input.GetAxis("Mouse X") * speedTowerRorate);
        //transform - компанент объекта(в нашем случае - башни), 
        //Rotate - метод поворота этого объекта, принимает при параметра - (угол поворота оси X. угол поворота оси Y, угол поворота оси Z)
        //Input.GetAxis(Mouse X) - Возвращает значение по axisName виртуальной оси. Mouse X привязан к перемещениям мыши.
    }
}
