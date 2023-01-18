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
            // ���� ������ �ٽ� false ó��
            gameObject.SetActive(false);

        }
        else if(other.tag.Equals("enemy"))
        {
            // ������ ���߸� �ٽ� false ó��
            gameObject.SetActive(false);
        }
    }
}
