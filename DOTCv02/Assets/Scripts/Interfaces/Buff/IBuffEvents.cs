using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IBuffEvents : IEventSystemHandler
{
    void BuffCollected(InGameBuff collected);
    void BuffExpired(InGameBuff expired);
}
