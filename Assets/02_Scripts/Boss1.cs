using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public BossMovement bossMovement;
    public float hp;

    void Start()
    {
        // ����1�� Ư�� ����
        bossMovement.SetupBoss(3f); // �̵� �ӵ� ����
        hp = 100f; // ����1�� HP ����
    }
}