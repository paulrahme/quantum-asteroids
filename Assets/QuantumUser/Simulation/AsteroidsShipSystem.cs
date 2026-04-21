using Photon.Deterministic;

namespace Quantum.Asteroids
{
    public unsafe class AsteroidsShipSystem : SystemMainThreadFilter<AsteroidsShipSystem.Filter>
    {
        public struct Filter
        {
            // Reference to entity
            public EntityRef Entity;
            
            // Pointers to components
            public Transform2D* Transform;
            public PhysicsBody2D* Body;
        }

        public override void Update(Frame f, ref Filter filter)
        {
            filter.Body->AddForce(filter.Transform->Up);
        }
    }
}
