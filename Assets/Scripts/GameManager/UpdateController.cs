using System.Collections.Generic;

namespace ShootEmUp
{
    public class UpdateController
    {
        private readonly List<IUpdateable> _updateables = new();
        public void AddUpdateable(IUpdateable updateable)
        {
            _updateables.Add(updateable);
        }

        public void RemoveUpdateable(IUpdateable updateable)
        {
            _updateables.Remove(updateable);
        }

        public void OnUpdate()
        {
            for (var index = 0; index < _updateables.Count; index++)
            {
                var updateable = _updateables[index];
                if (updateable is IUpdate update)
                    update.OnUpdate();
            }
        }

        public void OnFixedUpdate()
        {
            for (var index = 0; index < _updateables.Count; index++)
            {
                var updateable = _updateables[index];
                if (updateable is IFixedUpdate fixedUpdate)
                    fixedUpdate.OnFixedUpdate();
            }
        }
    }
}