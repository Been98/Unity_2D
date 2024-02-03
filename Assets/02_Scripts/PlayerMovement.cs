using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D p_Rigid;
    private Animator p_Animator;

    private void Awake()
    {
        p_Rigid = GetComponent<Rigidbody2D>();
        p_Animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Run();
        FlipSprite();
    }

    //Input System �Լ� ����
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            p_Rigid.velocity = new Vector2(0f, jumpSpeed);
        }
    }
    //�޸��� �Լ�
    void Run()
    {
        Vector2 p_Velocity = new Vector2(moveInput.x * runSpeed, p_Rigid.velocity.y);
        p_Rigid.velocity = p_Velocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(p_Rigid.velocity.x) > Mathf.Epsilon;
        p_Animator.SetFloat("RunState", Convert.ToInt32(playerHasHorizontalSpeed));
    }

    //���� ȸ���ϴ� �Լ�
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(p_Rigid.velocity.x) > Mathf.Epsilon; //0���� ������ ������ ���� �� ���� ���� 0 �ٻ簪 ���

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(-Mathf.Sign(p_Rigid.velocity.x), 1f); //-�� �־� ĳ�� ���⿡ �°� ����
        }
    }
}
