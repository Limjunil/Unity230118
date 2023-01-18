using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float playerBulletspeed = 10.0f;

    public string WallChk = string.Empty;

    private Rigidbody playerbulletRgBody = default;

    // Start is called before the first frame update
    void Start()
    {
        playerbulletRgBody = gameObject.GetComponent<Rigidbody>();

        playerbulletRgBody.velocity = transform.up * playerBulletspeed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayerFire()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("Wall"))
        {
            // 벽에 맞으면 다시 false 처리
            gameObject.SetActive(false);

        }
        else if(other.tag.Equals("enemy"))
        {
            // 적에게 맞추면 다시 false 처리
            gameObject.SetActive(false);
        }
    }
}
