using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.Role;

namespace HeroCraft.Models.HeroClasses;

public class Druid : Hero
{
    public Druid(string name):base(name)
    {        
        this.Health = this.MaxHealth = 200;
        this.SpellPower = 80;
        this.Role = Healer;
    }

    public override void CastAura()
    {
        this.SpellPower *= 105 / 100;
        base.CastAura();
    }

    public override void CastShield()
    {
        this.Health *= 110 / 100;
        base.CastShield();
    }
}
