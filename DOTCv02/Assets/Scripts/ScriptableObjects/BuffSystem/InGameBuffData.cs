using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InGameBuffData", menuName = "BuffData/InGameBuffData")]
public class InGameBuffData : BuffData
{
    public float _duration;
    public bool _isEffectedImmediately;
    public GameObject _model;
    public bool _isStackable;
}
