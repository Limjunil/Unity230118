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


    private const string SCENE_NAME = "PlayScene";
    private const string BEST_SCORE = "BestScore";
    // ����
    private static float scoreNow = default;

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


        // } ����� �ؽ�Ʈ ������Ʈ�� ã�ƿ´�.

        scoreNow = 0f;
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
        float ScoreNow = PlayerPrefs.GetFloat("scoreNow");

        scoreNow = ScoreNow;

        GFunc.SetTxt(scoreNowTxtObj, $"���� ���ھ� : {ScoreNow}");

        float bestScore = PlayerPrefs.GetFloat(BEST_SCORE);

        GFunc.SetTxt(scorehighTxtObj, $"�ְ� ���ھ�\n{bestScore}");

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
}
