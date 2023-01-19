using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScroller : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float scrollRange = 20f;

    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private Vector3 moveDirection = Vector3.back;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 배경이 moveDirection 방향으로 speed 속도로 이동
        transform.position += moveDirection * speed * Time.deltaTime;

        // 배경이 설정된 범위를 벗어나면 위치 재설정
        if(transform.position.z <= -scrollRange)
        {
            transform.position = target.position + Vector3.forward * scrollRange;
        }


    }
}
