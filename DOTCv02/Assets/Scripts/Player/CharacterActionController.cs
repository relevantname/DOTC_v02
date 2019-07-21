using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class CharacterActionController : InputManager, IAbilityControllerEvents 
{
    private CharacterAbilityController abilityController;

    public int maxAllowedAbilityNumber = 4;
    private Command[] abilityCommands;

    private void Awake()
    {
        EventListeners.Instance.AddListener(this.gameObject);
    }
    
    private void Update()
    {
        if (abilityCommands == null || abilityCommands.Length == 0)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            abilityCommands[1].Execute();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            abilityCommands[2].Execute();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            abilityCommands[3].Execute();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            abilityCommands[4].Execute();
        }
    }

    public void AbilitiesInitialized(List<Ability> abilities)
    {
        if (maxAllowedAbilityNumber < abilities.Count)
            Debug.Log("Error in ability count!");

        abilityCommands = new Command[maxAllowedAbilityNumber];

        for (int i = 0; i < maxAllowedAbilityNumber; i++)
        {
            if (i >= abilities.Count)
                abilityCommands[i] = new EmptyCommand();
            else 
                abilityCommands[i] = new AbilityCommand(abilities[i].abilityData.abilityName);
        }
    }
}
