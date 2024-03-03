using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 보스 스킬을 나타내는 열거형
public enum BossSkill
{
    ShurikenThrow,
    TeleportAndAttack,
    HorizontalLaser,

    RectangleSkill,
    SummonMinion,
    FallingStructure,
    JumpAttack,

    HorseCharge,
    RandomLaser,
    ProjectileBarrage,
    Heal,
    PowerUp
}


// 보스 스킬 컴포넌트
public abstract class BossSkillComponent : MonoBehaviour
{
    public abstract void UseSkill();
}


// 각 보스 스킬 컴포넌트 구현
public class ShurikenThrowSkill : BossSkillComponent
{
    public override void UseSkill()
    {
        // 표창을 사방으로 던짐
    }
}

public class TeleportAndAttackSkill : BossSkillComponent
{
    public override void UseSkill()
    {
        // 플레이어 뒤로 순간이동 후 공격
    }
}

public class HorizontalLaserSkill : BossSkillComponent
{
    public override void UseSkill()
    {
        // 수평으로 된 발판 레이져 발사
    }
}

