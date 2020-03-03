using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripTraining : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource Audioplayer;
    public AudioClip CorrectSound;
    public GameObject GripController;
    public GameObject GripText;
    public GameObject GripEndText;
    bool check = true;
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "GrabVolumeBig" && check == true)
        {
            check = false;
            Audioplayer = GetComponent<AudioSource>();
            GripController.SetActive(false);
            Audioplayer.PlayOneShot(CorrectSound);
            this.gameObject.GetComponent<Flicker>().enabled = false;
            GripText.SetActive(false);
            GripEndText.SetActive(true);
        }
    }
}
