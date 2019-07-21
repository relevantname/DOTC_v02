using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Ability : MonoBehaviour
{
    public AbilityData abilityData;
    [HideInInspector] public float remainingCooldownDuration;
    public bool isInCooldown;
    private float cooldownTimer; 

    private void Update()
    {
        if (isInCooldown)
        {
            remainingCooldownDuration -= Time.deltaTime;
            if (remainingCooldownDuration <= 0.0f)
                isInCooldown = false;
        }
    }

    public void Activate()
    {
        if (string.IsNullOrEmpty(abilityData.animationName) && abilityData.waitForExecute == false)
            Execute();

        if (abilityData.waitForExecute)
        {
            IWaitableAbility waitableAbility = this as IWaitableAbility;
            StartCoroutine(waitableAbility.WaitForAnEvent());
        }
    }

    public virtual void Execute()
    {
        foreach (GameObject listener in EventListeners.Instance.listeners)
            ExecuteEvents.Execute<IAbilityEvents>(listener, null, (x, y) => x.AbilityExecuted(abilityData.abilityName, abilityData.cooldownDuration));

        isInCooldown = true;
        remainingCooldownDuration = abilityData.cooldownDuration;
    }
}
