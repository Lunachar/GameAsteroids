using UnityEngine;
namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            Enemy enemy =
            Object.Instantiate(Resources.Load<GameObject>("Enemy/Asteroid")).GetComponent<Asteroid>();
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}
