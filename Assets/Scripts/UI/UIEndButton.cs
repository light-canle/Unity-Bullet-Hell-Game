using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndButton : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
    //[출처] [Unity3D] 게임 종료 스크립트|작성자 유알
}
