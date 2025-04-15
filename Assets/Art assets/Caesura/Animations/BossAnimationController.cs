using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private Animator animator;
    private float attackTimer = 0f;
    private bool hasPlayedAngry = false;
    private bool bossActive = true; 

    public float timeBetweenAttacks = 4f;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetIdle();
    }

    void Update()
    {
        if (!bossActive)
            return;

        attackTimer += Time.deltaTime;

        if (attackTimer >= timeBetweenAttacks)
        {
            PlayAttack();
            attackTimer = 0f;
        }
    }

    public void ActivateBoss()
    {
        bossActive = true;
        attackTimer = 0f;
    }

    public void PlayAttack()
    {
        ResetAllTriggers();
        animator.SetTrigger("Attack");
    }

    public void TriggerAngry()
    {
        if (hasPlayedAngry)
            return;

        ResetAllTriggers();
        animator.SetTrigger("Angry");
        hasPlayedAngry = true;
    }

    public void PlayerWin()
    {
        bossActive = false;
        ResetAllTriggers();
        animator.SetTrigger("Die");
    }

    public void PlayerLoose()
    {
        bossActive = false;
        ResetAllTriggers();
        animator.SetTrigger("Win");
    }

    public void SetIdle()
    {
        ResetAllTriggers();
        animator.SetTrigger("Idle");
    }

    void ResetAllTriggers()
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Angry");
        animator.ResetTrigger("Die");
        animator.ResetTrigger("Win");
        animator.ResetTrigger("Idle");
    }
}
