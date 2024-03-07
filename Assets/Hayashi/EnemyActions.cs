using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyActions : MonoBehaviour
{
    [Header("敵キャラの移動速度")] public float movementSpeed = 2.0f;
    [Header("敵キャラがプレイヤーを追いかけるときの移動速度")] public float chaseSpeed = 1.0f;
    [Header("回転終了後に次の方向へ移動するまでの時間")] public float changeDirectionInterval = 10.0f;
    [Header("敵キャラが回転にかける時間")] public float rotationDuration = 1.2f;

    [SerializeField] BoxCollider sightCollider;
    [SerializeField] Transform rayStartPoint;

    private BoxCollider enemyCollider;
    private float timer;
    private bool isRotating = false;
    private Transform playerTransform;
    [SerializeField] AudioMixer audioMixer;
    private bool isChase=false;

    private void Start()
    {
        enemyCollider = GetComponent<BoxCollider>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        ChangeDirection();
        audioMixer.SetFloat("UnDiscovered_BGM", 0f);
        audioMixer.SetFloat("Discovered_BGM", -80f);
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (CanFindPlayer() || isChase)
        {
            StartCoroutine(ChasePlayer());
            Vector3 newVector3 = playerTransform.position;
            newVector3.y = transform.position.y;
            transform.LookAt(newVector3);
            MoveForward(chaseSpeed);
            audioMixer.SetFloat("Discovered_BGM", 0f);
            audioMixer.SetFloat("UnDiscovered_BGM", -80f);
        }
        else
        {
            if (timer > changeDirectionInterval && !isRotating)
            {
                ChangeDirection();
                timer = 0;
            }

            if (!HasCollision() && !isRotating)
            {
                MoveForward(movementSpeed);
            }
            else if (HasCollision() && !isRotating)
            {
                ChangeDirection();
            }
            audioMixer.SetFloat("UnDiscovered_BGM", 0f);
            audioMixer.SetFloat("Discovered_BGM", -80f);
        }
    }
    //コルーチン
    IEnumerator ChasePlayer()
    {
        isChase=true;
         Debug.Log("oikaketeru");
        yield return new WaitForSeconds(3);
        isChase=false;
        Debug.Log("minogasita");
    }
    private void MoveForward(float speed = 1.0f)
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void ChangeDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        StartCoroutine(RotateOverTime(randomAngle, rotationDuration));
    }

    private IEnumerator RotateOverTime(float targetAngle, float duration)
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;
    }

    private bool HasCollision()
    {
        Collider[] colliders = Physics.OverlapBox(enemyCollider.bounds.center, enemyCollider.bounds.extents, transform.rotation);
        foreach (Collider col in colliders)
        {
            if ((col.CompareTag("Wall") || col.CompareTag("Enemy")) && col != enemyCollider)
            {
                return true;
            }
        }
        return false;
    }

    private bool CanFindPlayer()
    {
        // 「Playerタグを持つコリジョンに衝突している」なおかつ「自身からRayを飛ばして直線上にPlayerタグを持つオブジェクトが存在する」ならTrueを出して、それ以外はFalseを出す
        Collider[] colliders = Physics.OverlapBox(sightCollider.bounds.center, sightCollider.bounds.extents, transform.rotation);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                RaycastHit hit;
                if (Physics.Raycast(rayStartPoint.position, col.transform.position - rayStartPoint.position, out hit))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}