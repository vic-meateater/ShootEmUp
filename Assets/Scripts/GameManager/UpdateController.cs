using System.Collections.Generic;

namespace ShootEmUp
{
    public class UpdateController
    {
        private readonly List<IUpdateable> _updateables = new();
        private readonly List<IFixedUpdateable> _fixedUpdateables = new();

        public void AddUpdateable(IUpdateable updateable)
        {
            _updateables.Add(updateable);
        }

        public void AddFixedUpdateable(IFixedUpdateable fixedUpdateable)
        {
            _fixedUpdateables.Add(fixedUpdateable);
        }

        public void Update()
        {
            for (var index = 0; index < _updateables.Count; index++)
            {
                var updateable = _updateables[index];
                updateable.Update();
            }
        }

        public void FixedUpdate()
        {
            for (var index = 0; index < _fixedUpdateables.Count; index++)
            {
                var fixedUpdateable = _fixedUpdateables[index];
                fixedUpdateable.FixedUpdate();
            }
        }
    }
}