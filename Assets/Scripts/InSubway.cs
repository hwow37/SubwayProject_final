using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InSubway : MonoBehaviour
{
    public GameObject Subway;
    public GameObject WheelchairText;
    public GameObject EndText;
    bool check = true;

    AudioSource Audioplayer;
    public AudioClip EndProject;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CenterEyeAnchor" && check == true)  //휠체어칸 도착 시 실행되는 명령들
        {
            Subway.GetComponent<Animator>().Play("Subway_Close");
            Audioplayer = GetComponent<AudioSource>();
            Audioplayer.PlayOneShot(EndProject);

            GameObject.Find("Portal_001").SetActive(false);
            WheelchairText.SetActive(false);
            EndText.SetActive(true);
            check = false;
            Invoke("First", 10.0f);     //10초뒤 시작화면 로드
        }
    }
    private void First()            //시작화면 복귀
    {
        SceneManager.LoadScene("Main");
    }
}
