using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeRoom : MonoBehaviour
{
    [SerializeField] private CinemachineConfiner cinemachineConfiner;
    public BoxCollider2D boxCollider;
    public PolygonCollider2D[] Shapes;

    protected void Start()
    {
        cinemachineConfiner = GetComponent<CinemachineConfiner>();
        boxCollider = GetComponent<BoxCollider2D>();
        //Shapes = 
    }
    //Нужно, чтобы в CinemachineConfiner сменялся коллайдер BoundingShape1 на BoundingShape2 входя в триггер.

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.GetComponent<Player>() != null)
            //cinemachineConfiner.m_BoundingShape2D == Shapes[1];
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
            Debug.Log("Выход из триггера");
    }

}
