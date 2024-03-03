using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


/// <summary>
/// ���� ������ �ִ� ������ ���� ����
/// </summary>
public class WeaponManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TxtItemName;
    [SerializeField] private TextMeshProUGUI TxtAtkName;
    [SerializeField] private Image imgItem;
    private ItemSO[] itemDB;
    private int itemIdx = 0;
    [SerializeField] private GameObject player;


    //���� ������ ȭ�鿡 ������ ������
    public void BtnItemOnClick(int idx)
    {
        itemIdx = idx;
        imgItem.sprite = itemDB[idx].img;
        TxtItemName.text = itemDB[idx].name;
        TxtAtkName.text =" + " +itemDB[idx].atk.ToString();
    }

    //equip ��ư ������ �� ���� �ش� ��ư�� ���� ����
    public void BtnEquipOnClick()
    {
        player.GetComponent<SPUM_Prefabs>()._spriteOBj._weaponList[0].sprite = itemDB[itemIdx].img;
    }
}
