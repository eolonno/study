using UnityEngine;

public class Moving : MonoBehaviour
{
    Transform Tower;			    //объектная переменная для управления башней
    Transform TankBarrel; 			//объектная переменная для управления стволом
    float TankMoveSpeed = 0.2f;     //для регулирования скорости движения танка
    float TowerRotateSpeed = 1f; 	//для регулирования скорости вращения башни
    float min = 260f;			    //минимальный угол поворота ствола
    float max = 300f;               //максимальный угол поворота ствола
    float TankRotateSpeed = 0.3f;   //Скорость поворота танка

    // Start is called before the first frame update
    void Start()
    {
        Tower = gameObject.transform.Find("Башня");
        TankBarrel = Tower.transform.Find("Дуло");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * TankRotateSpeed;
        float z = Input.GetAxis("Vertical") * TankMoveSpeed;
        if (x != 0)
            transform.Rotate(0f, x, 0f);
        if (z != 0)
            transform.Translate(0, 0, z);
        
        float h = Input.GetAxis("Mouse X");
        if (h != 0)
            Tower.Rotate(0f, h * TowerRotateSpeed, 0f);

        float v = Input.GetAxis("Mouse Y");
        if (v != 0)
            TankBarrel.transform.Rotate(v * TowerRotateSpeed, 0f, 0f);
    }
}
