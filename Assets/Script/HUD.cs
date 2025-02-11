using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // �ٷ�� �� �����͸� �̸� ������ enum���� ����
    public enum InfoType { HP, MP }
    // ������ �������� Ÿ������ ���� �߰� -> ����Ƽ�� �ν����� â ������ InfoType ������ ���� �� �ϳ��� ���� ����
    public InfoType type;

    public int playernum;

    Slider mySlider;

    private float maxHP;
    private float maxMP;
    private float curHP;
    private float curMP;

    void Start()
    {
        if (playernum == 1)
        {
            maxHP = BattleManager.instance.player1.HP;
            maxMP = BattleManager.instance.player1.MP;
        }
        else if (playernum == 2)
        {
            maxHP = BattleManager.instance.player2.HP;
            maxMP = BattleManager.instance.player2.MP;
        }

        else {
            Debug.Log("�߸��� �ε���");
        }


        mySlider = GetComponent<Slider>();

    }
    
    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.HP:
                if (playernum == 1)
                {
                    curHP = BattleManager.instance.player1.HP;
                }
                else if (playernum == 2)
                {
                    curHP = BattleManager.instance.player2.HP;
                }

                mySlider.value = curHP / maxHP;

                break;
            case InfoType.MP:
                if (playernum == 1)
                {
                    curMP = BattleManager.instance.player1.MP;
                }
                else if (playernum == 2)
                {
                    curMP = BattleManager.instance.player2.MP;
                }
                mySlider.value = curMP / maxMP;
                break;
        }
    }
    
}
