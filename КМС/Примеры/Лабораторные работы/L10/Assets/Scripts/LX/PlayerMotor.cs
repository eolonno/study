using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private float angX = 0;
    private Vector3 rotationCamera = Vector3.zero;

    public float gunAng = 0;
    public GameObject gun;
    public float gunMaxAngle = 10;
    public float gunMinAngle = -10f;

    public void MyRotate(float angX)
    {
        this.angX += angX;
    }
    public void RotateCam(Vector3 rotationCam)
    {
        this.rotationCamera = rotationCam;
    }

    public void SetGunAngel(float k)
    {
        gunAng += k;
    }

    void FixedUpdate()
    {
        PerformRotation();
    }

    void PerformRotation()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, angX, transform.rotation.z);

        if (cam != null)
        {
            cam.transform.Rotate(-rotationCamera);
        }

        if (gunAng > gunMaxAngle)
        {
            gunAng = gunMaxAngle;
        }
        else if (gunAng < gunMinAngle)
        {
            gunAng = gunMinAngle;
        }

        gun.transform.rotation = Quaternion.Euler(-gunAng - 180, angX, transform.rotation.z);
    }
}
