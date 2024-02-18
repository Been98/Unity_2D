using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 20f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 0.5f;

    private Vector2 moveInput;
    private Rigidbody2D p_Rigid;
    private TrailRenderer p_Trail;
    private Animator p_Animator;

    private void Awake()
    {
        p_Rigid = GetComponent<Rigidbody2D>();
        p_Trail = GetComponent<TrailRenderer>();
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
        if (value.isPressed && !isDashing) //���̾� �߰��ؼ� ���� �� ���� 1�� �����ϰ�
        {
            p_Rigid.velocity = new Vector2(0f, jumpSpeed);
        }
    }
    private void OnDash(InputValue value)
    {
        if (value.isPressed && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        //�뽬�� �� �����ϴ� ����� ignoreLayercollision ��� https://www.youtube.com/watch?v=721TkkJ-CNM
        canDash = false;
        isDashing = true;
        float origin = p_Rigid.gravityScale;
        p_Rigid.gravityScale = 0f;
        p_Rigid.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
        p_Trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        p_Trail.emitting = false;
        p_Rigid.gravityScale = origin;
        isDashing = false;
        p_Rigid.velocity = Vector2.zero;
        p_Trail.Clear();
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    //�޸��� �Լ�
    void Run()
    {
        if (isDashing) return;
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
