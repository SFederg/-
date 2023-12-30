using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float timeUntilActivationConst;

    private float timeUntilDeactivationConst;
    private float timeUntilActivation;
    private float timeUntilDeactivation;
    private bool isActive;
    private bool isFirstActive;

    protected Animator animator;

    public bool IsFirstActive => isFirstActive;

    protected abstract void StartAppearenceAnimation();

    protected abstract void StartDisappearenceAnimation();

    protected abstract void StartDamagedAnimation();

    public void ResetFirstActive()
    {
        isFirstActive = true;
        timeUntilActivation = timeUntilActivationConst;
        timeUntilDeactivation = timeUntilDeactivationConst;
    }

    public void Deactivate()
    {
        isFirstActive = false;
        isActive = false;
    }

    protected virtual void Start()
    {
        timeUntilDeactivationConst = 5f;
        animator = GetComponent<Animator>();
        isActive = false;
        isFirstActive = true;
        timeUntilActivation = timeUntilActivationConst;
        timeUntilDeactivation = timeUntilDeactivationConst;
    }

    protected virtual void Update()
    {
        if (isFirstActive)
        {
            if (!isActive)
            {
                timeUntilActivation -= Time.deltaTime;
                if (timeUntilActivation <= 0)
                {
                    isActive = true;
                    StartAppearenceAnimation();
                }
            }
            else
            {
                timeUntilDeactivation -= Time.deltaTime;
                if (timeUntilDeactivation <= 0)
                {
                    StartDisappearenceAnimation();
                }
            }
        }
    }
}