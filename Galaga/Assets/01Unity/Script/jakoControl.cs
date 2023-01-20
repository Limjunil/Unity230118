using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class jakoControl : MonoBehaviour
{

    private Rigidbody enemyRigbody = default;

    
    // ���� ź���� ���
    public GameObject enemyBulletPrefab;
    public int count;
    public float fireRate = 0.8f; // ���� ���� �ֱ�

    public float xValue = 0f;
    public float zValue = 0f;
    public bool movechk = false;

    private GameObject[] enemyjakobullets; // �̸� ������ ź�˵�

    private int bulletCount = 0; // ����� ź�� ����

    private Vector3 bulletPosition = new Vector3(0f, 0f, 31.0f);

    private float timeAfterSpawn = 0f;

    public float xMin = 0f;
    public float xMax = 0f;


    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.8f;

        count = 20;
        movechk = false;

        xMin = -18f;
        xMax = 18f;

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
        
        timeAfterSpawn += Time.deltaTime;

        // ź�� ��� ����
        if (fireRate < timeAfterSpawn)
        {
            Actjako();

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

    private void OnDisable()
    {
        timeAfterSpawn = 0;
    }

    public void Actjako()
    {
        
        float xchk = gameObject.transform.position.x;
        float zchk = gameObject.transform.position.z;


        if (xMin >= xchk)
        {
            movechk = true;
        }
        else if (xMax <= xchk)
        {
            movechk = false;
        }



        if (movechk == false)
        {
            if(xMax <= xchk)
            {
                zchk -= 2f;
            }
            xchk -= 2f;
            gameObject.transform.position = new Vector3(xchk, 0f, zchk);
        }
        else
        {
            if(xMin >= xchk)
            {
                zchk -= 2f;

            }
            xchk += 2f;
            gameObject.transform.position = new Vector3(xchk, 0f, zchk);
        }

    }



    public void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("PlayerBullet"))
        {

            movechk = false;
            // �ٽ� false ó��
            gameObject.SetActive(false);
        }
    }


}
