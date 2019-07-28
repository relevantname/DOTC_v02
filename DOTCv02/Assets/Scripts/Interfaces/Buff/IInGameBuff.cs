using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInGameBuff
{
    void Activate();
    void Execute();
    void Expired();
}
