using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : Fighter
{
    public Animator animator;

    [SerializeField] private Patrol patrol;

    [Header("Follow")]
    [SerializeField] private AIPath aiPath;
    [SerializeField] private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private BoxCollider2D trigger;
    private bool Following = false;



    public void Start()
    {
        patrol = GetComponent<Patrol>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        trigger = GetComponent<BoxCollider2D>();
    }

    public void FixedUpdate()
    {
        Movemenet();
    }

    private void Movemenet()
    {
        float mx = aiPath.desiredVelocity.x;
        float my = aiPath.desiredVelocity.y;

        animator.SetFloat("velocityX", mx);
        animator.SetFloat("velocityY", my);

        //Если фоллоу, то выключает скрипт патрулирования и включает скрипт преследования
        if (Following)
        {
            patrol.enabled = false;
            aiDestinationSetter.enabled = true;
        }
        //Иначе, выключает скрипт преследования и включает скрипт патрулирования
        else
        {
            aiDestinationSetter.enabled = false;
            patrol.enabled = true;
        }

    }

    //Если персонаж с компонентом Player попадает в триггер, то following = true, и наоборот = false, если он выходит из триггера.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
            Following = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
            Following = false;
    }

}
