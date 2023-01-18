using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jakoControl : MonoBehaviour
{

    private Rigidbody enemyRigbody = default;
    
    private const float ENEMY_SPEED = 9.0f;

    // 적이 탄알을 쏘기
    public GameObject enemyBulletPrefab;
    public int count = 15;
    public float fireRate = 1000.0f; // 최초 생성 주기

    public float xValue = 0f;
    public float zValue = 0f;

    private float scoreNow = 0f;


    private GameObject[] enemyjakobullets; // 미리 생성할 탄알들

    private int bulletCount = 0; // 사용할 탄알 순번

    private Vector3 bulletPosition = new Vector3(0f, 0f, 31.0f);

    private float timeAfterSpawn = 0f;


    // Start is called before the first frame update
    void Start()
    {
        scoreNow = 0f;
        PlayerPrefs.SetFloat("scoreNow", scoreNow);

        enemyRigbody = gameObject.GetComponent<Rigidbody>();

        enemyjakobullets = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            enemyjakobullets[i] = Instantiate(enemyBulletPrefab,
                bulletPosition, Quaternion.identity);
            enemyBulletPrefab.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        


        //float xSpeed = xInput * ENEMY_SPEED;

        //Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);

        //enemyRigbody.velocity = newVelocity;

        timeAfterSpawn += Time.deltaTime;

        // 탄알 쏘는 조건
        if (fireRate < timeAfterSpawn)
        {
            timeAfterSpawn = 0f;

            if (15 <= bulletCount)
            {
                bulletCount = 0;
            }

            xValue = gameObject.transform.position.x;
            zValue = gameObject.transform.position.z;


            enemyjakobullets[bulletCount].transform.position = new Vector3(xValue, 0, zValue - 1f);
            enemyjakobullets[bulletCount].transform.rotation = Quaternion.Euler(90, 180, 0);
            enemyjakobullets[bulletCount].SetActive(true);
            bulletCount++;


        }
    }



    public void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("PlayerBullet"))
        {
            
            PlayerBullet playerBullet = other.GetComponent<PlayerBullet>();

            if (playerBullet == null || playerBullet == default)
            {
                return;
            }
            else
            {
                scoreNow += 1f;
                PlayerPrefs.SetFloat("scoreNow", scoreNow);
            }

            // 적에게 맞추면 다시 false 처리
            gameObject.SetActive(false);
        }
    }
}
