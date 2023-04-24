using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineClosestEnemy : MonoBehaviour
{
    private GameObject[] multipleEnemys;
    [SerializeField]private GameObject closestEnemy;
    void Start()
    {
        closestEnemy = null;
    }

    
    void Update()
    { 
        multipleEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in multipleEnemys)
        {
            enemy.GetComponent<Renderer>().material.color = new Color(238, 55, 0);
        }
        closestEnemy =  getCloseEnemy();
        closestEnemy.GetComponent<Renderer>().material.color = new Color(255,0,0);
    }

    private GameObject getCloseEnemy()
    {
        
        
        float closetDistance = Mathf.Infinity;
        GameObject trans = null;

        foreach (GameObject enemy in multipleEnemys)
        {
            float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (currentDistance < closetDistance)
            {
                closetDistance = currentDistance;
                trans = enemy;
            }
        }
        return trans;
    }
}
