using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BlockButton : EventTrigger {

    private PlayerBlock pBlock;
    private EventTrigger pTrigger;
    private UnityAction<BaseEventData> call;

    // Use this for initialization
    void Start () {

        pTrigger = GameObject.Find("/Canvas MainWorld/BlockButton").GetComponent<EventTrigger>();
        Debug.Assert(pTrigger != null);

        pBlock = GetComponent<PlayerBlock>();
        Debug.Assert(pBlock != null);

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventData) => { pBlock.Block(); });
        pTrigger.triggers.Add(entry);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((eventData) => { pBlock.StopBlock(); });
        pTrigger.triggers.Add(entry2);

    }

	// Update is called once per frame
	void Update () {

        if(pTrigger == null)
        {
            pTrigger = GameObject.Find("/Canvas MainWorld/BlockButton").GetComponent<EventTrigger>();
            Debug.Assert(pTrigger != null);

            pBlock = GetComponent<PlayerBlock>();
            Debug.Assert(pBlock != null);

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            call = new UnityAction<BaseEventData>(PointerDown);
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(call);
            pTrigger.triggers.Add(entry);

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerUp;
            call = new UnityAction<BaseEventData>(PointerUp);
            entry.callback = new EventTrigger.TriggerEvent();
            entry.callback.AddListener(call);
            pTrigger.triggers.Add(entry);
        }
		
	}

    private void PointerDown(BaseEventData eventData)
    {
        Debug.Log("pointer enter");
        pBlock.Block();
    }
    private void PointerUp(BaseEventData eventData)
    {
        Debug.Log("pointer exit");
        pBlock.StopBlock();
    }
}
