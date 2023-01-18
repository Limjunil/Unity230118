using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{

    public float enemyBulletspeed = 8.0f;

    public string WallChk = string.Empty;

    private Rigidbody enemybulletRgBody = default;

    // Start is called before the first frame update
    void Start()
    {
        enemyBulletspeed = 8.0f;

        enemybulletRgBody = gameObject.GetComponent<Rigidbody>();

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
            // PlayerController ��������
            PlayerControl player = other.GetComponent<PlayerControl>();

            if (player == null || player == default)
            {
                return;
            }

            // �÷��̾��� ��Ʈ���� ���������� ������ ���
            // �Ѿ��� ���� �÷��̾�� �״´�.
            player.Die();
        }
        else if (other.tag.Equals("Wall"))
        {
            // ���� ������ �ٽ� false ó��
            gameObject.SetActive(false);

        }
    }
}