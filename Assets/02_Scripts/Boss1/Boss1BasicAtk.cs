using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//기본 공격
public class Boss1BasicAtk : MonoBehaviour, IBossSkill
{
    public float attackInterval = 1f;
    public float damage = 5f;

    private Animator e_Animator;
    private BossMovement bossMovement;

    private void Awake()
    {
        bossMovement = GetComponent<BossMovement>();
        e_Animator = GetComponent<Animator>();
    }


    public void UseSkill(Vector2 targetPos)
    {
        e_Animator.SetFloat("NormalState", 0f); //공격 모션 초기화
        e_Animator.SetFloat("AttackState", 0f); //스킬 모션 초기화
        StartCoroutine(BasicAtkRoutine());
    }


    //공격 루틴 함수
    private IEnumerator BasicAtkRoutine()
    {
        bossMovement.SetupBoss(0f); 
        e_Animator.SetFloat ("RunState", 0.0f);
        yield return new WaitForSeconds(attackInterval);
        e_Animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attackInterval);
        e_Animator.SetFloat("RunState", 0.5f);
        bossMovement.SetupBoss(3f);
    }
}
