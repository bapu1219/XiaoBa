using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 角色 & 敵人最底層的數值
/// </summary>
public class 基礎數值藍圖 : ScriptableObject
{
    [Header("數值相關")]
    public string 名字;
    public float 攻擊力;
    public int 最大生命值;
    public float 防禦力;
    public int 基礎魔力值;


    [Header("操作相關")]
    public int 移動速度;
    public int 跳躍高度;
    public int 最大跳躍次數;
    public int 最大攻擊速度;
    public int 攻擊間隔;
}