using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{

    // Start is called before the first frame update

    [SerializeField]
     GameObject[] m_Engines;

    EnergySystem energySys;
    
   
    void Awake()
    {
        energySys=GetComponent<EnergySystem>();
        Reset();
        UpdateEngine();
   
    }

    void OnEnable()
    {
       
    }

    private void OnDisable()
    {
       
    }

   
   

   
    private void Reset()
    {
      
    }

    private void UpdateEngine()
    {
        for (int i = 0, len = m_Engines.Length; i < len; i++)
        {
            m_Engines[i].SetActive(i < 5 ? true : false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
