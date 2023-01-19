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



    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("Wall"))
        {
            // ���� ������ �ٽ� false ó��
            gameObject.SetActive(false);

        }
        
        if(other.tag.Equals("enemy"))
        {

            float Updatescore = PlayerPrefs.GetFloat("scoreNow");
            Updatescore += 1f;

            PlayerPrefs.SetFloat("scoreNow", Updatescore);

            GFunc.ChkenemyCnt();

            // ������ ���߸� �ٽ� false ó��
            gameObject.SetActive(false);
        }
    }
}
