using UnityEngine;

public class TextFloatingAnimation : MonoBehaviour
{
    [SerializeField] AnimationCurve floatingCurve;
    [SerializeField] private bool zAxisAnimation = true;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(zAxisAnimation)
        {
            transform.localPosition = new Vector3(0,0,floatingCurve.Evaluate(timer));
        }
        else
        {
            transform.localPosition = new Vector3(0,floatingCurve.Evaluate(timer),0);
        }
    }
}
