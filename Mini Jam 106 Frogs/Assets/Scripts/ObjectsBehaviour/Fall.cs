using UnityEngine;

public class Fall : MonoBehaviour
{
    [SerializeField] private FadeBehaviour sceneChanger;
    [SerializeField] private AudioClip getPipeClip;
    [SerializeField] private AudioSource source;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            source.clip = getPipeClip;
            source.Play();
            sceneChanger.FadeIn("Game");
        }
    }
}
