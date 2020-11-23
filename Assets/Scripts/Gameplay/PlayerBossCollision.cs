using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with a Boss.
    /// </summary>
    /// <typeparam name="BossCollision"></typeparam>
    public class PlayerBossCollision : Simulation.Event<PlayerBossCollision>
    {
        public BossController boss;
        public PlayerController player;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var willHurtBoss = player.Bounds.min.y >= boss.Bounds.max.y || player.attacking;

            if (willHurtBoss)
            {
                if (boss.health <= 0)
                {
                    var bossHealth = boss.GetComponent<Health>();
                    if (bossHealth != null)
                    {
                        bossHealth.Decrement();
                        if (!bossHealth.IsAlive)
                        {
                            Schedule<BossDeath>().boss = boss;
                            player.Bounce(2);
                        }
                        else
                        {
                            player.Bounce(7);
                        }
                    }
                    else
                    {
                        Schedule<BossDeath>().boss = boss;
                        player.Bounce(2);
                    }
                }
                else
                {
                    boss.health--;
                    player.Bounce(10);
                }
            }
            else
            {
                Schedule<PlayerDeath>();
            }
        }
    }
}