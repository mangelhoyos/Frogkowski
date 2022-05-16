using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {private set; get;}
    [SerializeField] private AudioSource source;

    void Awake() => Instance = this;

    public void PlaySound(AudioClip clip)
    {
        source.Stop();

        source.clip = clip;
        source.Play();
    }

    public void PlayDelayed(AudioClip clip, float delaySeconds)
    {
        source.Stop();

        source.clip = clip;
        source.PlayDelayed(delaySeconds);
    }
}
