using UnityEngine;

public class TimerHandler : MonoBehaviour
{
    public static TimerHandler Instance {private set; get;}
    [SerializeField] private float maxTimer;
    [SerializeField] private int addTimerValue;
    float timerDivisor;
    float timer;
    [SerializeField] private GameBPMManager bpmManager;
    [SerializeField] private FadeBehaviour fadeBehaviour;
    
    [SerializeField] private AudioClip getPipeClip;
    [SerializeField] private AudioSource source;
    int actualBPM = 0;
    private bool gameEnded = false;
    
    private void Awake() 
    {
        Instance = this;
    }

    void Start()
    {
        timer = maxTimer;
        timerDivisor = maxTimer / 4;
    }

    void Update()
    {
        if(!gameEnded)
        {
            timer -= Time.deltaTime;

            CheckTimer();
        }
    }

    public void GameEnd()
    {
        gameEnded = true;
    }

    public void AddTime()
    {
        timer += addTimerValue;
        timer = Mathf.Clamp(timer, 0, maxTimer);
    }

    void CheckTimer()
    {
        if(timer > timerDivisor * 3 && actualBPM != 0)
        {
            bpmManager.NextBPM(0);
            actualBPM = 0;    
        }
        else if(timer > timerDivisor * 2 && timer < timerDivisor * 3 && actualBPM != 1)
        {
            bpmManager.NextBPM(1);
            actualBPM = 1;
        }
        else if(timer > timerDivisor && timer < timerDivisor * 2 && actualBPM != 2)
        {
            bpmManager.NextBPM(2);
            actualBPM = 2;
        }
        else if(timer > 0 && timer < timerDivisor && actualBPM != 3)
        {
            bpmManager.NextBPM(3);
            actualBPM = 3;
        }
        else if(actualBPM != 4 && timer <= 0)
        {
            bpmManager.EndBPM();
            fadeBehaviour.FadeIn("Game");
            source.clip = getPipeClip;
            source.Play();
            actualBPM = 4;
        }
    }
}
