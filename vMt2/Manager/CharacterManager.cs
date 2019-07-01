using System;
using System.Collections.Generic;
using System.Text;
using vMt2.Models;

namespace vMt2.Manager
{
    public class CharacterManager
    {
        private MainCharacter mainCharacter;

        public MainCharacter GetCharacter()
        {
            if (mainCharacter == null)
                throw new NullReferenceException();
            return mainCharacter;
        }

        public void SetCharacter(MainCharacter mainCharacter)
        {
            this.mainCharacter = mainCharacter;
        }
    }
}
