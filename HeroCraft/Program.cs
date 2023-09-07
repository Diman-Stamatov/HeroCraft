using HeroCraft.Models.HeroClasses;

namespace HeroCraft;

internal class Program
{
    static void Main(string[] args)
    {
        var pala = new Paladin("Paladin");
        var rogue = new Rogue("ROgue");
        
        rogue.CastAbility(rogue);
        rogue.CastAbility(rogue);
        rogue.CastAbility(rogue);
        rogue.CastAbility(rogue);
        pala.CastAbility(rogue);
        Console.WriteLine(rogue.Name);
        Console.WriteLine(rogue.SpellPower);
    }
}