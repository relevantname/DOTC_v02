using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateDamageBoxAbility : Ability, IWaitableAbility
{
    private Vector3 placePosition = Vector3.zero;

    public override void Execute()
    {
        base.Execute();

        PlaceAbility_AreaHealDamageMakerAbility aData = abilityData as PlaceAbility_AreaHealDamageMakerAbility;
        Instantiate(aData.gameObjectToBePlaced, placePosition, Quaternion.identity);
    }

    public IEnumerator WaitForAnEvent()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    CancelAbility();
                    yield break;
                }

                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    if (hit.collider.tag == "Ground")
                    {
                        placePosition = hit.point;
                        Execute();
                        yield break;
                    }
                    else
                    {
                        CancelAbility();
                        yield break;
                    }
                }
            }
            yield return null;
        }
    } 
    public void CancelAbility()
    {
        foreach (GameObject listener in EventListeners.Instance.listeners)
            ExecuteEvents.Execute<IAbilityEvents>(listener, null, (x, y) => x.AbilityCancelled());
    }
}
