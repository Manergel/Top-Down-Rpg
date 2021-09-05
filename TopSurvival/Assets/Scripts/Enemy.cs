using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D capsuleColl;
    [SerializeField] private Animator animator;

    [SerializeField] private Patrol patrol;

    [Header("Follow")]
    [SerializeField] private AIPath aiPath;
    [SerializeField] private AIDestinationSetter aiDestinationSetter;
    [SerializeField] private BoxCollider2D trigger;
    private bool Following = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleColl = GetComponent<CapsuleCollider2D>();
        patrol = GetComponent<Patrol>();
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        trigger = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
            Following = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
            Following = false;
    }

}
