using System.Collections;
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
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            attackCoroutine =  StartCoroutine(Attack());
        }

    }

    private IEnumerator Attack()
    {
        if (!IsAttacking && !IsMoving)
        {

            IsAttacking = true;

            animator.SetBool("Attack", true);

            yield return new WaitForSeconds(3);

            StopAttack();
        }
    }

}
