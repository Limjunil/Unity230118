using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody playerRigbody = default;
    // 플레이어 움직임
    private const float PLAYER_SPEED = 10.0f;

    // 플레이어가 탄알을 쏘기
    public GameObject PlayerBulletPrefab;
    public int count = 40;
    public float fireRate = 0.1f; // 최초 생성 주기

    public float xValue = 0f;

    public const float Z_VALUE = -8.0f;

    private GameObject[] playerbullets; // 미리 생성할 탄알들

    private int bulletCount = 0; // 사용할 탄알 순번

    private Vector3 bulletPosition = new Vector3(0f, 0f, 30f);

    private float timeAfterSpawn = 0f;

    [SerializeField]
    private StageData stageData;


    // Start is called before the first frame update
    void Start()
    {
        
        playerRigbody = gameObject.GetComponent<Rigidbody>();

        playerbullets = new GameObject[count];

        for(int i = 0; i < count; i++)
        {
            playerbullets[i] = Instantiate(PlayerBulletPrefab, 
                bulletPosition, Quaternion.identity);
            PlayerBulletPrefab.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        
        float xSpeed = xInput * PLAYER_SPEED;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, 0f);

        playerRigbody.velocity = newVelocity;

        timeAfterSpawn += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z))
        {

            // 탄알 쏘는 조건
            if (fireRate <= timeAfterSpawn)
            {
                timeAfterSpawn = 0f;

                if (20 <= bulletCount)
                {
                    bulletCount = 0;
                }

                xValue = gameObject.transform.position.x;

                playerbullets[bulletCount].transform.position = new Vector3(xValue - 0.5f, 0, Z_VALUE);
                playerbullets[bulletCount].transform.rotation = Quaternion.Euler(90, 0, 0);
                playerbullets[bulletCount].SetActive(true);
                bulletCount++;

                playerbullets[bulletCount].transform.position = new Vector3(xValue + 0.5f, 0, Z_VALUE);
                playerbullets[bulletCount].transform.rotation = Quaternion.Euler(90, 0, 0);
                playerbullets[bulletCount].SetActive(true);

                bulletCount++;


            }

        } // if : 공격
    } // Update()



    //! 플레이어가 사망했을 때 호출하는 함수
    public void Die()
    {
        

        // 가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();

        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);


    }   // Die()


    //! 플레이어의 이동 제한
    private void LateUpdate()
    {
        // 플레이어 캐릭터가 화면 범위 바깥으로 나가지 못하게 한다.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,
            stageData.LimitMin.x, stageData.LimitMax.x), 0f, -9f);
    }

}
