using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jacoCreate : MonoBehaviour
{

    public GameObject jakoPrefabs;

    private GameObject[] jacoenemys; // 미리 생성할 자코들

    public int count = 5;

    private int jacoCount = 0; // 사용할 자코 순번

    private Vector3 jacoPosition = new Vector3(0f, 0f, 32f); // 자코 생성할 위치

    public float xValue = 0f;
    public float zValue = 0f;


    // Start is called before the first frame update
    void Start()
    {

        xValue = -8f;
        zValue = 8f;
        count = 5;

        jacoCount = 0;

        jacoenemys = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            jacoenemys[i] = Instantiate(jakoPrefabs,
                jacoPosition, Quaternion.identity);
            jakoPrefabs.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        float enemyChk = PlayerPrefs.GetFloat("enemycnt");

        if (enemyChk == 5)
        {
            jacoCount = 0;
            PlayerPrefs.SetFloat("enemycnt", 0f);

            xValue = -8f;
            zValue = 8f;
        }

        if (jacoCount == 0)
        {

            for (int i = 0; i < 5; i++)
            {

                jacoenemys[jacoCount].transform.position = new Vector3(xValue, 0f, zValue);

                jacoenemys[jacoCount].SetActive(true);

                xValue += 4f;

                jacoCount++;
                
            }

            
        }

        
    }


}
