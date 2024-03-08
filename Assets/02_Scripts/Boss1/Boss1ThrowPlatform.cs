using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//바닥 던지기
public class Boss1ThrowPlatform : MonoBehaviour, IBossSkill
{
    public float attackInterval = 0.5f;
    public float damage = 5f;

    //던지는 오브젝트
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
        platformPrefab.transform.position = throwPoint.position; //포지션 초기화
        e_Animator.SetFloat("SkillState", 1f); //공격 모션 초기화
        e_Animator.SetFloat("AttackState", 1f); //스킬 모션 초기화
        platformPrefab.SetActive(true);
        StartCoroutine(ThrowAtkRoutine(targetPos));
       
    }


    //던지기 루틴
    private IEnumerator ThrowAtkRoutine(Vector2 targetPos)
    {
        bossMovement.SetupBoss(0f);
        e_Animator.SetFloat("RunState", 0.0f);
        
        //공격 시간
        yield return new WaitForSeconds(attackInterval);
        platformRb.velocity = (targetPos - new Vector2(platformPrefab.transform.position.x, platformPrefab.transform.position.y)).normalized * throwForce;
        e_Animator.SetTrigger("Attack");

        //공격 끝
        yield return new WaitForSeconds(attackInterval);
        e_Animator.SetFloat("RunState", 0.5f);
        bossMovement.SetupBoss(3f); 


        platformPrefab.SetActive(false); //이건 콜라이더로 변경
    }
}
