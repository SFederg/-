using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float timeUntilActivationConst;
    private float timeUntilDeactivationConst;
    private float timeUntilActivation;
    private float timeUntilDeactivation;
    public bool isActive;

    protected virtual void Start()
    {
        timeUntilDeactivationConst = 5f;
        isActive = false;
        timeUntilActivation = timeUntilActivationConst;
        timeUntilDeactivation = timeUntilDeactivationConst;
    }

    protected virtual void Update()
    {
        if (!isActive)
        {
            timeUntilActivation -= Time.deltaTime;
            if (timeUntilActivation <= 0)
            {
                timeUntilActivation = timeUntilActivationConst;
            }
        }
        else
        {
            timeUntilDeactivation -= Time.deltaTime;
            if (timeUntilDeactivation <= 0)
            {
                isActive = false;
                gameObject.SetActive(isActive);
                timeUntilDeactivation = timeUntilDeactivationConst;
            }
        }
    }
}