using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : Character
{
    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat mana;


    [SerializeField]
    private float initHealth;

    [SerializeField]
    private float initMana;

    [SerializeField]
    private GameObject[] spellPrefab;

    private int FaceDirection;

    [SerializeField]
    private Block[] blocks;

    public Transform target { get; set; }


    protected override void Start()
    {
        health.Initialized(initHealth, initHealth);
        mana.Initialized(initMana, initMana);

      
        base.Start();
    }

     protected override void Update()
    {
        GetInput();
        
        base.Update();
    }



    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 20;
            
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 20;
        }



        if ( Input.GetKey( KeyCode.W ))
        {
            FaceDirection = 0;
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            FaceDirection = 3;
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            FaceDirection = 2;
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            FaceDirection = 1;
            direction += Vector2.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Block();

            if (target != null && !IsAttacking && !IsMoving && InLineOfSight())
            {
                attackCoroutine = StartCoroutine(Attack());
            }
           
        }

    }

    private IEnumerator Attack()
    {

        IsAttacking = true;

        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(1);

        CastSpell();

        StopAttack();
    }

    public void CastSpell()
    {

        Spell s = Instantiate(spellPrefab[0],transform.position, Quaternion.identity).GetComponent<Spell>();
        s.target = target;
    }

    private bool InLineOfSight()
    {

        Vector3 targetDirection = (target.transform.position - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection,Vector2.Distance(transform.position, target.transform.position),256);

        if (hit.collider == null)
        {
            return true;
        }

        return false;
    }

    private void Block()
    {
        foreach (Block b in blocks)
        {
            b.Deactivate();
        }

        blocks[FaceDirection].Activate();  
    }
}
