using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//�ٴ� ������
public class Boss1ThrowPlatform : MonoBehaviour, IBossSkill
{
    public float attackInterval = 0.5f;
    public float damage = 5f;

    //������ ������Ʈ
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float throwForce = 30f;
    [SerializeField] private Transform throwPoint;

    private Rigidbody2D platformRb;

    private Animator e_Animator;
    private BossMovement bossMovement;

    private void Awake()
    {
        bossMovement = GetComponent<BossMovement>();
        e_Animator = GetComponent<Animator>();
        platformPrefab.SetActive(false);
        platformRb = platformPrefab.GetComponent<Rigidbody2D>();
    }

    public void UseSkill(Vector2 targetPos)
    {
        platformPrefab.transform.position = throwPoint.position; //������ �ʱ�ȭ
        e_Animator.SetFloat("SkillState", 1f); //���� ��� �ʱ�ȭ
        e_Animator.SetFloat("AttackState", 1f); //��ų ��� �ʱ�ȭ
        platformPrefab.SetActive(true);
        StartCoroutine(ThrowAtkRoutine(targetPos));
       
    }


    //������ ��ƾ
    private IEnumerator ThrowAtkRoutine(Vector2 targetPos)
    {
        bossMovement.SetupBoss(0f);
        e_Animator.SetFloat("RunState", 0.0f);
        
        //���� �ð�
        yield return new WaitForSeconds(attackInterval);
        platformRb.velocity = (targetPos - new Vector2(platformPrefab.transform.position.x, platformPrefab.transform.position.y)).normalized * throwForce;
        e_Animator.SetTrigger("Attack");

        //���� ��
        yield return new WaitForSeconds(attackInterval);
        e_Animator.SetFloat("RunState", 0.5f);
        bossMovement.SetupBoss(3f); 


        platformPrefab.SetActive(false); //�̰� �ݶ��̴��� ����
    }
}
