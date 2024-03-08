using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // ������ Ư���� ������ ����
    public float moveSpeed = 3f; // �⺻ �̵� �ӵ�
    public float wallCheckDistance = 0.1f; // �� üũ �Ÿ�
    public LayerMask wallLayer; // �� ���̾�

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private Animator e_Animator;

    // ������ Ư���� ������ �޼���
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
        // �̵��� ���� ����
        float moveDirection = isFacingRight ? 1f : -1f;

        // �̵� ���⿡ ���� �ִ��� Ȯ���� ��ġ ���
        Vector2 wallCheckDirection = isFacingRight ? Vector2.right : Vector2.left;
        Vector2 wallCheckPosition = (Vector2)transform.position + wallCheckDirection * wallCheckDistance;

        // �̵� ���⿡ ���� �ִ��� Ȯ��
        RaycastHit2D hit = Physics2D.Raycast(wallCheckPosition, wallCheckDirection, 0.2f, wallLayer);


        // ���� ���� ������ ���� ��ȯ
        if (hit.collider != null)
        {
            isFacingRight = !isFacingRight;
            Flip();
        }

        // �̵� �ӵ� ����
        Vector2 targetVelocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        rb.velocity = targetVelocity;
        //e_Animator.SetFloat("RunState",0.5f);
    }

    private void Flip()
    {
        // ������ ��������Ʈ ������
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
