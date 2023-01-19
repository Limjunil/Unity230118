using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // ���� ������ Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    private GameObject gameOverTxtObj = default;

    //!< ���� �ð��� ǥ���� �ؽ�Ʈ
    private GameObject scoreNowTxtObj = default;

    //!< �ְ� ����� ǥ���� �ؽ�Ʈ
    private GameObject scorehighnowTxtObj = default;
    private GameObject scorehighTxtObj = default;

    //!< ���� ü���� ǥ���� �ؽ�Ʈ
    private GameObject HpvalueTxtObj = default;


    private const string SCENE_NAME = "PlayScene";
    private const string BEST_SCORE = "BestScore";
    // ����
    private float scoreNow = default;

    // ü��
    private float HpvalueCut = default;


    // ���� ���� ����
    private bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        // { ����� �ؽ�Ʈ ������Ʈ�� ã�ƿ´�.
        GameObject uiObjs_ = GFunc.GetRootObj("UiObj");


        scoreNowTxtObj = uiObjs_.FindChildObj("scoreNow");
        gameOverTxtObj = uiObjs_.FindChildObj("gameoverTxt");
        scorehighnowTxtObj = uiObjs_.FindChildObj("scorehighnow");
        scorehighTxtObj = uiObjs_.FindChildObj("scorehigh");
        HpvalueTxtObj = uiObjs_.FindChildObj("Hpvalue");

        // } ����� �ؽ�Ʈ ������Ʈ�� ã�ƿ´�.

        HpvalueCut = 0f;
        PlayerPrefs.SetFloat("Hpvalue", 3f);

        scoreNow = 0f;
        PlayerPrefs.SetFloat("scoreNow", scoreNow);

        PlayerPrefs.SetFloat("enemycnt", 0f);

        isGameOver = false;

        gameOverTxtObj.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                GFunc.LoadScene(SCENE_NAME);

            } // if : R Ű �Է� �� �����

            if (Input.GetKeyDown(KeyCode.Q))
            {

               GFunc.QuitThisGame();

            } // if : Q Ű �Է� �� ����
        }   // if : ���� ������ ���


        // ���� ������ �����Ѵ�.
        scoreNow = PlayerPrefs.GetFloat("scoreNow");

        GFunc.SetTxt(scoreNowTxtObj, $"���� ���ھ� : {scoreNow}");

        float bestScore = PlayerPrefs.GetFloat(BEST_SCORE);

        GFunc.SetTxt(scorehighTxtObj, $"�ְ� ���ھ�\n{bestScore}");

        // ���� ü���� �����Ѵ�.

        HpvalueCut = PlayerPrefs.GetFloat("Hpvalue");

        GFunc.SetTxt(HpvalueTxtObj, $"���� ü�� : {HpvalueCut}");

    }

    //! ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        isGameOver = true;

        // gameOverTxtObj�� ũ�⸦ 1, 1, 1�� �����Ѵ�
        gameOverTxtObj.transform.localScale = Vector3.one;

        // BestTime Ű�� ����� ���������� �ְ� ��� ��������

        float bestScore = PlayerPrefs.GetFloat(BEST_SCORE);

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� �� ���
        if (bestScore < scoreNow)
        {
            bestScore = scoreNow;
            PlayerPrefs.SetFloat(BEST_SCORE, bestScore);
        } // if : ���� 

        // �ְ� ����� �ؽ�Ʈ�� �����Ѵ�.

        GFunc.SetTxt(scorehighnowTxtObj, $"Best Score : {bestScore}");
        GFunc.SetTxt(scorehighTxtObj, $"�ְ� ���ھ�\n{bestScore}");

    }

    public static void BestSocreReset()
    {
        PlayerPrefs.SetFloat(BEST_SCORE, 0f);
    }
}
