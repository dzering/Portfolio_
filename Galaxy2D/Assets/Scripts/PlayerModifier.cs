using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Galaxy
{
    internal class PlayerModifier
    {
        protected BarrelProperties barrel;
        protected PlayerModifier NextModifier;

        public PlayerModifier(BarrelProperties barrel)
        {
            this.barrel = barrel;
        }

        public void Add(PlayerModifier modifier)
        {
            if(NextModifier != null)
            {
                NextModifier.Add(modifier);
            }
            else
            {
                NextModifier = modifier;
            }
        }

        public virtual void Handle() => NextModifier?.Handle();

    }
}