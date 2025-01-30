using UnityEngine;

public class SpellScript : MonoBehaviour
{
    

    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    public Transform target { get; set; }



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;

            rb.linearVelocity = direction.normalized * speed;


            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HitBox" && collision.transform == target) 
            {
            GetComponent<Animator>().SetTrigger("Inpact");
            rb.linearVelocity = Vector2.zero;
            target = null;
           
            }
    }
}
