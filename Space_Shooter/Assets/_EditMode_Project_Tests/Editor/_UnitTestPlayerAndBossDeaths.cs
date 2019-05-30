
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class _UnitTestPlayerAndBossDeaths
    {
        //Test to see that the player health drops to 0 after 5 hits
        [Test]
        public void TestPlayerHealthIsZeroAfterFiveHits()
        {
            PlayerController playerController = new PlayerController();
            playerController.Start();

            float expected = 0.0f;

            for (int i = 0; i <= 4; i++)
            {
                playerController.TakeDamage();
            }

            float result = playerController.PlayerCurrentHealth();

            Assert.AreEqual(expected, result);
        }

        //Test to see that the player dies after 5 hits
        [Test]
        public void TestPlayerDiedOnFiveHits()
        {
            PlayerController playerController = new PlayerController();
            playerController.Start();

            bool expected = true;

            for (int i = 0; i <= 4; i++)
            {
                playerController.TakeDamage();
            }

            bool result = playerController.PlayerDeath();

            Assert.AreEqual(expected, result);
        }

        //Test to see that the boss health drops to zero after 5 hits
        [Test]
        public void TestBossHealthIsZeroAfterTenHits()
        {
            EnemyBoss boss = new EnemyBoss();
            boss.Start();

            float expected = 0.0f;

            for (int i = 0; i <= 9; i++)
            {
                boss.TakeDamage();
            }

            float result = boss.Health();

            Assert.AreEqual(expected, result);
        }

        //Test to see that the boss dies after 10 hits
        [Test]
        public void TestBossDiedOnTenHits()
        {
            EnemyBoss boss = new EnemyBoss();
            boss.Start();

            bool expected = true;

            for (int i = 0; i <= 9; i++)
            {
                boss.TakeDamage();
            }

            bool result = boss.Death();

            Assert.AreEqual(expected, result);
        }
    }
}