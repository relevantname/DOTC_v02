using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour, IPointerClickHandler
{
    public string abilityName;

    private GameObject abilityHolderCooldownMask;
    private Text abilityHolderCooldownText;
    private float remainingCooldownDuration;
    private float initialCooldownDuration;
    private bool isInCooldown;

    private void Start()
    {
        abilityHolderCooldownMask = transform.Find("AbilityHolderMask").gameObject;
        abilityHolderCooldownText = abilityHolderCooldownMask.GetComponentInChildren<Text>();
        abilityHolderCooldownMask.SetActive(false);
    }
    private void Update()
    {
        if (isInCooldown)
        {
            remainingCooldownDuration -= Time.deltaTime;
            abilityHolderCooldownText.text = ((int)remainingCooldownDuration).ToString();
            abilityHolderCooldownMask.GetComponent<Image>().fillAmount = remainingCooldownDuration / initialCooldownDuration;
            if (remainingCooldownDuration <= 0.0f)
            {
                isInCooldown = false;
                abilityHolderCooldownMask.SetActive(false);
                abilityHolderCooldownMask.GetComponent<Image>().fillAmount = 1;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (GameObject listener in EventListeners.Instance.listeners)
            ExecuteEvents.Execute<IAbilityEvents>(listener, null, (x, y) => x.AbilityTriggered(abilityName));
    }

    public void StartCooldown(float cooldownDuration)
    {
        initialCooldownDuration = cooldownDuration;
        remainingCooldownDuration = cooldownDuration;
        abilityHolderCooldownText.text = ((int) cooldownDuration).ToString();
        abilityHolderCooldownMask.SetActive(true);
        isInCooldown = true;
    }
}
