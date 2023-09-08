using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.RoleType;

namespace HeroCraft.Models.HeroClasses;

public class Druid : Hero
{
    public Druid(string name):base(name)
    {        
        Health = MaxHealth = 200;
        SpellPower = 80;
        AuraPower = 1.05;
        ShieldPower = 1.10;
        Role = Healer;
    }
}
