using UnityEngine;

public class BottleEnd : MonoBehaviour
{
    [SerializeField] FadeBehaviour sceneManager;
    [SerializeField] private AudioClip getPipeClip;
    [SerializeField] private AudioSource source;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            source.clip = getPipeClip;
            source.Play();
            sceneManager.FadeIn("Credits");
            TimerHandler.Instance.GameEnd();
        }
    }
}
