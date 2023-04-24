using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToChoosenEnemy : MonoBehaviour
{
    
        [SerializeField] private Transform target; 
        [SerializeField] private float speed = 5f; 
        void Update()
        {
            if (target != null)
            {
                Vector3 direction = target.position - transform.position;
                if (direction.magnitude > 0.1f)
                {
                    direction.Normalize();
                    transform.Translate(direction * speed * Time.deltaTime);
                }
            }
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    
}
