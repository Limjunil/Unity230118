using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // �� ���� ���� ���̺귯��

public static partial class GFunc
{
    // static �����̶� �ٸ� Ŭ�������� �� �� �ִ�.
    public static void QuitThisGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    } // QuitThisGame()


    //! �ٸ� ���� �ε��ϴ� �Լ�
    public static void LoadScene(string sceneName_)
    {
        SceneManager.LoadScene(sceneName_);

    } // LoadScene
}
