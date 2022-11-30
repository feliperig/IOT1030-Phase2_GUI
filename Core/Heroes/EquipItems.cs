namespace IOT1030_Phase2_GUI.Core.Heroes
{
    class EquipItems
    {
        protected readonly Player player;
        public Map Map { get; private set;  }
        public Bow Bow { get; private set; }
        public Sword Sword { get; private set; }
        public Armour Armour { get; private set; }
        public Shield Shield { get; private set; }
        public MagicStick MagicStick { get; private set; }
        public RagePotion RagePotion { get; private set; }


        public bool Equip(Sword sword)
        {
            if(player.HasSword)
            {
                if ((BowEquipped()) || (ShieldEquipped() && MapEquipped()))
                {
                    return false;
                }
                Sword = sword;
                return true;
            }
            return false;
        }

        public bool Equip(Bow bow)
        {
            if (player.PlayerHasItem(bow))
            {
                if((SwordEquipped()) || (ShieldEquipped() && MapEquipped()))
                {
                    return false;
                }
                Bow = bow;
                return true;
            }
            return false;
        }


        public bool Equip(Shield shield)
        {
            if (player.PlayerHasItem(shield))
            {
                if (MapEquipped())
                {
                    return false;
                }
                else
                {
                    Shield = shield;
                    return true;
                }
            }
            return false;
        }

        
        public bool Equip(Map map)
        {
            if (player.HasMap)
            {
                if (ShieldEquipped() || SwordEquipped() || MagicStickEquipped())      
                {
                    return false;
                }
                else
                {
                    Map = map;
                    return true;
                }
            }
            return false;
        }

        public bool Equip(Armour armour)
        {
            if (player.PlayerHasItem(armour) || ArmourEquipped())                               
            {
                Armour = armour;
                return true;
            }
            return false;
        }

        public bool Equip(MagicStick magicStick)
        {
            if (player.PlayerHasItem(magicStick))
            {
                if (SwordEquipped() && !ShieldEquipped())
                {
                    return false;
                }
                else if (!SwordEquipped() && ShieldEquipped())
                {
                    MagicStick = magicStick;
                    return true;
                }
                else if (MapEquipped())                                 
                {
                    return false;
                }
                MagicStick = magicStick;
                return true;
            }
            return false;
        }

        public bool MapEquipped() => Map != null;
        public bool BowEquipped() => Bow != null;
        public bool SwordEquipped() => Sword != null;
        public bool ShieldEquipped() => Shield != null;
        public bool ArmourEquipped() => Armour != null;
        public bool UseRagePotion() => RagePotion != null;
        public bool MagicStickEquipped() => MagicStick != null;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (SwordEquipped())
                sb.AppendLine($"{Sword}\n");
            else
                sb.AppendLine("No sword equipped\n");
            if (ShieldEquipped())
                sb.AppendLine($"{Shield}\n");
            else
                sb.AppendLine("No shield equipped\n");
            if (ArmourEquipped())
                sb.AppendLine($"{Armour}");
            else
                sb.AppendLine("No Armour equipped");
            if (MapEquipped())
                sb.AppendLine($"{Map}\n");
            else
                sb.AppendLine("No map equipped\n");
            if (MagicStickEquipped())
                sb.AppendLine($"{MagicStick}");
            else
                sb.AppendLine("No MagicStick equipped");
            return sb.ToString();
        }
    }
}
