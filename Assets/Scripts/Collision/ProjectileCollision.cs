using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ProjectileCollision : NetworkBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private int blockDurabilityNum = 4;

    //private int tempBlockDurability;
    public SoundOnline sound;

    private void Awake()
    {

        sound = GetComponentInChildren<SoundOnline>();

    }   
    
    // Use this for initialization
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        Debug.Assert(healthManager != null);

        
        //tempBlockDurability = blockDurabilityNum;
    }

    void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.tag == "Player2" || other.gameObject.tag == "Player1")
        {
            //PlayerAnimation panim = other.gameObject.GetComponent<PlayerAnimation>();
            PlayerData pData = other.gameObject.GetComponent<PlayerData>();

            Debug.Log("Collided with: " + other.gameObject.name);
            //Debug.Log("Player Attack 1: " + pAttack.getAttack1);

            //panim.lightHit();

            if (!gameObject.GetComponent<SpellFire>().getStrongAttack)
            {
                healthManager.takeDamage(other.gameObject, pData.lightAttackDamage);
                //panim.lightHit();
                if (isServer)
                {
                    RpcPlayLight();
                }
                else
                {
                    CmdPlayLight();
                }
                sound.lightAttackedSound();
            }
            else
            {
                healthManager.takeDamage(other.gameObject, pData.heavyAttackDamage);
                //panim.lightHit();
                if (isServer)
                {
                    RpcPlayHeavy();
                }
                else
                {
                    CmdPlayHeavy();
                }
                sound.heavyAttackedSound();
            }

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [ClientRpc]
    public void RpcPlayLight()
    {
        sound.lightAttackedSound();
    }
    [Command]
    public void CmdPlayLight()
    {
        sound.lightAttackedSound();

    }
    [ClientRpc]
    public void RpcPlayHeavy()
    {
        sound.heavyAttackedSound();
    }
    [Command]
    public void CmdPlayHeavy()
    {
        sound.heavyAttackedSound();

    }
}