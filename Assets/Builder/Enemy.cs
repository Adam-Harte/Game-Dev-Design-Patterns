using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Speed { get; private set; }
    public int Damage { get; private set; }

    // create a builder to simplify building objects that have a lot of properties that would
    // require a large constructor. The Builder breaks it down so we set each field on its own in one method
    // then call the Buiuld method to build the new object with all the fields.
    public class Builder
    {
        private string name;
        private int health;
        private int speed;
        private int damage;

        public Builder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public Builder WithHealth(int health)
        {
            this.health = health;
            return this;
        }

        public Builder WithSpeed(int speed)
        {
            this.speed = speed;
            return this;
        }

        public Builder WithDamage(int damage)
        {
            this.damage = damage;
            return this;
        }

        public Enemy Build()
        {
            var enemy = new GameObject("Enemy").AddComponent<Enemy>();

            enemy.Name = this.name;
            enemy.Health = this.health;
            enemy.Speed = this.speed;
            enemy.Damage = this.damage;

            return enemy;
        }
    }
}
