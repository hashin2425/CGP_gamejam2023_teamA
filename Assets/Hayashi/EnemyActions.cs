using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public float speed = 5.0f;
    public float changeDirectionInterval = 2.0f;
    public BoxCollider collider;
    public float rotationDuration = 1.0f;

    private float timer;
    private bool isRotating = false;

    private void Start()
    {
        ChangeDirection();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > changeDirectionInterval && !isRotating)
        {
            ChangeDirection();
            timer = 0;
        }

        if (!HasCollision() && !isRotating)
        {
            MoveForward();
        }
        else if (HasCollision() && !isRotating)
        {
            ChangeDirection();
        }
    }

    private void MoveForward()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
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
        Collider[] colliders = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, transform.rotation);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Wall"))
            {
                return true;
            }
        }
        return false;
    }
}