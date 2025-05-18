using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;

public class AttackArea : MonoBehaviour
{

    private List<Collider2D> collidingObjects = new List<Collider2D>();
    [System.NonSerialized] public GameObject nearObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !collidingObjects.Contains(collision))
        {
            collidingObjects.Add(collision);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collidingObjects.Remove(collision);
        }
    }

    private void FixedUpdate()
    {
        float nearDis = Mathf.Infinity;
        nearObject = null;
        int layerMask = ~((1 << 6) + (1 << 8));

        foreach (Collider2D enemy in collidingObjects)
        {
            Vector2 enemyPos = enemy.gameObject.transform.position;
            float dis = Vector2.Distance(transform.position, enemyPos);
            Vector2 direction = (enemyPos - (Vector2)transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, dis,layerMask);
            if (hit.collider != null && hit.collider == enemy)
            {
                if (nearDis > dis)
                {
                    nearDis = dis;
                    nearObject = enemy.gameObject;
                }
            }
            
        }
    }

}
