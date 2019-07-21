using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IAbilityEvents : IEventSystemHandler
{
    void AbilityTriggered(string abilityName);
    void AbilityExecuted(string abilityName, float cooldownDuration);
    void AbilityCancelled();
}
