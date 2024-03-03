using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// ���� ��ų�� ��Ÿ���� ������
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


// ���� ��ų ������Ʈ
public abstract class BossSkillComponent : MonoBehaviour
{
    public abstract void UseSkill();
}


// �� ���� ��ų ������Ʈ ����
public class ShurikenThrowSkill : BossSkillComponent
{
    public override void UseSkill()
    {
        // ǥâ�� ������� ����
    }
}

public class TeleportAndAttackSkill : BossSkillComponent
{
    public override void UseSkill()
    {
        // �÷��̾� �ڷ� �����̵� �� ����
    }
}

public class HorizontalLaserSkill : BossSkillComponent
{
    public override void UseSkill()
    {
        // �������� �� ���� ������ �߻�
    }
}

