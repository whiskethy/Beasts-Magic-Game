using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[NetworkSettings (channel = 1, sendInterval = 10f) ]
public class PlayerAttack : NetworkBehaviour {
	
    [SerializeField] private GameObject blockingEffect;
    [SerializeField] private GameObject breakBlockingEffect;
    [SerializeField] private GameObject breakBlockEffectTrans;
    [SerializeField] private GameObject projectileSpawn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject projectilePrefab2;
    [SerializeField] private bool hasProjectileAttack;
    [SerializeField] private bool mobileMode;

    private PlayerData pData;
    private Button attackButton1;
    private Button attackButton2;
    private Button blockButton;

    //data
    private bool attack1;
    private bool attack2;
    private bool canBlock;
    private bool canSpawnBreakingBlockEffect;

    //private PlayerAnimation anim;

    // Use this for initialization
    void Start () {
        //anim = GetComponent<PlayerAnimation>();
        //Debug.Assert(anim != null);

        attack1 = false;
        attack2 = false;
        canBlock = false;
        canSpawnBreakingBlockEffect = false;

        pData = GetComponent<PlayerData>();
        Debug.Assert(pData != null);

		blockingEffect.SetActive(false);
        Debug.Assert(blockingEffect != null);

        breakBlockingEffect.SetActive(false);
        Debug.Assert(breakBlockingEffect != null);

        if(mobileMode)
        {
            //attackButton1 = GameObject.Find("Attack 1").GetComponent<Button>();
            //Debug.Assert(attackButton1 != null);

            //attackButton2 = GameObject.Find("Attack 2").GetComponent<Button>();
            //Debug.Assert(attackButton2 != null);

            //blockButton = GameObject.Find("Block Attack").GetComponent<Button>();
            //Debug.Assert(blockButton != null);
            
            //attackButton1.onClick.AddListener(CmdAttack1);
            //attackButton2.onClick.AddListener(CmdAttack2);
            //blockButton.onClick.AddListener(CmdBlock);
        }

	}

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        attackButton1 = GameObject.Find("Attack 1").GetComponent<Button>();
        Debug.Assert(attackButton1 != null);

        attackButton2 = GameObject.Find("Attack 2").GetComponent<Button>();
        Debug.Assert(attackButton2 != null);

        blockButton = GameObject.Find("Block Attack").GetComponent<Button>();
        Debug.Assert(blockButton != null);

        attackButton1.onClick.AddListener(() => CmdAttack1());
        attackButton2.onClick.AddListener(() => CmdAttack2());
        blockButton.onClick.AddListener(() => CmdBlock());
    }

    // Update is called once per frame
    void Update () {

        if (!isLocalPlayer)  
        {
            return;
        }
		
        if(Input.GetMouseButtonDown(0) && !attack1 && !attack2 && pData.isAlive)
        {
            Debug.Log("Attack 1 Start!");
            attack1 = true;
            StartCoroutine(DisableAttack1());
        }

        if(Input.GetMouseButtonDown(1) && !attack1 && !attack2 && pData.isAlive)
        {
            Debug.Log("Attack 2 Start");
            attack2 = true;
            StartCoroutine(DisableAttack2());
        }

        if (Input.GetKey(KeyCode.Space) && !attack1 && !attack2 && pData.isAlive)
        {
            canBlock = true;
            blockingEffect.SetActive(true);
            //Debug.Log("Blocking Attack");
            //anim.blocking();
        }
        else
        {
            //Debug.Log("Blocking Attack Stop");
            canBlock = false;
            //SpawnBreakBlockEffect();
            blockingEffect.SetActive(false);
            //anim.unBlocking();
        }

 		if(Input.GetKeyUp(KeyCode.Space) && !attack1 && !attack2)
        {
            canSpawnBreakingBlockEffect = true;
        }

        if(canSpawnBreakingBlockEffect)
        {
            CmdSpawnBreakBlockEffect();
            canSpawnBreakingBlockEffect = false;
            //anim.blockBreak(); //will play the block Break animation
        }
    }

    [Command]
    void CmdSpawnBreakBlockEffect()
    {
        GameObject temp = Instantiate(breakBlockingEffect, breakBlockEffectTrans.transform);
        temp.SetActive(true);
        Destroy(temp, 2.1f);
    }

    private IEnumerator DisableAttack1()
    {
        //anim.attackOne(attack1);
        yield return new WaitForSeconds(pData.attack1CoolDown);

        if (hasProjectileAttack && attack1)
        {
            CmdSpawnProjectileAttack1();
        }

        Debug.Log("Attack 1 Stop");
        this.attack1 = false;
    }

    private IEnumerator DisableAttack2()
    {
        //anim.attackTwo(attack2);
        yield return new WaitForSeconds(pData.attack2CoolDown);

 		if (hasProjectileAttack && attack2)
        {
            CmdSpawnProjectileAttack2();
        }

        this.attack2 = false;
        Debug.Log("Attack 2 Stop");
    }

    public bool getAttack1
    {
        get { return attack1; }
    }

    public bool getAttack2
    {
        get { return attack2; }
    }

	public bool getBlock
    {
        get { return canBlock; }
    }

    [Command]
    private void CmdSpawnProjectileAttack1()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        GameObject temp = Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        temp.GetComponent<SpellFire>().setStrongAttack(false);
    }

    [Command]
    private void CmdSpawnProjectileAttack2()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        GameObject temp = Instantiate(projectilePrefab2, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        temp.GetComponent<SpellFire>().setStrongAttack(true);
    }

    [Command]
    public void CmdAttack1()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (!attack1 && !attack2)
        {
            attack1 = true;
            Debug.Log("Attack 1 Start!");
            StartCoroutine(DisableAttack1());
        }
    }

    [Command]
    public void CmdAttack2()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (!attack1 && !attack2)
        {
            attack2 = true;
            Debug.Log("Attack 2 Start!");
            StartCoroutine(DisableAttack2());
        }
    }

    [Command]
    public void CmdBlock()
    {
        //if (!isLocalPlayer)
        //{
        //    return;
        //}

        canBlock = true;
        pData.isBlocking = true;
        blockingEffect.SetActive(true);
        Debug.Log("Blocking Attack");
        //anim.blocking();
    }

    [Command]
    public void CmdStopBlock()
    {
        //if (!isLocalPlayer)
        //{
        //    return;
        //}

        //Debug.Log("Blocking Attack Stop");
        pData.isBlocking = false;
        canBlock = false;
        blockingEffect.SetActive(false);
        //anim.unBlocking();
    }
}
