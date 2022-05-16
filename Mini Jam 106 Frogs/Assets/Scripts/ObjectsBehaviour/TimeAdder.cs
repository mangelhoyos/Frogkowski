using UnityEngine;

public class TimeAdder : MonoBehaviour
{
    [SerializeField] private AudioClip getPipeClip;
    [SerializeField] private AudioSource source;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            AddTime();
            source.clip = getPipeClip;
            source.Play();
            Destroy(gameObject);
        }
    }

    void AddTime()
    {
        TimerHandler.Instance.AddTime();
    }

}
