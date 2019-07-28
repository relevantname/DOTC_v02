using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InGameBuff : MonoBehaviour, IInGameBuff
{
    public InGameBuffData buffData;
    protected PlayerStats playerStats;

    private bool collected = false;
    private float _timer;

    private void Update()
    {
        if (collected && buffData._isEffectedImmediately == false)
        {
            _timer += Time.deltaTime;
            if (_timer >= buffData._duration)
                Expired();
        }
    }

    public void Activate()
    {
        if (playerStats.IsBuffExists(this) && buffData._isStackable == false)
            return;

        foreach (GameObject listener in EventListeners.Instance.listeners)
            ExecuteEvents.Execute<IBuffEvents>(listener, null, (x, y) => x.BuffCollected(this));

        Execute();

        buffData._model.GetComponent<Collider>().enabled = false;
        buffData._model.GetComponent<MeshRenderer>().enabled = false;
    }

    public virtual void Execute()
    {
        if (buffData._isEffectedImmediately)
            Expired();
    }

    public virtual void Expired()
    {
        foreach (GameObject listener in EventListeners.Instance.listeners)
            ExecuteEvents.Execute<IBuffEvents>(listener, null, (x, y) => x.BuffExpired(this));

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            playerStats = collision.collider.GetComponent<PlayerStats>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerStats = other.GetComponent<PlayerStats>();
            Activate();
        }
    }
}
