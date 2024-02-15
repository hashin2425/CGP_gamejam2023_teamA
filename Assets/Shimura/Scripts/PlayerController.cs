using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度(0.04~0.1くらい)")] public float mainSPEED; //mainspeedをいじったら移動速度が変わる
    [Header("走るときの倍率")] [SerializeField] float runSPEED;
    [Header("x方向の視点感度(3~7くらい)")] public float x_sensi; //これいじったらx方向の視点感度が変わる
    [Header("y方向の視点感度(3~7くらい)")] public float y_sensi; //これいじったらy方向の視点感度が変わる
    [Header("カメラ")] [SerializeField] GameObject Maincamera; //cameraにMainCamera入れといて
    [Header("Player")] [SerializeField] GameObject Player;
    float runspeed;
    void Start()
    {
        runspeed = 1.0f;
    }

    void Update()
    {
        {
            movecon();
            cameracon();
        }
    }

    void movecon()
    {
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
        {
            runspeed = runSPEED;
        }

        if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            runspeed = 1.0f;
        }

        Transform trans = transform;  
        trans.position += trans.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * mainSPEED * runspeed;
        trans.position += trans.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") * mainSPEED * runspeed;
    }

    void cameracon()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = x_Rotation * x_sensi;
        y_Rotation = y_Rotation * y_sensi;
        this.transform.Rotate(0, x_Rotation, 0);
        Maincamera.transform.Rotate(-y_Rotation, 0, 0);
        Vector3 cameraAngle = Maincamera.transform.localEulerAngles;
        if (cameraAngle.x < 280 && cameraAngle.x > 180)
        {
            cameraAngle.x = 280;
        }
        if (cameraAngle.x > 45 && cameraAngle.x < 180)
        {
            cameraAngle.x = 45;
        }
        cameraAngle.y = 0;
        cameraAngle.z = 0;
        Maincamera.transform.localEulerAngles = cameraAngle;
    }
}
