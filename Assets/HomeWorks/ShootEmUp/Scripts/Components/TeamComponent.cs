using UnityEngine;

namespace ShootEmUp
{
    public sealed class TeamComponent : MonoBehaviour, ITeammate
    {
        [SerializeField] private bool _isPlayer;
        public bool IsPlayer => _isPlayer;   
    }

    public interface ITeammate
    {
        bool IsPlayer { get; }
    }
}