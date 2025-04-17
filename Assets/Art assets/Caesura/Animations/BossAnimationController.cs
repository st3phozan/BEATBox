using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private Animator animator;
    private float attackTimer = 0f;
    private bool hasPlayedAngry = false;
    private bool bossActive = true; 

    public float timeBetweenAttacks = 4f;
    
    public EyeManager eyeManager;

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
        
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.IsName("idle")) //Idle & blinking
        {
            if (eyeManager.currentAnimation != 1)
            {
               eyeManager.PlayAnimation(1);
            }
            else if (!eyeManager.isPlaying)
            {
                if (Random.Range(0f, 1f) > 0.999f) //Random chance to blank per idle finished frame.
                {
                    eyeManager.PlayAnimation(1);
                }
            }
        }
        else if (animatorStateInfo.IsName("attack_01")) //Exclamation mark for attack
        {
            if (eyeManager.currentAnimation != 2)
            {
                eyeManager.PlayAnimation(2);
            }
        } else if (animatorStateInfo.IsName("locking dance")) //Happy eyes for winning
        {
            if (eyeManager.currentAnimation != 3)
            {
                eyeManager.PlayAnimation(3);
            }
        } else if (animatorStateInfo.IsName("angey")) //Angry eyes for losing
        {
            if (eyeManager.currentAnimation != 4)
            {
                eyeManager.PlayAnimation(4);
            }
        } else if (animatorStateInfo.IsName("defeated_dying")) //Melting eyes for dying
        {
            if (eyeManager.currentAnimation != 5)
            {
                eyeManager.PlayAnimation(5);
            }
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
        Debug.Log("ANGRYTRIGGERED");
        /*if (hasPlayedAngry)
            return;*/

        ResetAllTriggers();
        animator.SetTrigger("Angry");
        //hasPlayedAngry = true;
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

    public void JumpAttack()
    {
        bossActive = false;
        ResetAllTriggers();
        animator.SetTrigger("JumpAttack");
    }

    void ResetAllTriggers()
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Angry");
        animator.ResetTrigger("Die");
        animator.ResetTrigger("Win");
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("JumpAttack");
    }
}
