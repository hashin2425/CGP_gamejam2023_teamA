using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度(一秒で進む距離)")] public float PlayerSpeed;
    [Header("走るときの倍率")] [SerializeField] float runSPEED;
    [Header("x方向の視点感度")] public float x_sensi;
    [Header("y方向の視点感度")] public float y_sensi;
    [Header("カメラ")] [SerializeField] GameObject Maincamera;
    [SerializeField] Animator anim;
    float runspeed; // これはrunSPEEDと違う
    Rigidbody rb;
    bool isJumping = false;
    public float jumpPower;
    void Start()
    {
        runspeed = 1.0f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        WASDmove();
        CAMERAmove();
        shiftdash();
        Spacejump();
    }

    //WASD移動の関数
    void WASDmove()
    { 
        float _input_WS = Input.GetAxis("Vertical");
        float _input_AD = Input.GetAxis("Horizontal");
        transform.position += transform.TransformDirection(Vector3.forward) * _input_WS * PlayerSpeed * runspeed * Time.deltaTime
                            + transform.TransformDirection(Vector3.right) * _input_AD * PlayerSpeed * runspeed * Time.deltaTime;
        //アニメーション用
        if (_input_WS != 0 || _input_AD != 0)
        {  
            StartCoroutine(WASDanim1());
        }
        else
        {
            StartCoroutine(WASDanim2());
        }
    }
    //WASDアニメーション用コルーチン(歩き始め)
     IEnumerator WASDanim1()
    {
        anim.SetBool("bl_Walk", true);

        yield return new WaitForSeconds(1);

        anim.SetBool("bl_Walking", true);
    }
    //WASDアニメーション用コルーチン(歩き終わり)
     IEnumerator WASDanim2()
    {
        anim.SetBool("bl_Walking", false);

        yield return new WaitForSeconds(1);

        anim.SetBool("bl_Walk", false);
    }
    //視点操作の関数
    void CAMERAmove()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = x_Rotation * x_sensi * Time.deltaTime;
        y_Rotation = y_Rotation * y_sensi * Time.deltaTime;
        this.transform.Rotate(0, x_Rotation, 0);
        Maincamera.transform.Rotate(-y_Rotation, 0, 0);
        //以下カメラの視点制限
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

    //shiftで走る関数
    void shiftdash()
    {
        //Shiftを押したとき
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
        {
            runspeed = runSPEED;
            anim.SetBool("bl_Run", true);
        }
        //Shiftを離したとき
        if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            runspeed = 1.0f;
            anim.SetBool("bl_Run", false);
        }
    }
    //ジャンプの関数
    void Spacejump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
        }
    }

    //二段ジャンプ禁止用
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
