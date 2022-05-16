using UnityEngine;

public class LocutionTrigger : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(clip);
            Destroy(gameObject);
        }
    }
}
