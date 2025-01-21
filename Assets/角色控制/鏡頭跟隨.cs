using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 鏡頭跟隨 : MonoBehaviour
{
    public Transform 主角;
    void Update()
    {
        transform.position = 主角.position + Vector3.back * 10;
    }
    
}
