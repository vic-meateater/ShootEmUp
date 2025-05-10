using System;

namespace ShootEmUp.HomeWorks.Atomic
{
    [Serializable]
    public class GameServices
    {
        public PlayerService PlayerService;
        public WeaponService WeaponService;
        public BulletsService BulletsService;
    }
}