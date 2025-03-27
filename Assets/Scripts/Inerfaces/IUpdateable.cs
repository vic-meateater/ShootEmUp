namespace ShootEmUp
{
    public interface IUpdateable
    {
        
    }
    
    public interface IFixedUpdate : IUpdateable
    {
        public void OnFixedUpdate();
    }
    
    public interface IUpdate: IUpdateable
    {
        public void OnUpdate();
    }
}