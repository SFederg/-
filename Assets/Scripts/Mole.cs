using UnityEngine;

public class Mole : Enemy
{
    private static readonly int isAppearenceMole = Animator.StringToHash("is-appearance-mole");
    private static readonly int isDisappearenceMole = Animator.StringToHash("is-disappearence-mole");
    private static readonly int isDamaged = Animator.StringToHash("is-damaged");

    protected override void StartAppearenceAnimation()
    {
        animator.SetBool(isDisappearenceMole, false);
        animator.SetBool(isDamaged, false);
        animator.SetBool(isAppearenceMole, true);
    }

    protected override void StartDamagedAnimation()
    {
        animator.SetBool(isDisappearenceMole, false);
        animator.SetBool(isAppearenceMole, false);
        animator.SetBool(isDamaged, true);
    }

    protected override void StartDisappearenceAnimation()
    {
        animator.SetBool(isAppearenceMole, false);
        animator.SetBool(isDamaged, false);
        animator.SetBool(isDisappearenceMole, true);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
