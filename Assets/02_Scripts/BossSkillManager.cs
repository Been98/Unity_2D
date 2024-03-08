using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillManager : MonoBehaviour
{
    private IBossSkill[] skills;

    private void Start()
    {
        skills = GetComponents<IBossSkill>();
    }

    public void UseRandomSkill(Vector2 targetPos)
    {
        if(skills.Length == 0) { return; }
        int randomIdx = Random.Range(0, skills.Length);
        IBossSkill selectSkill = skills[randomIdx];

        selectSkill.UseSkill(targetPos);
    }
}