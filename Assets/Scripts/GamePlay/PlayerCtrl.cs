using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl instance;

    public PlayerMovement movement;

    private void Awake()
    {
        instance = this;
    }
}
