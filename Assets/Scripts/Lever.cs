using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject LeverUI;
    public GameObject Chargerhole;
    public GameObject Charger;
    public GameObject Flickerdis;
    public GameObject Info;
    public GameObject Handle2;
    private GameObject Directions2;

    public Material OrigianlMat;
    public MeshRenderer LeverMat;

    AudioSource Audioplayer;
    public AudioClip Beep;           //소리
    bool limit = true;
    void Awake()
    {
        Audioplayer = GetComponent<AudioSource>();
        Directions2 = GameObject.Find("Directions2");
    }
    void Start()
    {
        Info.SetActive(false);
        Directions2.SetActive(false);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "LeverTrigger" && limit == true)
        {
            limit = false;
            Audioplayer.PlayOneShot(Beep);
            LeverUI.SetActive(false);
            Chargerhole.SetActive(false);
            Charger.SetActive(true);
            LeverMat.material = OrigianlMat;
            Flickerdis.GetComponent<Flicker>().enabled = false;
            Info.SetActive(true);
            Handle2.SetActive(true);
            //this.GetComponent<SphereCollider>().enabled = false;        //레버 누르면 손가락 콜리더 삭제

            var direction = GameObject.FindGameObjectsWithTag("Directions1");
            for (int i = 0; i < direction.Length ; i++)
            {
                direction[i].SetActive(false);
            }
            Directions2.SetActive(true);
        }//레버 밀면 충전케이블 원래대로
    }
}
