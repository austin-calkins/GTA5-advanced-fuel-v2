using GTA;
using System;

namespace Advanced_Fuel_Mod_v2
{
    internal class Animation
    {
        public Animation()
        {
        }

        public static void play(string animationSet, string animationName, int time, Vehicle v)
        {
            try
            {
                Game.get_Player().get_Character().get_Task().PlayAnimation(animationSet, animationName, 1f, time, true, 0f);
            }
            catch (Exception exception)
            {
                LOG.write("Error playing animation");
            }
        }
    }
}