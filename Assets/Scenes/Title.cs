// Title.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // 좌클릭되었으면
            SceneManager.LoadScene("Main"); // Main scene 이동
        }
    }
    private GUIStyle guiStyle = new GUIStyle();
    void OnGUI()
    {
        guiStyle.fontSize = 40; // Font size 변경
        guiStyle.normal.textColor = Color.red; // Font color 변경
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 128, 32), "Title", guiStyle); // 화면에 'title'이라고 표시.
    }
}