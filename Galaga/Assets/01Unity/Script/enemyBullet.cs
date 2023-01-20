using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public GameObject player;

    public float enemyBulletspeed = 8.0f;

    public string WallChk = string.Empty;

    private Rigidbody enemybulletRgBody = default;

    // Start is called before the first frame update
    void Start()
    {
        enemyBulletspeed = 8.0f;

        enemybulletRgBody = gameObject.GetComponent<Rigidbody>();

        player = GameObject.FindWithTag("Player");

        enemybulletRgBody.velocity = transform.up * enemyBulletspeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            // PlayerController 가져오기
            PlayerControl player = other.GetComponent<PlayerControl>();

            if (player == null || player == default)
            {
                return;
            }

            gameObject.SetActive(false);


            float damage = PlayerPrefs.GetFloat("Hpvalue");

            player.gameObject.SetActive(false);

            damage -= 1f;

            if (damage == 0)
            {
                PlayerPrefs.SetFloat("Hpvalue", damage);
                // 플레이어의 컨트롤을 정상적으로 가져온 경우
                // 총알을 맞은 플레이어는 죽는다.
                player.Die();
            }
            else
            {
                PlayerPrefs.SetFloat("Hpvalue", damage);

                // Deleyplayer() 함수를 0.5초 후 실행
                Invoke("Deleyplayer", 0.5f);

            }
        }
        else if (other.tag.Equals("Wall"))
        {
            // 벽에 맞으면 다시 false 처리
            gameObject.SetActive(false);

        }
    }

    void Deleyplayer()
    {
        player.gameObject.SetActive(true);
    }
}
