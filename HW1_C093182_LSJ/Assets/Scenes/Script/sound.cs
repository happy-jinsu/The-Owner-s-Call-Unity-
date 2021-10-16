using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sound : MonoBehaviour
{
    static AudioSource audioS;
    public static AudioClip audioC;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioC = Resources.Load<AudioClip>("HPMin");   
    }

    // Update is called once per frame
    void soundPlay()
    {

    }
}
