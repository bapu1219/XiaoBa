using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "近戰攻擊", menuName = "技能/近戰攻擊")]
public class 近戰攻擊 : 技能藍圖
{
    public override void 技能行為()
    {
        Collider2D[] 被打到敵人 = Physics2D.OverlapCircleAll(攻擊範圍偵測器.position, 攻擊範圍, 敵人圖層);
        foreach (Collider2D item in 被打到敵人)
        {
            Debug.Log(item.gameObject.name);

            if (檢測魔力())
            {
                item.gameObject.SendMessage("被攻擊");
            }
            else
            {
                Debug.Log("魔力不足");
            }
        }

    }

}
