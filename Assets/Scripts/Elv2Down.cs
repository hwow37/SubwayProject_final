using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elv2Down : MonoBehaviour
{
    AudioSource Audioplayer;
    public AudioClip Beep;           //소리
    private bool limit = true;
    void OnTriggerEnter(Collider col)
    {
        Audioplayer = GetComponent<AudioSource>();
        if (col.gameObject.name == "DownButton2" && limit == true)   //엘베버튼 누르면 내려감
        {
            limit = false;
            Audioplayer.PlayOneShot(Beep);
            col.gameObject.GetComponent<Button>().onClick.Invoke();
        }
        if (col.gameObject.name == "B4Button" && limit == false)   //엘베버튼 누르면 내려감
        {
            limit = true;
            Audioplayer.PlayOneShot(Beep);
            col.gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
