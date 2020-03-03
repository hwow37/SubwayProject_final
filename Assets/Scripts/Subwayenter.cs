using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Subwayenter : MonoBehaviour
{
    public GameObject Subway;
    public GameObject PeopleOut;
    public GameObject PeopleIn;
    public GameObject Portal;
    Animator[] PeopleOutSubway;
    Animator[] PeopleInSubway;
    NavMeshAgent[] PeopleOutNav;

    AudioSource Audioplayer;
    public AudioClip Opendoor;
    bool check = true;

    private void Start()
    {
        PeopleOutSubway = PeopleOut.GetComponentsInChildren<Animator>();
        PeopleInSubway = PeopleIn.GetComponentsInChildren<Animator>();
        PeopleOutNav = PeopleOut.GetComponentsInChildren<NavMeshAgent>();
    }
    void OnTriggerEnter(Collider col)   //장애인 전용 탑승 칸 도착하면 출입문 개방 & NPC 하차 및 승차
    {
        Portal.SetActive(false);
        Audioplayer = GetComponent<AudioSource>();
        if (col.gameObject.name == "CenterEyeAnchor" && check == true)
        {
            Subway.GetComponent<Animator>().Play("Subway_Open");
            GameObject.Find("SubwayMusicPlay").GetComponent<AudioSource>().Stop();
            Audioplayer.PlayOneShot(Opendoor);
        }
        if(check == true)
            StartCoroutine(SubwayOut());            //시간 간격을 위한 코루틴 이용
        check = false;
    }
    void SubwayWait()
    {
        for (int i = 0; i < PeopleInSubway.Length; i++)
            PeopleInSubway[i].Play("Idle");
    }
    IEnumerator SubwayOut()     //지하철 내부에 있던 NPC하차
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < PeopleOutSubway.Length; i++)
        {
            PeopleOutNav[i].enabled = true;
            PeopleOutNav[i].GetComponent<MoveAgent>().enabled = true;
            PeopleOutSubway[i].Play("Walking");
        }
        StartCoroutine(SubwayIn());
    }
    IEnumerator SubwayIn()      //대기하던 NPC 승차
    {
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i < PeopleInSubway.Length; i++)
            PeopleInSubway[i].Play("Walking");
        Invoke("SubwayWait", 3);            //3초만 걸어가고 멈춤
        yield break;
    }
}
