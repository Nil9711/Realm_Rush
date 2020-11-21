using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform ObjectToPan;
    [SerializeField] Transform CurrentEnemy;
    [SerializeField] float attackRange = 30f;
    [SerializeField] GameObject bullets;

    private void Start()
    {
    }
    void Update()
    {
        ObjectToPan.LookAt(CurrentEnemy);
        AttackOnRange();
    }

    void AttackOnRange()
    {
        var emission = bullets.GetComponent<ParticleSystem>().emission;
        if (Vector3.Distance(CurrentEnemy.transform.position, this.transform.position) <= attackRange)
        {
        emission.enabled = true;
        }
        else
        {
        emission.enabled = false;
        }
    }
}
