using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    public Animator animator;

    public bool Attack = false;
    public bool Hurt = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void handleAnimationTriggers()
    {
        if (animator == null) return;
        if (Attack)
        {
            Attack = false;
            animator.SetTrigger("Attack");
        }
        if (Hurt)
        {
            Hurt = false;
            animator.SetTrigger("Hurt");
        }
    }
    void Update()
    {
        handleAnimationTriggers();
    }
}
