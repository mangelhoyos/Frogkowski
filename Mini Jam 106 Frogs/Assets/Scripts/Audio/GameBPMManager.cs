using UnityEngine;

public class GameBPMManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] bpmClips;
    private int actualBPM = 0;

    public void NextBPM(int bpm)
    {
        actualBPM = bpm;
        float audioPlayedPercentage = audioSource.time / audioSource.clip.length;
        audioSource.Stop();
        audioSource.clip = bpmClips[actualBPM];

        float newTime = audioSource.clip.length * audioPlayedPercentage;
        audioSource.time = newTime;
        audioSource.Play();
    }

    public void EndBPM()
    {
        audioSource.Stop();
    }
}
