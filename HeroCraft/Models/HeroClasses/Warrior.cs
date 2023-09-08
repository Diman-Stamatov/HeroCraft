using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.RoleType;

namespace HeroCraft.Models.HeroClasses;

public class Warrior : Hero
{
    public Warrior(string name) : base(name) 
    {
        SpellPower = 120;
        AuraPower = 1.05;
        ShieldPower = 1.05;
        Role = DamageDealer;
    }
}
