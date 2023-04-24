using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefineClosestEnemy : MonoBehaviour
{
    private GameObject[] multipleEnemys;
    [SerializeField]private Transform closestEnemy;
    [SerializeField] private MoveToChoosenEnemy script;
    [SerializeField] private bool allowedToAutomove = false;
    void Start()
    {
        closestEnemy = null;
    }

    
    void Update()
    { 
        //change color setion
        multipleEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in multipleEnemys)
        {
            enemy.GetComponent<Renderer>().material.color = new Color(238, 55, 0);
        }
        closestEnemy =  getCloseEnemy();
        if (closestEnemy != null)
        {
            closestEnemy.GetComponent<Renderer>().material.color = new Color(255,0,0);
        }
        
        
        //move section
        if (Input.GetKeyDown("space"))
        {
            allowedToAutomove = !allowedToAutomove;
        }

        if (allowedToAutomove)
        {
            script.SetTarget(closestEnemy);
        }
        else
        {
            script.SetTarget(null);
        }
        
    }

    public Transform getCloseEnemy()
    {
        
        
        float closetDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject enemy in multipleEnemys)
        {
            float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (currentDistance < closetDistance)
            {
                closetDistance = currentDistance;
                trans = enemy.transform;
            }
        }
        return trans;
    }

    
}
