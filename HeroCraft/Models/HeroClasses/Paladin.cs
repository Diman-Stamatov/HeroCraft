using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.RoleType;

namespace HeroCraft.Models.HeroClasses;
public class Paladin:Hero
{
    public Paladin(string name) : base(name)
    {
        Health = MaxHealth = 240;
        SpellPower = 100;
        AuraPower = 1.15;
        ShieldPower = 1.12;
        Role = Healer;
    }
}
