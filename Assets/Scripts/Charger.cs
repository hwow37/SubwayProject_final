using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    public Material OrigianlMat;
    public MeshRenderer ChargerMat;
    public GameObject ChargerUI;
    public Material joystick;
    Material[] Charge = new Material[2];    //충전기에 적용된 머터리얼이 2개 -> 배열로 선언
    bool limit = true;

    void Start()
    {
        Charge = ChargerMat.materials;
        Charge[1] = OrigianlMat;
        //OriginColor = joystick.color;//칼라정보 저장
    }
    void Update()
    {
        //색 점멸
        float flicker = Mathf.Abs(Mathf.Sin(Time.time * 4));
        if(limit == true)
        ChargerMat.materials[1].color = joystick.color * flicker * 2;
    }

    void OnTriggerEnter(Collider col)       //손으로 충전케이블 잡으면 깜빡이는거 중지
    {
        if (col.gameObject.name == "GrabVolumeBig")
        {
            ChargerMat.GetComponent<MeshRenderer>().materials = Charge;
            limit = false; 
            ChargerUI.SetActive(false);
        }     
}
}
