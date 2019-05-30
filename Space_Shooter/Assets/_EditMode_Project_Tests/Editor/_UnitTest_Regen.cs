using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	
	public class _UnitTest_Regen
    {
	
		//Test to see if player gains 10 health after being hit by 20 damage
		[Test]
        public void PlayerRegenTest() 
		{
        PlayerController player = new PlayerController();
		
		player.Start();
		player.TakeDamage(); //Player takes 20 damage
		player.PlayerRegenHealth(); //Regen 10 health
		float health = player.PlayerHealth; //Obtain health

		Assert.AreEqual(90.0f, health);
        }
	
    }
	
}
