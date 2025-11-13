using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody characterRigidbody;

    public int xp = 0;
    Vector3 size = new Vector3(1f, 0f, 1f);
    public float growFactor = 0.1f;

    private HoleAbsorption holeAbsorption;

    void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        holeAbsorption = GetComponent<HoleAbsorption>();
    }

    void OnEnable()
    {
        // ✅ 이벤트 구독
        if (holeAbsorption != null)
            holeAbsorption.OnAbsorb += AddXP;
    }

    void OnDisable()
    {
        // ✅ 이벤트 구독 해제 (메모리 누수 방지)
        if (holeAbsorption != null)
            holeAbsorption.OnAbsorb -= AddXP;
    }

    private void AddXP(int amount)
    {
        xp += amount;
        if (xp >= 5)
        {
            LevelUp();
            xp = 0;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= speed;
        characterRigidbody.velocity = velocity;
    }

    private void LevelUp()
    {
        transform.localScale += size * growFactor;
    }
}
