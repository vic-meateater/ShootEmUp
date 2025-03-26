using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour, IFixedUpdate, IGameStartListener, IGamePauseListener, IGameResumeListener, IGameStopListener
    {
        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;
        private Transform _myTransform;
        private bool _canUpdate;

        [SerializeField]
        private Params _params;
        
        public void OnStartGame()
        {
            _canUpdate = true;
            _startPositionY = _params._startPositionY;
            _endPositionY = _params._endPositionY;
            _movingSpeedY = _params._movingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        public void OnPauseGame()
        {
            _canUpdate = false;
        }
        
        public void OnResumeGame()
        {
            _canUpdate = true;
        }

        public void OnStopGame()
        {
            _canUpdate = false;
        }

        void IFixedUpdate.OnFixedUpdate()
        {
            UpdateBack();
        }

        private void UpdateBack()
        {
            if (!_canUpdate) return;
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * Time.fixedDeltaTime,
                _positionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float _startPositionY;

            [SerializeField]
            public float _endPositionY;

            [SerializeField]
            public float _movingSpeedY;
        }
    }
}