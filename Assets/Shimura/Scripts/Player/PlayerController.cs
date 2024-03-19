using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度(200くらい)")] public float PlayerSpeed;
    [Header("走るときの倍率")] [SerializeField] float runSPEED;
    [Header("x方向の視点感度")] public float x_sensi;
    [Header("y方向の視点感度")] public float y_sensi;
    [Header("カメラ")] [SerializeField] GameObject Maincamera;
    [SerializeField] Animator anim;
    //[SerializeField] AudioClip footsteps;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixer audioMixer;
    float runspeed; // これはrunSPEEDと違う
    Rigidbody rb;
    bool isJumping = false;
    bool isSounding = false;
    public float jumpPower;
    private int Level;
    void Start()
    {
        // ゲーム開始時にマウスカーソルをロック
        Cursor.lockState = CursorLockMode.Locked;
        // カーソルを非表示にする
        Cursor.visible = false;
        runspeed = 1.0f;
        rb = GetComponent<Rigidbody>();
        Level = DifficultyManager.DifficultyLevel;
    }

    void Update()
    {
        CAMERAmove();
        if(Level <= 2)
        {
            shiftdash();
        }
        
        Spacejump();
        if (isSounding == true)
        {
            if (Time.timeScale == 0)
            {
                isSounding = false;
                audioSource.Stop();
                Debug.Log("ototomatta");
            }
        }
    }
    void FixedUpdate()
    {
        WASDmove();
    }

    //WASD移動の関数
    void WASDmove()
    { 
        float _input_WS = Input.GetAxis("Vertical");
        float _input_AD = Input.GetAxis("Horizontal");
        Vector3 movement = gameObject.transform.forward * _input_WS * PlayerSpeed * runspeed * Time.deltaTime 
                            + gameObject.transform.right * _input_AD * PlayerSpeed * runspeed * Time.deltaTime;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        //アニメーション用
        if (_input_WS != 0 || _input_AD != 0)
        {  
            StartCoroutine(WASDanim1());
            if (!isSounding)
            {
                audioSource.Play();
                isSounding=true;
            }
        }
        else
        {
            StartCoroutine(WASDanim2());
            isSounding=false;
            audioSource.Stop();
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
        audioMixer.GetFloat("Sensitivity", out float Sensitivity);
        float x_Rotation = Input.GetAxis("Mouse X") * Sensitivity * 0.2f;//sensitivityの初期値を5にしたため1にするため0.2倍
        float y_Rotation = Input.GetAxis("Mouse Y") * Sensitivity * 0.2f;
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
