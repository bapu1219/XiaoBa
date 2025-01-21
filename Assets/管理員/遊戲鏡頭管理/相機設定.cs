using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class 相機設定 : MonoBehaviour
{

    public CinemachineVirtualCamera cam1, cam2;

    void Start()
    {
       cam1.m_Priority = 10;

       cam2.m_Priority = 0;


    }

    
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))

        {

            cam1.m_Priority = 10;

            cam2.m_Priority = 0;

        }

        else if (Input.GetMouseButtonDown(1))

        {

            cam1.m_Priority = 0;

            cam2.m_Priority = 10;

        }
    }
}
