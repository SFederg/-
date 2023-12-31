using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float timeUntilActivationConst;
    [HideInInspector] public UnityEvent damaged = new UnityEvent();

    private float timeUntilDeactivationConst;
    private float timeUntilActivation;
    private float timeUntilDeactivation;
    private bool isActive;
    private bool isFirstActive;
    private bool isDamaged;
    private bool canDamaged;

    protected Animator animator;

    public bool IsFirstActive => isFirstActive;

    public bool IsDamaged => isDamaged;

    protected abstract void StartAppearenceAnimation();

    protected abstract void StartDisappearenceAnimation();

    protected abstract void StartDamagedAnimation();

    public void ResetFirstActive()
    {
        isFirstActive = true;
        isDamaged = false;
        timeUntilActivation = timeUntilActivationConst;
        timeUntilDeactivation = timeUntilDeactivationConst;
        canDamaged = true;
    }

    public void Deactivate()
    {
        isFirstActive = false;
        isActive = false;
        canDamaged = true;
    }

    public void CantDamage()
    {
        canDamaged = false;
    }

    protected virtual void Start()
    {
        timeUntilDeactivationConst = 5f;
        animator = GetComponent<Animator>();
        isActive = false;
        isFirstActive = true;
        canDamaged = true;
        timeUntilActivation = timeUntilActivationConst;
        timeUntilDeactivation = timeUntilDeactivationConst;
    }

    protected virtual void Update()
    {
        if (isFirstActive && !isDamaged)
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

    private void OnMouseDown()
    {
        if (!isDamaged && isActive && canDamaged)
        {
            isDamaged = true;
            damaged?.Invoke();
            StartDamagedAnimation();
        }
    }
}