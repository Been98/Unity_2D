using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public BossMovement bossMovement;
    public float hp;

    void Start()
    {
        // 보스1의 특성 설정
        bossMovement.SetupBoss(3f); // 이동 속도 설정
        hp = 100f; // 보스1의 HP 설정
    }
}