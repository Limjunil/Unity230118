using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // 게임 오버시 활성화할 텍스트 게임 오브젝트
    private GameObject gameOverTxtObj = default;

    //!< 생존 시간을 표시할 텍스트
    private GameObject scoreNowTxtObj = default;

    //!< 최고 기록을 표시할 텍스트
    private GameObject scorehighnowTxtObj = default;
    private GameObject scorehighTxtObj = default;

    //!< 현재 체력을 표시할 텍스트
    private GameObject HpvalueTxtObj = default;


    private const string SCENE_NAME = "PlayScene";
    private const string BEST_SCORE = "BestScore";
    // 점수
    private float scoreNow = default;

    // 체력
    private float HpvalueCut = default;


    // 게임 오버 상태
    private bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        // { 출력할 텍스트 오브젝트를 찾아온다.
        GameObject uiObjs_ = GFunc.GetRootObj("UiObj");


        scoreNowTxtObj = uiObjs_.FindChildObj("scoreNow");
        gameOverTxtObj = uiObjs_.FindChildObj("gameoverTxt");
        scorehighnowTxtObj = uiObjs_.FindChildObj("scorehighnow");
        scorehighTxtObj = uiObjs_.FindChildObj("scorehigh");
        HpvalueTxtObj = uiObjs_.FindChildObj("Hpvalue");

        // } 출력할 텍스트 오브젝트를 찾아온다.

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

            } // if : R 키 입력 시 재시작

            if (Input.GetKeyDown(KeyCode.Q))
            {

               GFunc.QuitThisGame();

            } // if : Q 키 입력 시 종료
        }   // if : 게임 오버인 경우


        // 현재 점수를 갱신한다.
        scoreNow = PlayerPrefs.GetFloat("scoreNow");

        GFunc.SetTxt(scoreNowTxtObj, $"현재 스코어 : {scoreNow}");

        float bestScore = PlayerPrefs.GetFloat(BEST_SCORE);

        GFunc.SetTxt(scorehighTxtObj, $"최고 스코어\n{bestScore}");

        // 현재 체력을 갱신한다.

        HpvalueCut = PlayerPrefs.GetFloat("Hpvalue");

        GFunc.SetTxt(HpvalueTxtObj, $"현재 체력 : {HpvalueCut}");

    }

    //! 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        isGameOver = true;

        // gameOverTxtObj의 크기를 1, 1, 1로 변경한다
        gameOverTxtObj.transform.localScale = Vector3.one;

        // BestTime 키로 저장된 이전까지의 최고 기록 가져오기

        float bestScore = PlayerPrefs.GetFloat(BEST_SCORE);

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 긴 경우
        if (bestScore < scoreNow)
        {
            bestScore = scoreNow;
            PlayerPrefs.SetFloat(BEST_SCORE, bestScore);
        } // if : 현재 

        // 최고 기록을 텍스트에 갱신한다.

        GFunc.SetTxt(scorehighnowTxtObj, $"Best Score : {bestScore}");
        GFunc.SetTxt(scorehighTxtObj, $"최고 스코어\n{bestScore}");

    }

    public static void BestSocreReset()
    {
        PlayerPrefs.SetFloat(BEST_SCORE, 0f);
    }
}
