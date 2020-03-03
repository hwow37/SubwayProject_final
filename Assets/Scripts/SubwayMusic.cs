using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayMusic : MonoBehaviour            //지하철이 들어오고 있다는 안내 음성 재생

{
    AudioSource Audioplayer;
    public AudioClip SubwayComing;
    bool check = true;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CenterEyeAnchor" && check == true)
        {
            Audioplayer = GetComponent<AudioSource>();
            Audioplayer.PlayOneShot(SubwayComing);
            check = false;
        }
    }
}
