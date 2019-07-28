using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUIManager : MonoBehaviour, IAbilityEvents, IAbilityControllerEvents
{
    private List<AbilityHolder> abilityHolders = new List<AbilityHolder>();

    public GameObject abilityBar;
    public GameObject abilityHolder;

    private void Start()
    {
        EventListeners.Instance.AddListener(this.gameObject);
    }

    public void CreateAbilityBar(List<Ability> abilities)
    {
        foreach (Ability ability in abilities)
        {
            GameObject abilityHolderGO = Instantiate(abilityHolder);
            abilityHolderGO.GetComponent<Image>().sprite = ability.abilityData.abilityImage;
            AbilityHolder aHolder = abilityHolderGO.GetComponent<AbilityHolder>();
            aHolder.abilityName = ability.abilityData.abilityName;
            abilityHolders.Add(aHolder);
            abilityHolderGO.transform.SetParent(abilityBar.transform);

            abilityHolder.transform.localPosition = Vector3.zero;
            abilityHolder.transform.localRotation = Quaternion.identity;
            abilityHolder.transform.localScale = Vector3.one;
        }
    }

    public void AbilityTriggered(string abilityName) { }
    public void AbilityCancelled() { }

    public void AbilityExecuted(string abilityName, float cooldownDuration)
    {
        abilityHolders.Find(ah => ah.abilityName == abilityName).StartCooldown(cooldownDuration);
    }

    public void AbilitiesInitialized(List<Ability> abilities)
    {
        CreateAbilityBar(abilities);
    }
}
