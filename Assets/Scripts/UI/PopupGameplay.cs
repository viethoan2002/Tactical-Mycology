using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGameplay : BasePopup
{
    [SerializeField] private Button btnAttack, btnMove;

    public static Action OnAttack;
    public static Action OnMove;
    private void Awake()
    {
        btnAttack.onClick.AddListener(() =>
        {
            OnAttack?.Invoke();
        });

        btnMove.onClick.AddListener(() =>
        {
            OnMove?.Invoke();
        });
    }
}
