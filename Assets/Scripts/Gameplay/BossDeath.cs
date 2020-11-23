using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the health component on an enemy has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="BossDeath"></typeparam>
    public class BossDeath : Simulation.Event<BossDeath>
    {
        public BossController boss;

        public override void Execute()
        {
            boss._collider.enabled = false;
            boss.control.enabled = false;
            if (boss._audio && boss.ouch)
                boss._audio.PlayOneShot(boss.ouch);
        }
    }
}