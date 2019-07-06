using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionsInputManager
{
    bool GetShoot();
    bool GetCast();

    void ResetShoot();
    void ResetCast();
}
