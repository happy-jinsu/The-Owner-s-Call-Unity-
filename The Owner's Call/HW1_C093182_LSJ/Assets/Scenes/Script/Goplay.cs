using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goplay : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("Main");
    }
}
