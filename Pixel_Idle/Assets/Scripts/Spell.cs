using UnityEngine;

public class Spell : MonoBehaviour
{
    

    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.Find("Target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;

        rb.linearVelocity = direction.normalized * speed;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }
}
