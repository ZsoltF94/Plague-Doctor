using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    InputSystem_Actions inputActions;
    AttackHitBox attackHitBoxScript;
    Animator animator;


    [SerializeField] private GameObject attackHitBox;
    [SerializeField] private float attackCooldown = 0.3f;
    [SerializeField] private float attackduration = 0.2f;
    [SerializeField] private float attacksize = 1f;
    [SerializeField] public float attackValue = 5f;

    private bool canAttack = true;


    void Awake()
    {
        inputActions = new InputSystem_Actions();
        attackHitBoxScript = attackHitBox.GetComponent<AttackHitBox>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        UpdateAnimation();
    }


    public void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Attack.performed += OnAttack;
    }

    public void OnDisable()
    {
        inputActions.Player.Attack.performed -= OnAttack;
        inputActions.Disable();
    }

    private void OnAttack(InputAction.CallbackContext ctx)
    {
        Attack();
    }

    public void Attack()
    {
        if (!canAttack) return;
        StartCoroutine(Performeattack());
    }

    private IEnumerator Performeattack()
    {
        canAttack = false;
        attackHitBoxScript.SetDamageAmount(attackValue);

        // set hitbox position to mouse
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPosition.z = 0;
        Vector2 direction = (mouseWorldPosition - transform.position).normalized;
        attackHitBox.transform.localPosition = direction * 0.7f;

        // set hitbox bigger
        attackHitBox.transform.localScale *= attacksize;

        // set hitbox active for attackduration
        attackHitBox.SetActive(true);

        yield return new WaitForSeconds(attackduration);
        attackHitBox.SetActive(false);

        // set canattack true after attackcooldown
        yield return new WaitForSeconds(attackCooldown - attackduration);
        canAttack = true;
        attackHitBox.transform.localScale /= attacksize;
    }


    // animation
    
    public void UpdateAnimation()
    {
        // get mouse posiotion
        Vector3 mouseWorldPosition = (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())) - transform.position;
        mouseWorldPosition.z = 0;

        animator.SetFloat("MoveX", mouseWorldPosition.x);
        animator.SetFloat("MoveY", mouseWorldPosition.y);
    }



}
