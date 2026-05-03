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

        public override void Update(Frame frame, ref Filter filter)
        {
            var input = frame.GetPlayerInput(0);

            UpdateShipMovement(frame, ref filter, input);
        }

        private void UpdateShipMovement(Frame frame, ref Filter filter, Input* input)
        {
            FP shipAcceleration = 7;
            FP turnSpeed = 8;

            if (input->Up)
            {
                filter.Body->AddForce(filter.Transform->Up * shipAcceleration);
            }

            if (input->Left)
            {
                filter.Body->AddTorque(turnSpeed);
            }

            if (input->Right)
            {
                filter.Body->AddTorque(-turnSpeed);
            }

            filter.Body->AngularVelocity = FPMath.Clamp(filter.Body->AngularVelocity, -turnSpeed, turnSpeed);
        }
    }
}
