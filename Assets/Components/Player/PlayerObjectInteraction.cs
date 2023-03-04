using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectInteraction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Objective":
                Debug.Log("Congratulations you've won!");
                break;
            default:
                break;
        }
    }
}
