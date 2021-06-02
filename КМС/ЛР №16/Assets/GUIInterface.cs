using UnityEngine;

public class GUIInterface : MonoBehaviour
{
    public Moving TankMovingComponent;
    private float h = 0;
    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.BeginGroup(new Rect(10, h, 250, 300)); 
        GUI.Label(new Rect(15, 20, 170, 30),"Скорость танка");
        TankMovingComponent.TankMoveSpeed = GUI.HorizontalSlider(new Rect(15, 50, 170, 30), 
            TankMovingComponent.TankMoveSpeed, 0.0f, 2.0f);
        GUI.Label(new Rect(15, 80, 170, 30),"Скорость поворота танка");
        TankMovingComponent.TankRotateSpeed = GUI.HorizontalSlider(new Rect(15, 100, 170, 30), 
            TankMovingComponent.TankRotateSpeed, 0.0f, 2.0f);
        GUI.contentColor = Color.white;
        if (GUI.Button(new Rect(10, 170, 90, 20), "Скрыть ПУ"))
            Hide();

        if (GUI.Button(new Rect(100, 170, 90, 20), "Показать ПУ"))
            Show();

        GUI.EndGroup();
    }

    public void Hide() { h = -170;} 
    public void Show() { h = 0; }
}
