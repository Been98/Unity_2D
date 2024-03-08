using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private BossMovement bossMovement;
    public float hp;

    private BossSkillManager bossSkillManager;

    [SerializeField] private Transform targetPos;
    [SerializeField] private float skillCooltime = 3f;


    private void Awake()
    {
        bossSkillManager = GetComponent<BossSkillManager>();
        bossMovement = GetComponent<BossMovement>();
    }
    void Start()
    {
        StartCoroutine(UseRandomSkill());
        // 보스1의 특성 설정
        bossMovement.SetupBoss(3f); // 이동 속도 설정
        hp = 100f; // 보스1의 HP 설정
    }
 
    private IEnumerator UseRandomSkill()
    {
        while (true)
        {
            yield return new WaitForSeconds(skillCooltime);
            bossSkillManager.UseRandomSkill(targetPos.position);
        }
    }
}