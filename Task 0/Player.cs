using System.Collections.Generic;
using Task_0.Interfaces;

namespace Task_0
{
    public class Player : IPlayer
    {
        public void Play(IPlay play)
        {
            play.Play();
        }
        
    }
}