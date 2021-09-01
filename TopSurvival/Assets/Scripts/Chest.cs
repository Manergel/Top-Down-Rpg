using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Animator animator;
    public int pesosAmount = 5;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            animator.SetBool("Collectable",true);
            Debug.Log("Grant " + pesosAmount + " pesos!");
        }

    }
}
