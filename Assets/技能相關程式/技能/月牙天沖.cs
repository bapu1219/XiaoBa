using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "月牙天沖", menuName = "技能/月牙天沖")]
public class 月牙天沖 : 技能藍圖
{
    public override void 技能行為()
    {

        if (檢測魔力())
        {
            Debug.Log("發動月牙天沖");
        }
        else
            Debug.Log("技能發動失敗");
    }

}
