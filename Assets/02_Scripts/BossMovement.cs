using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // 보스의 특성을 설정할 변수
    public float moveSpeed = 3f; // 기본 이동 속도
    public float wallCheckDistance = 0.1f; // 벽 체크 거리
    public LayerMask wallLayer; // 벽 레이어

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private Animator e_Animator;

    // 보스의 특성을 설정할 메서드
    public void SetupBoss(float speed)
    {
        moveSpeed = speed;
    }

    private void Start()
    {
        e_Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        e_Animator.SetFloat("RunState", 0.5f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // 이동할 방향 설정
        float moveDirection = isFacingRight ? 1f : -1f;

        // 이동 방향에 벽이 있는지 확인할 위치 계산
        Vector2 wallCheckDirection = isFacingRight ? Vector2.right : Vector2.left;
        Vector2 wallCheckPosition = (Vector2)transform.position + wallCheckDirection * wallCheckDistance;

        // 이동 방향에 벽이 있는지 확인
        RaycastHit2D hit = Physics2D.Raycast(wallCheckPosition, wallCheckDirection, 0.2f, wallLayer);


        // 만약 벽이 있으면 방향 전환
        if (hit.collider != null)
        {
            isFacingRight = !isFacingRight;
            Flip();
        }

        // 이동 속도 설정
        Vector2 targetVelocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        rb.velocity = targetVelocity;
        //e_Animator.SetFloat("RunState",0.5f);
    }

    private void Flip()
    {
        // 보스의 스프라이트 뒤집기
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
