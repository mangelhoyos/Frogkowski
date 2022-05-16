using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudioOnStart : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    void Start()
    {
        AudioManager.Instance.PlayDelayed(clip, 2);
    }

}
