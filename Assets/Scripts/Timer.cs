using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float finishTime;
    [SerializeField] private Image timerLine;
    [HideInInspector] public UnityEvent finished = new UnityEvent();
    private float timeLeft;
    private bool isFinished;

    public void StartTimer()
    {
        timeLeft = finishTime;
        isFinished = false;
    }

    public void StopTimer()
    {
        isFinished = true;
    }

    private void Update()
    {
        if (!isFinished)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerLine.fillAmount = timeLeft / finishTime;
            }
            else
            {
                isFinished = true;
                finished?.Invoke();
            }
        }
    }
}