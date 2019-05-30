
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthTests
    {
        //Test to see that the player health decreases when the TakeDamage() method is called
        //Player health starts at 100.0f, and decreases by 20.0f every hit
        [Test]
        public void PlayerHealthDecreasesTest()
        {
            PlayerController playerController = new PlayerController();
            playerController.Start();

            Assert.AreEqual(80.0f, playerController.TakeDamage());
            Assert.AreEqual(60.0f, playerController.TakeDamage());
            Assert.AreEqual(40.0f, playerController.TakeDamage());
        }

        //Test to see that the boss health decreases when TakeDamage() method is called
        //boss health starts at 100.0f, and decreasaes by 10.0f every hit
        [Test]
        public void BossHealthDecreasesTest()
        {
            EnemyBoss enemyBoss = new EnemyBoss();
            enemyBoss.Start();

            Assert.AreEqual(90.0f, enemyBoss.TakeDamage());
        }
    }
}

