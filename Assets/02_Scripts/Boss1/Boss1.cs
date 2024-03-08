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
        // ����1�� Ư�� ����
        bossMovement.SetupBoss(3f); // �̵� �ӵ� ����
        hp = 100f; // ����1�� HP ����
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