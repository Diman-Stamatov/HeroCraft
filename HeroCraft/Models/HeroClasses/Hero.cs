using HeroCraft.Models.HeroClasses.Roles;
using HeroCraft.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.RoleType;

namespace HeroCraft.Models.HeroClasses;

public abstract class Hero : ICastAura, ICastShield
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int SpellPower { get; set; }
    public double ShieldPower { get;set; }
    public double AuraPower { get; set; }
    public RoleType Role { get; set; }
    public bool Dead { get; set; }
    protected Hero(string name)
    {
        Name = name;
        Health = MaxHealth = 120;
        SpellPower = 90;
    }
    
    public string CastAura()
    {
        SpellPower = Convert.ToInt32(SpellPower * AuraPower);
        string auraMessage = $"{this.GetType().Name} {Name} cast an aura, which raised the hero's total ability power to {SpellPower}!";
        return auraMessage;
    }
    public string CastShield()
    {
        Health = Convert.ToInt32(Health * ShieldPower);        
        string auraMessage = $"{this.GetType().Name} {Name} cast a shield, which raised the hero's health to {Health}!";
        return auraMessage;
    }
    
    public string CastAbility(Hero target)
    {
        if (Dead)
        {
            string className = GetType().Name;
            string deadHeroMessage = $"{Name} is dead, how did that {className} get a turn?\n";
            return deadHeroMessage;
        }

        if (Role == DamageDealer) 
        {
            return DealDamage(target);
        }
        else
        {
            return Heal(target);     
        }
    }

    private string DealDamage(Hero target)
    {        
        if (target.Dead)
        {
            string deadTargetMessage = $"Stop! Stop! {target.Name} is already dead!\n";            
            return deadTargetMessage;
        }

        if (Name == target.Name)
        {
            string targetSelfMessage = $"{Name} refused to self-harm!\n";
            return targetSelfMessage;
        }

        string className = GetType().Name;
        string targetClassName = target.GetType().Name;
        var abilityResult = new StringBuilder();

        target.Health -= SpellPower;
        string damageMessage = $"{className} {Name} hit {target.Name} for {SpellPower} damage.";
        abilityResult.AppendLine(damageMessage);

        if (target.Health <= 0)
        {
            target.Dead = true;
            string targetDiedMessage = $"{targetClassName} {target.Name} died!";
            abilityResult.AppendLine(targetDiedMessage);
        }
        else if (target.Health > 1 && target.Health < 10)
        {
            string lowHealthMessage = $"{targetClassName} {target.Name} is low on health! Healers, handle it!";
            abilityResult.AppendLine(lowHealthMessage);
        }

        return abilityResult.ToString();
    }

    private string Heal(Hero target) 
    {
        if (target.Dead)
        {
            string deadTargetMessage = $"It's a bit late to heal {target.Name}. " +
                $"Too bad you never finished that Resurection spell quest...\n";
            return deadTargetMessage;
        }

        string className = GetType().Name;
        string targetClassName = target.GetType().Name;
        var abilityResult = new StringBuilder();

        target.Health += SpellPower;
        string healingMessage = $"{className} {Name} healed {target.Name} for {SpellPower} health.";
        abilityResult.AppendLine(healingMessage);

        if (target.Health == target.MaxHealth)
        {
            string message = $"{targetClassName} {target.Name} was fully healed!";
            abilityResult.AppendLine(message);
        }
        else if (target.Health > target.MaxHealth)
        {
            int difference = target.Health - target.MaxHealth;
            target.Health = target.MaxHealth;
            string message = $"{targetClassName} {target.Name} was overhealed for {difference}!";
            abilityResult.AppendLine(message);
        }
        return abilityResult.ToString();
    }
}
