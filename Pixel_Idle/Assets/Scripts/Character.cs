using UnityEngine;

public abstract class Character : MonoBehaviour
{

    [SerializeField]
    private float speed;

    protected Vector2 direction;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

   


    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
        
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0)
        {
            Animate(direction);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
       

    }

    public void Animate(Vector2 direction)
    {
        animator.SetBool("IsMoving", true);

        if (direction.x != 0)
        {
            spriteRenderer.flipX = direction.x < 0; 
        }
    }
}
