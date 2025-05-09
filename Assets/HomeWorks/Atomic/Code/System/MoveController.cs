using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.Serialization;
using Event = Atomic.Elements.Event;

namespace ShootEmUp.HomeWorks.Atomic
{
    public class MoveController : MonoBehaviour
    {
        private const float MAX_DISTANCE = 100f;
        
        public ReactiveVector3 MoveDirection { get; } = new ReactiveVector3();
        public ReactiveVector3 LookPoint { get; } = new ReactiveVector3();
        public ReactiveBool IsShooting { get; } = new ReactiveBool();
        
        [SerializeField] private LayerMask _groundLayer;
        //[SerializeField] private SceneEntity _playerEntity;
        
        private Camera _mainCamera;
        private Vector3 _direction;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            HandleMovementInput();
            HandleMouseInput();
            HandleFireInput();
        }

        private void HandleFireInput()
        {
            IsShooting.Value = Input.GetButtonDown("Fire1");
            if (Input.GetButtonDown("Fire1"))
            {
                //_playerEntity.Entity.GetDealDamageEvent().Invoke();
                Debug.Log("Player fire");
            }
        }

        private void HandleMovementInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            _direction = new Vector3(horizontal, 0f, vertical).normalized;
            MoveDirection.Value = _direction;
        }

        private void HandleMouseInput()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, MAX_DISTANCE, _groundLayer))
            {
                Vector3 lookPoint = hit.point;
                LookPoint.Value = lookPoint;
            }
        }
    }
}