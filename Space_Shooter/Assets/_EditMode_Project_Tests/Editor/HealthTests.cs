using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UnitTests
    {
        //Test to see that the player health decreases when the playerIsHit() method is called
        [Test]
        public void PlayerHealthDecreasesTest()
        {
            PlayerController playerController = new PlayerController();
            playerController.Start();

            Assert.AreEqual(80.0f, playerController.PlayerIsHit());
            Assert.AreEqual(60.0f, playerController.PlayerIsHit());
            Assert.AreEqual(40.0f, playerController.PlayerIsHit());
        }

        [Test]
        public void BossHealthDecreasesTest()
        {
            EnemyBoss enemyBoss = new EnemyBoss();
            enemyBoss.Start();

            Assert.AreEqual(90.0f, enemyBoss.TakeDamage());
        }
    }
}

