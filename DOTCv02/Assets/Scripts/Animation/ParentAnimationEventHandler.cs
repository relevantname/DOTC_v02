using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class responsible for transmit animation events to parent gameobject scrtips.
/// </summary>
public class ParentAnimationEventHandler : MonoBehaviour, IAnimationEventHandler<string>
{
    public void HandleEvent(string eventParameter)
    {
        transform.parent.SendMessage(eventParameter);
    }
}
