using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    /// <summary>
    /// 武器 & 防具各類道具的最底層
    /// </summary>
public class 物品藍圖 :ScriptableObject
{
    public string 名稱;
    /// <summary>
    /// 所有道具的ID (為整數int)
    /// </summary>
    public int 物品ID;
    /// <summary>
    /// 如賣出 & 買入的價錢
    /// </summary>
    public int 金額;
    public enum 稀有度
    {
        普通,稀有,史詩,傳奇

    }
    public 稀有度 稀有度等級;
}
