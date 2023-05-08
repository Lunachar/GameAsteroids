using UnityEngine;
namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        public Health Health { get; protected set; }
        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            Asteroid enemy = Instantiate(Resources.Load<GameObject>("Enemy/Asteroid")).GetComponent<Asteroid>();
            enemy.Health = hp;
            return enemy;
        }
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;            
        }
    }
}
