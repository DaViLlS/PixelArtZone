using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMoney : MonoBehaviour
{
    private int _npcMoney;

    public int GetMoney()
    {
        return _npcMoney;
    }

    public void SetMoney(int money)
    {
        _npcMoney += money;
    }
}
