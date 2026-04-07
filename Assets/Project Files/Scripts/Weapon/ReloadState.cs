using System;

namespace Project_Files.Scripts.Weapon
{
    [Serializable]
    public enum ReloadState
    {
        Readying,
        RemoveMag,
        InsertMag,
        ChamberRound,
        Bolting
    }
}