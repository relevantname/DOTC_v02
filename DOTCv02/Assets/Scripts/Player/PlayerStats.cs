using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IPlayerStatsContainer, IBuffEvents
{
    [SerializeField]private PlayerData playerBaseStats;
    [HideInInspector]public PlayerData playerStats;

    private List<InitialBuff> initialBuffs = new List<InitialBuff>();
    private List<InGameBuff> inGameBuffs = new List<InGameBuff>();

    private void Start()
    {
        playerStats = Instantiate(playerBaseStats);

        ExecuteInitialBuffs();
    }

    public void InitializePlayerStats(PlayerData defaultData)
    {
        playerBaseStats = defaultData;
    }

    private void ExecuteInitialBuffs()
    {
        foreach (InitialBuff buff in initialBuffs)
            buff.Execute(this);
    }

    public bool IsBuffExists(InGameBuff buff)
    {
        return inGameBuffs.Exists(b => b.buffData._name == buff.buffData._name);
    }

    public void BuffCollected(InGameBuff collected)
    {
        inGameBuffs.Add(collected);
    }

    public void BuffExpired(InGameBuff expired)
    {
        inGameBuffs.Remove(expired);
    }
}
