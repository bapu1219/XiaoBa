using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class 敵人控制 : MonoBehaviour
{
    public 敵人藍圖 怪物;
    Rigidbody2D 敵人鋼體;
    Transform 敵人位置;
    private bool 是否被攻擊 = false;

    void Start()
    {
        敵人鋼體 = GetComponent<Rigidbody2D>();
        敵人位置 = GetComponent<Transform>();
    }
    void Update()
    {
        
        if (!是否被攻擊)
        {
            StartCoroutine(怪物.移動(怪物.移動速度, 敵人位置, 敵人鋼體));
        }
        if (是否被攻擊 == true)
        {
            if (Mathf.Abs(敵人鋼體.velocity.x) < 0.1)
                是否被攻擊 = false;
        }
    }

    public void 被攻擊()
    {
        if (transform.position.x > 遊戲管理員.管理員.玩家位置.gameObject.transform.position.x)
        {
            敵人鋼體.velocity = new Vector2(10, 10);
            是否被攻擊 = true;
        }
        if (transform.position.x < 遊戲管理員.管理員.玩家位置.gameObject.transform.position.x)
        {
            敵人鋼體.velocity = new Vector2(-10, 10);
            是否被攻擊 = true;
        }
    }
}