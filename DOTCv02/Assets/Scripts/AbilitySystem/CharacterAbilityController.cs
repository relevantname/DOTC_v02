using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterAbilityController : MonoBehaviour, IAbilityEvents
{
    public List<GameObject> abilityPrefabs = new List<GameObject>();
    private List<Ability> abilities = new List<Ability>();
    public Ability currentActiveAbility = null;

    private Animator characterAnimator;
    
    private void Start()
    {
        EventListeners.Instance.AddListener(this.gameObject);
        characterAnimator = GetComponentInChildren<Animator>();

        InitializeAbilities();
    }

    // Initialization of abilities.
    private void InitializeAbilities()
    {
        foreach (GameObject abilityPrefab in abilityPrefabs)
        {
            GameObject abilityGO = Instantiate(abilityPrefab, this.transform.position, Quaternion.identity);
            abilityGO.transform.SetParent(this.transform);
            abilities.Add(abilityGO.GetComponent<Ability>());
        }
        
        foreach (GameObject listener in EventListeners.Instance.listeners)
            ExecuteEvents.Execute<IAbilityControllerEvents>(listener, null,
                (x, y) => x.AbilitiesInitialized(abilities));
    }

    // This method is executed from Animation events.
    public void ExecuteAbilityWithAnimationEvent()
    {
        currentActiveAbility.Execute();
    }

    // This method triggered when player use an ability.
    public void AbilityTriggered(string abilityName)
    {
        Ability abilityToTrigger = abilities.Find(a => a.abilityData.abilityName == abilityName);
        if (abilityToTrigger.isInCooldown == true)
            return;

        if (currentActiveAbility is IWaitableAbility)
            AbilityCancelled();

        currentActiveAbility = abilityToTrigger;
        if (characterAnimator != null && !string.IsNullOrEmpty(currentActiveAbility.abilityData.animationName))
            characterAnimator.SetTrigger(currentActiveAbility.abilityData.animationName);
        currentActiveAbility.Activate();
    }
    // This method triggered when an ability is executed.
    public void AbilityExecuted(string abilityName, float cooldownDuration)
    {
        currentActiveAbility = null;
    }
    // This method triggered when an ability is cancelled.
    public void AbilityCancelled()
    {
        IWaitableAbility waitableAbility = currentActiveAbility as IWaitableAbility;
        currentActiveAbility = null;
    }
}
