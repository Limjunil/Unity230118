using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 관리 관련 라이브러리

public static partial class GFunc
{
    // static 선언이라서 다른 클래스에서 쓸 수 있다.
    public static void QuitThisGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        GameManager.BestSocreReset();
        Application.Quit();
        #endif

    } // QuitThisGame()


    //! 다른 씬을 로드하는 함수
    public static void LoadScene(string sceneName_)
    {
        SceneManager.LoadScene(sceneName_);
    } // LoadScene
}
