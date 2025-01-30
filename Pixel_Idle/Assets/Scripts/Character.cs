using UnityEngine;

public abstract class Character : MonoBehaviour
{

    [SerializeField]
    private float speed;

    protected Vector2 direction;

    protected Animator animator;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    protected bool IsAttacking = false;
    
    protected Coroutine attackCoroutine;

   public bool IsMoving
        { get
            {
            return direction.x != 0 || direction.y != 0;
            }
        }


    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleLayers();


    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rb.linearVelocity = direction.normalized * speed;

    }

    public void HandleLayers()
    {
        if (IsMoving)
        {
            ActivateLayer("Walk");
     
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);

            StopAttack();
        }
        else if (IsAttacking)
        {
            spriteRenderer.flipX = false;
            ActivateLayer("Attack");
        }
        else
        {
            ActivateLayer("Idle");
        }

    }

    
    public void ActivateLayer (string layerName)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }

    public virtual void StopAttack()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            IsAttacking = false;
            animator.SetBool("Attack", IsAttacking);
        }
       
    }
}
