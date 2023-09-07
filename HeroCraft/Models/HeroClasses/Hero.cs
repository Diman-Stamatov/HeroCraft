using HeroCraft.Models.HeroClasses.Roles;
using HeroCraft.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroCraft.Models.HeroClasses.Roles.Role;

namespace HeroCraft.Models.HeroClasses;

public abstract class Hero : ICastAura, ICastShield
{
    private const string DamageMessage = "{0} {1} hit {2} for {3} damage.";
    private const string HealingMessage = "{0} {1} healed {2} for {3} health.";    

    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int SpellPower { get; set; }
    public Role Role { get; set; }
    public bool Dead { get; set; }
    protected Hero(string name)
    {
        this.Name = name;
        this.Health = this.MaxHealth = 120;
        this.SpellPower = 90;
    }
    
    public virtual void CastAura()
    {
        string auraMessage = $"{this.Name} cast an aura, resulting in a total of {this.SpellPower} ability power!";
        Console.WriteLine(auraMessage);
    }
    public virtual void CastShield()
    {
        string auraMessage = $"{this.Name} cast a shield, resulting in a total of {this.Health} health!";
        Console.WriteLine(auraMessage);
    }
    
    public virtual void CastAbility(Hero target)
    {
        if (this.Dead)
        {
            string className = this.GetType().Name;
            Console.WriteLine($"{this.Name} is dead, how did that {className} get a turn?");
            return;
        }

        if (this.Role == DamageDealer) 
        {
            DealDamage(target);
        }
        else
        {
            Heal(target);     
        }
    }

    private void DealDamage(Hero target)
    {        
        if (target.Dead)
        {
            Console.WriteLine($"Stop! Stop! {target.Name} is already dead!");
            return;
        }

        string className = this.GetType().Name;
        string targetClassName = target.GetType().Name;

        target.Health -= SpellPower;
        Console.WriteLine(string.Format(DamageMessage, className, Name, target.Name, SpellPower));
        if (target.Health <= 0)
        {
            target.Dead = true;
            Console.WriteLine($"{targetClassName} {target.Name} died!");
        }
        else if (target.Health > 1 && target.Health < 10)
        {
            Console.WriteLine($"{targetClassName} {target.Name} is low on health! Healers, handle it!");
        }
    }

    private void Heal(Hero target) 
    {
        if (target.Dead)
        {
            Console.WriteLine($"It's a bit late to heal {target.Name}. Too bad you never finished that Resurection spell quest.");
            return;
        }

        string className = this.GetType().Name;
        string targetClassName = target.GetType().Name;

        target.Health += SpellPower;
        Console.WriteLine(string.Format(HealingMessage, className, Name, target.Name, SpellPower));
        if (target.Health == target.MaxHealth)
        {
            Console.WriteLine($"{targetClassName} {target.Name} was fully healed!");
        }
        else if (target.Health > target.MaxHealth)
        {
            int difference = target.Health - target.MaxHealth;
            target.Health = target.MaxHealth;
            Console.WriteLine($"{targetClassName} {target.Name} was overhealed for {difference}!");
        }
    }
}
