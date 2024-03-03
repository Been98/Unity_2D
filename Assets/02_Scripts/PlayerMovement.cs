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

    //Input System 함수 모음
    private void OnMove(InputValue value)
    {
            moveInput = value.Get<Vector2>();
    }
    private void OnJump(InputValue value)
    {
        if (value.isPressed && !isDashing) //레이어 추가해서 땅일 때 점프 1번 가능하게
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

    // 대쉬를 실행하는 코루틴 함수
    private IEnumerator Dash()
    {
        //대쉬할 때 무시하는 방법은 ignoreLayercollision 사용 https://www.youtube.com/watch?v=721TkkJ-CNM
        canDash = false;
        isDashing = true;
        float origin = p_Rigid.gravityScale;
        p_Rigid.gravityScale = 0f;
        p_Rigid.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
        p_Trail.emitting = true;
        yield return new WaitForSeconds(dashingTime); // 대쉬 지속 시간만큼 대기
        p_Trail.emitting = false;
        p_Rigid.gravityScale = origin;
        isDashing = false;
        p_Rigid.velocity = Vector2.zero;
        p_Trail.Clear();
        yield return new WaitForSeconds(dashingCooldown); // 대쉬 쿨다운 시간만큼 대기
        canDash = true;
    }

    //달리는 함수
    void Run()
    {
        // 대쉬 중이면 함수 종료
        if (isDashing) return;
        Vector2 p_Velocity = new Vector2(moveInput.x * runSpeed, p_Rigid.velocity.y); // 이동 속도 계산
        p_Rigid.velocity = p_Velocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(p_Rigid.velocity.x) > Mathf.Epsilon; // 수평 속도가 0이 아닌지 확인
        p_Animator.SetFloat("RunState", Convert.ToInt32(playerHasHorizontalSpeed));
    }

    //방향 회전하는 함수
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(p_Rigid.velocity.x) > Mathf.Epsilon; //0으로 설정시 에러가 나올 수 있음 따라서 0 근사값 사용

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(-Mathf.Sign(p_Rigid.velocity.x), 1f); //-를 넣어 캐릭 방향에 맞게 설정
        }
    }
}
