
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class _UnitTestPlayerAndBossDeaths
    {
        [Test]
        public void PlayerHealthIsZero()
        {
            PlayerController playerController = new PlayerController();
            playerController.Start();

            float expected = 0.0f;

            for (int i = 0; i <= 4; i++)
            {
                playerController.PlayerIsHit();
            }

            float result = playerController.PlayerHealth;

            Assert.AreEqual(expected, result);
        }

    //PlayerIsDead is omitted on PlayerController, thus this test is disregarded unless re-implemented
    /*     [Test]
        public void PlayerDied()
        {
            PlayerController playerController = new PlayerController();
            playerController.Start();

            bool expected = true;

            for (int i = 0; i <= 4; i++)
            {
                playerController.PlayerIsHit();
            }

            bool result = playerController.PlayerIsDead;

            Assert.AreEqual(expected, result);
        }
    */
        [Test]
        public void BossHealthIsZero()
        {
            EnemyBoss boss = new EnemyBoss();
            boss.Start();

            float expected = 0.0f;

            for (int i = 0; i <= 9; i++)
            {
                boss.TakeDamage();
            }

            float result = boss.bossHealth;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BossDied()
        {
            EnemyBoss boss = new EnemyBoss();
            boss.Start();

            bool expected = true;

            for (int i = 0; i <= 9; i++)
            {
                boss.TakeDamage();
            }

            bool result = boss.IsDead;

            Assert.AreEqual(expected, result);
        }
    }
}