using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody playerRigbody = default;
    // �÷��̾� ������
    private const float PLAYER_SPEED = 10.0f;

    // �÷��̾ ź���� ���
    public GameObject PlayerBulletPrefab;
    public int count = 40;
    public float fireRate = 0.1f; // ���� ���� �ֱ�

    public float xValue = 0f;

    public const float Z_VALUE = -8.0f;

    private GameObject[] playerbullets; // �̸� ������ ź�˵�

    private int bulletCount = 0; // ����� ź�� ����

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

            // ź�� ��� ����
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

        } // if : ����
    } // Update()



    //! �÷��̾ ������� �� ȣ���ϴ� �Լ�
    public void Die()
    {
        

        // ������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();

        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);


    }   // Die()


    //! �÷��̾��� �̵� ����
    private void LateUpdate()
    {
        // �÷��̾� ĳ���Ͱ� ȭ�� ���� �ٱ����� ������ ���ϰ� �Ѵ�.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,
            stageData.LimitMin.x, stageData.LimitMax.x), 0f, -9f);
    }

}
