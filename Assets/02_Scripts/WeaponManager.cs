using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


/// <summary>
/// 무기 도감에 있는 무기의 상태 설정
/// </summary>
public class WeaponManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TxtItemName;
    [SerializeField] private TextMeshProUGUI TxtAtkName;
    [SerializeField] private Image imgItem;
    private ItemSO[] itemDB;
    private int itemIdx = 0;
    [SerializeField] private GameObject player;


    //무기 누르면 화면에 비춰질 데이터
    public void BtnItemOnClick(int idx)
    {
        itemIdx = idx;
        imgItem.sprite = itemDB[idx].img;
        TxtItemName.text = itemDB[idx].name;
        TxtAtkName.text =" + " +itemDB[idx].atk.ToString();
    }

    //equip 버튼 눌렀을 때 실행 해당 버튼의 무기 장착
    public void BtnEquipOnClick()
    {
        player.GetComponent<SPUM_Prefabs>()._spriteOBj._weaponList[0].sprite = itemDB[itemIdx].img;
    }
}
