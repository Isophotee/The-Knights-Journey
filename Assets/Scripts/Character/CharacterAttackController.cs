using UnityEngine;

public class CharacterAttackController : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float comboDuration = 0.4f;

    [Header("References")]
    [SerializeField] private Animator animator;

    // Attack state tracking
    private int currentComboStep = 0;
    private float lastAttackTime;
    private float comboResetTimer;

    // Animation hashes for optimization
    private int attackTriggerHash;
    private int comboStepHash;

    private void Awake()
    {
        // Ensure animator is set
        if (animator == null)
            animator = GetComponent<Animator>();

        // Create animation parameter hashes
        attackTriggerHash = Animator.StringToHash("Attack");
        comboStepHash = Animator.StringToHash("ComboStep");
    }

    private void Update()
    {
        // Check for attack input
        if (Input.GetButtonDown("Attack"))
        {
            PerformAttack();
        }

        // Handle combo reset timer
        if (currentComboStep > 0)
        {
            comboResetTimer += Time.deltaTime;
            if (comboResetTimer >= comboDuration)
            {
                ResetCombo();
            }
        }
    }

    private void PerformAttack()
    {
        // Check if enough time has passed since last attack
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            // Increment combo step
            currentComboStep = (currentComboStep % 3) + 1;
            
            // Reset combo reset timer
            comboResetTimer = 0f;

            // Set animator parameters
            animator.SetInteger(comboStepHash, currentComboStep);
            animator.SetTrigger(attackTriggerHash);

            // Record attack time
            lastAttackTime = Time.time;
        }
    }

    private void ResetCombo()
    {
        currentComboStep = 0;
        animator.SetInteger(comboStepHash, 0);
    }

    // Optional method to be called by animation events to reset combo
    public void OnAttackAnimationEnd()
    {
        ResetCombo();
    }
}