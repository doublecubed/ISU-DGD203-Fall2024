namespace FirstGame
{
    public static class PhysicsCalculator
    {
        private const float GravConst = 0.000000000066743f;
        
        public static float Force(float mass, float acceleration)
        {
            return mass * acceleration;
        }

        public static float GravitationalPull(float massOne, float massTwo, float distance)
        {
            return (GravConst * massOne * massTwo) / (distance * distance);
        }
    }
}