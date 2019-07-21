using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityCommand : Command
{
    public string abilityName;

    public AbilityCommand(string abilityName)
    {
        this.abilityName = abilityName;
    }

    public override void Execute()
    {
        foreach (GameObject listener in EventListeners.Instance.listeners)
            ExecuteEvents.Execute<IAbilityEvents>(listener, null, (x, y) => x.AbilityTriggered(abilityName));
    }
}
