using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 和武器一樣的使用方式
/// </summary>
public class 敵人AI管理員
{
    Transform 玩家 { get { return 遊戲管理員.管理員.玩家位置; } }
    public void 朝向玩家移動(float 速度, Transform 敵人, Rigidbody2D 敵人移動)
    {
        Vector3 怪物朝向 = (玩家.position - 敵人.position).normalized;

        敵人移動.velocity = new Vector2(Mathf.Min(怪物朝向.x, 1) * 速度, 敵人移動.velocity.y);

        // Debug.Log(怪物朝向);
    }
}
