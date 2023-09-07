using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.Role;

namespace HeroCraft.Models.HeroClasses;

public class Rogue : Hero
{
    public Rogue(string name) : base(name)
    {
        this.Health = this.MaxHealth = 230;
        this.Role = DamageDealer;
    }  

    public override void CastAura()
    {
        this.SpellPower *= 110 / 100;
        base.CastAura();
    }

    public override void CastShield()
    {
        this.Health *= 102 / 100;
        base.CastShield();
    }
}
