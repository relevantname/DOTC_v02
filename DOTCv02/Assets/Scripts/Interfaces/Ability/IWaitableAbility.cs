using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWaitableAbility
{
    IEnumerator WaitForAnEvent();
    void CancelAbility();
}
