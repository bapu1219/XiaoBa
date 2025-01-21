using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class 敵人藍圖 : 基礎數值藍圖
{
    public int 敵人ID;
    protected 敵人AI管理員 敵人AI { get { return 遊戲管理員.管理員.敵人AI; } }
    public abstract IEnumerator 移動(float 速度, Transform 敵人, Rigidbody2D 敵人移動);
}
