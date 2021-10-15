using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingUI : MonoBehaviour
{
    public GameObject Stop;
    bool stoped = false;
    void Start()
    {
        Stop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("settingButton"))
        {
            stoped = !stoped;
        }

        if(stoped)
        {
            Stop.SetActive(true);
            Time.timeScale = 0;
        }

        if(!stoped)
        {
            Stop.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void StartScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
    public void End()
    {
        Application.Quit();
    }
}
