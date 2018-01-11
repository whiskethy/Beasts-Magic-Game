using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollisionOffline : MonoBehaviour
{

    [SerializeField] private GameObject playerObj;
    [SerializeField] private HealthManagerOffline healthManager;
    [SerializeField] private bool offlineMode;

    private PlayerAttack pAttack;
    private PlayerAttackOffline pAttackO;
    private PlayerData pData;

    // Use this for initialization
    void Start()
    {
        healthManager = FindObjectOfType<HealthManagerOffline>();
        Debug.Assert(healthManager != null);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == null)
        {
            return;
        }
                
        PlayerAnimation pAnim = other.gameObject.GetComponent<PlayerAnimation>();
        Debug.Assert(pAnim != null);
        PlayerAttackOffline pAttack = GetComponent<PlayerAttackOffline>();
        Debug.Assert(pAttack != null);
        PlayerData pData = other.GetComponent<PlayerData>();
        Debug.Assert(pData != null);
        
        if (pData.currentHealth <= 0)
        {
            return;
        }
          
        if (pAttack.getAttack1)
        {
            Debug.Log("Collided with: " + other.gameObject.name);
            Debug.Log("Player Attack 1: " + pAttack.getAttack1);

            pAnim.lightHit();
            healthManager.takeDamage(other.gameObject, 10);
        }

        if (pAttack.getAttack2)
        {
            Debug.Log("Collided with: " + other.gameObject.tag + "  name:" + other.gameObject.name);
            Debug.Log("Player Attack 2: " + pAttack.getAttack2);
            pAnim.lightHit();
            healthManager.takeDamage(other.gameObject, 20);

        }
        
    }
}
