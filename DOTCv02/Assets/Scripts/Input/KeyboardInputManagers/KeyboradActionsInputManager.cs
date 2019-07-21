using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboradActionsInputManager : InputManager, IInputManager, IAbilityControllerEvents
{
    private CharacterAbilityController abilityController;

    public int maxAllowedAbilityNumber = 4;
    private ICommand[] abilityCommands;
    
    public override void Start()
    {
        base.Start();
        EventListeners.Instance.AddListener(this.gameObject);
    }

    private void Update()
    {
        GetInputs();
    }

    public void GetInputs()
    {
        if (abilityCommands == null || abilityCommands.Length == 0)
            return;

        if (_unityServices.GetKeyDown(KeyCode.Alpha1))
        {
            abilityCommands[0].Execute();
        }
        else if (_unityServices.GetKeyDown(KeyCode.Alpha2))
        {
            abilityCommands[1].Execute();
        }
        else if (_unityServices.GetKeyDown(KeyCode.Alpha3))
        {
            abilityCommands[2].Execute();
        }
        else if (_unityServices.GetKeyDown(KeyCode.Alpha4))
        {
            abilityCommands[3].Execute();
        }
    }

    public void AbilitiesInitialized(List<Ability> abilities)
    {
        if (maxAllowedAbilityNumber < abilities.Count)
            Debug.Log("Error in ability count!");

        abilityCommands = new ICommand[maxAllowedAbilityNumber];

        for (int i = 0; i < maxAllowedAbilityNumber; i++)
        {
            if (i >= abilities.Count)
                abilityCommands[i] = new EmptyCommand();
            else
                abilityCommands[i] = new AbilityCommand(abilities[i].abilityData.abilityName);
        }
    }
}
