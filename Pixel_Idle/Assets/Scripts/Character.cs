using UnityEngine;

public abstract class Character : MonoBehaviour
{

    [SerializeField]
    private float speed;

    protected Vector2 direction;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

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
            if (direction.x != 0)
            {
                spriteRenderer.flipX = direction.x < 0;
            }
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
}
