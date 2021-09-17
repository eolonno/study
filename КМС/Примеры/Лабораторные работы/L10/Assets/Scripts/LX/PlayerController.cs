using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float lookSpeed = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float yRot = Input.GetAxisRaw("Mouse X");
        yRot *= lookSpeed;
        motor.MyRotate(yRot);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0f, 0f) * lookSpeed;
        motor.RotateCam(camRotation);

        motor.SetGunAngel(xRot);
    }

    
}
