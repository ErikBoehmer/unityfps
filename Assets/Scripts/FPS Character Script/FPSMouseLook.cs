using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMouseLook : MonoBehaviour
{
    public enum RotationAxis {MouseX, MouseY}
    public RotationAxis axex = RotationAxis.MouseY;
    private float CurrentSensitity_X = 1.5f;
    private float CurrentSensitity_Y = 1.5f;
    private float Sensitity_X = 1.5f;
    private float Sensitity_Y = 1.5f;
    private float Rotation_X, Rotation_Y;
    private float Minimum_X = -360f;
    private float Max_X = 360f;
    private float Minimum_Y = -60f;
    private float Max_Y = 60f;
    private Quaternion originalRotation;
    private float mouseSens = 1.7f;



    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;


    }

    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        HandleRotation();
    }

    float ClampAngle(float angle, float min, float max)
    {
        if(angle < -360f)
        {
            angle += 360;
        }
        if(angle > 360f)
        {
            angle -= 360f;
        }
        return Mathf.Clamp(angle, min, max);

        void HandleRotation()
        {
            if(CurrentSensitity_X != mouseSens || CurrentSensitity_Y != mouseSens)
            {
                CurrentSensitity_X = CurrentSensitity_Y = mouseSens;
            }
        }
        Sensitity_X = CurrentSensitity_X;
        Sensitity_Y = CurrentSensitity_Y;
        if(axex == RotationAxis.MouseX)
        {
            Rotation_X += Input.GetAxis("Mouse X") * Sensitity_X;

            Rotation_X = ClampAngle(Rotation_X, Minimum_X, Max_X);
            Quaterion xQuaterion = Quaterion.AngleAxis(Rotation_X, Vector3.up);
            transform.localRotation = originalRotation * xQuaterion;
        }

        if(axex == RotationAxis.MouseY)
        {
            Rotation_Y += Input.GetAxis("Mouse Y") * Sensitity_Y;
            Rotation_Y = ClampAngle(Rotation_Y, Minimum_Y, Max_Y);
            Quaterion yQuaterion = Quaterion.AngleAxis(Rotation_Y, Vector3.right);
            transform.localRotation = originalRotation * yQuaterion;
        }

    }
}
