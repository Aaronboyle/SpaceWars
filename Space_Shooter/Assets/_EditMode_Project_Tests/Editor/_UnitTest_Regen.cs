using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	
	public class _UnitTest_Regen
    {
	
		//Test to see if player can regenerate health
		[Test]
        public void PlayerRegenTest() 
		{
        PlayerController player = new PlayerController();
		
		player.Start();
		player.PlayerIsHit(); //Player takes 20 damage
	//	player.PlayerRegenHealth(); //Regen 10 health
	//	float health = player.PlayerCurrentHealth(); //Obtain health

	//	Assert.AreEqual(90.0f, health);
        }
	
    }
	
}
