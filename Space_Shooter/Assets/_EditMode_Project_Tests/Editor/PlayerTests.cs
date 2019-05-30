
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests
    {
        //Test to see that the player health decreases when the TakeDamage() method is called
        //Player health starts at 100.0f, and decreases by 20.0f every hit
        //[Test]
        public void something()
        {
            GameController gameController = new GameController();
            gameController.SpawnWaves();

            Assert.AreEqual(2, gameController.wave);
        }
    }
}
