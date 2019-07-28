using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlaceAbility_AreaStatChanger : AreaHealDamageMakerAbility
{
    public virtual GameObject GetPlacedObject()
    {
        return ((PlaceAbility_AreaStatChangerAbilityData) abilityData).gameObjectToBePlaced;
    }
}
