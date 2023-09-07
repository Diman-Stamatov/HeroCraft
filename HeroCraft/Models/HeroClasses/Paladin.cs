using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.Role;

namespace HeroCraft.Models.HeroClasses;

public class Paladin:Hero
{
    public Paladin(string name) : base(name)
    {
        this.Health = this.MaxHealth = 240;
        this.SpellPower = 100;
        this.Role = Healer;
    }

    public override void CastAura()
    {
        this.SpellPower *= 115 / 100;
        base.CastAura();        
    }

    public override void CastShield()
    {
        this.Health *= 112 / 100;
        base.CastShield();
    }
}
