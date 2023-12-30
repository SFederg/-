using UnityEngine;

public class Bomb : Enemy
{
    private static readonly int isAppearenceBomb = Animator.StringToHash("is-appearance-bomb");
    private static readonly int isDisappearenceBomb = Animator.StringToHash("is-disappearence-bomb");
    private static readonly int isBoom = Animator.StringToHash("is-boom");

    protected override void StartAppearenceAnimation()
    {
        animator.SetBool(isDisappearenceBomb, false);
        animator.SetBool(isBoom, false);
        animator.SetBool(isAppearenceBomb, true);
    }

    protected override void StartDamagedAnimation()
    {
        animator.SetBool(isDisappearenceBomb, false);
        animator.SetBool(isAppearenceBomb, false);
        animator.SetBool(isBoom, true);
    }

    protected override void StartDisappearenceAnimation()
    {
        animator.SetBool(isAppearenceBomb, false);
        animator.SetBool(isBoom, false);
        animator.SetBool(isDisappearenceBomb, true);
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
