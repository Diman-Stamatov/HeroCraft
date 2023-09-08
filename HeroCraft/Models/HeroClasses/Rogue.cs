using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.RoleType;

namespace HeroCraft.Models.HeroClasses;

public class Rogue : Hero
{
    public Rogue(string name) : base(name)
    {
        Health = MaxHealth = 230;
        AuraPower = 1.10;
        ShieldPower = 1.02;
        Role = DamageDealer;
    }  
}
