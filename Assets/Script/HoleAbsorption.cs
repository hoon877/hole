using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleAbsorption : MonoBehaviour
{
    public float absorbSpeed = 0.5f;
    //이벤트 헨들러
    public event Action<int> OnAbsorb;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            // 천천히 블랙홀 중심으로 이동
            Vector3 dir = (transform.position - other.transform.position).normalized;
            other.transform.position += dir * absorbSpeed * Time.deltaTime;
            other.transform.position += Vector3.down * absorbSpeed * Time.deltaTime;
            
            float holeY = transform.position.y;
            float objectY = other.transform.position.y;

            // 충분히 가까워지면 흡수 처리
            if (Mathf.Abs(holeY-objectY)>0.05)
            {
                other.gameObject.SetActive(false);
                // 이벤트 발생
                OnAbsorb?.Invoke(1);
            }
        }
    }
}
