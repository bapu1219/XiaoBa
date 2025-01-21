using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "點燃星海", menuName = "技能/點燃星海")]
public class 點燃星海 : 技能藍圖
{
    public override void 技能行為()
    {
        if (檢測魔力())
        {
            Debug.Log("發動點燃星海");
        }
        else
        Debug.Log("技能發動失敗");
    }
}
