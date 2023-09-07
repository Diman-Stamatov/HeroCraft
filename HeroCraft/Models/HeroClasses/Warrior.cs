using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.Role;

namespace HeroCraft.Models.HeroClasses;

public class Warrior : Hero
{
    public Warrior(string name) : base(name) 
    {
        this.SpellPower = 120;
        this.Role = DamageDealer;
    }
    
    public override void CastAura()
    {
        this.SpellPower *= 105 / 100;
        base.CastAura();
    }

    public override void CastShield()
    {
        this.Health *= 105 / 100;
        base.CastShield();
    }
}
