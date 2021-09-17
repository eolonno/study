using UnityEngine;

public class Moving : MonoBehaviour
{
    Transform Tower;			    //объектная переменная для управления башней
    Transform TankBarrel; 			//объектная переменная для управления стволом
    public float TankMoveSpeed = 0.2f;     //для регулирования скорости движения танка
    float TowerRotateSpeed = 1f; 	//для регулирования скорости вращения башни
    float MinTowerRotation = -40f;	//минимальный угол поворота ствола
    float MaxTowerRotation = 40f;   //максимальный угол поворота ствола
    public float TankRotateSpeed = 0.3f;   //Скорость поворота танка
    float MinBarrelRotation = -20f; //Минимальный угол поворота дула
    float MaxBarrelRotation = 20f;  //Максимальный угол поворота дула
    bool isPlaying = false; //Проигрывается ли музыка движения танка
    void Start()
    {
        Tower = gameObject.transform.Find("Башня");
        TankBarrel = Tower.transform.Find("Дуло");
    }

    // Update is called once per frame
    void Update()
    {
        float TowerAngle = Tower.localEulerAngles.y;
        if (TowerAngle > 180)
            TowerAngle = -(360 - TowerAngle);
        float BarrelAngle = TankBarrel.eulerAngles.x;
        if (BarrelAngle > 180)
            BarrelAngle = -(360 - BarrelAngle);
        

        float x = Input.GetAxis("Horizontal") * TankRotateSpeed;
        float z = Input.GetAxis("Vertical") * TankMoveSpeed;
        if ((x > 0 || z > 0) && !isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Play();
            isPlaying = true;
        }
        else if(x == 0 && z == 0)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            isPlaying = false;
        }
        if (x != 0)
            transform.Rotate(0f, x, 0f);
        if (z != 0)
            transform.Translate(0, 0, z);
        
        float h = Input.GetAxis("Mouse X");
        if (h != 0 && TowerAngle > MinTowerRotation && TowerAngle < MaxTowerRotation)
        {
            Tower.Rotate(0f, h * TowerRotateSpeed, 0f);
            TowerAngle = Tower.localEulerAngles.y;
            if (TowerAngle > 180)
                TowerAngle = -(360 - TowerAngle);
            if (TowerAngle > MaxTowerRotation)
                Tower.localEulerAngles = new Vector3(.0f, MaxTowerRotation - 0.01f, .0f);
            else if(TowerAngle < MinTowerRotation)
                Tower.localEulerAngles = new Vector3(.0f, MinTowerRotation + 0.01f, .0f);
        }

        float v = Input.GetAxis("Mouse Y");
        if (v != 0 && BarrelAngle > MinBarrelRotation && BarrelAngle < MaxBarrelRotation)
        { 
            TankBarrel.Rotate(v * TowerRotateSpeed, 0f, 0f);
            BarrelAngle = TankBarrel.localEulerAngles.x;
            if (BarrelAngle > 180)
                BarrelAngle = -(360 - BarrelAngle);
            if (BarrelAngle > MaxBarrelRotation)
                TankBarrel.localEulerAngles = new Vector3(MaxBarrelRotation - 0.01f, .0f, .0f);
            if (BarrelAngle < MinBarrelRotation)
                TankBarrel.localEulerAngles = new Vector3(MinBarrelRotation + 0.01f, .0f, .0f);
        }
    }
}
