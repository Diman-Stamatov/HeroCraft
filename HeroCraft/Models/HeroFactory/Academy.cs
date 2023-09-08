using HeroCraft.Models.HeroClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroCraft.Models.HeroFactory;

public class Academy
{
    public static Hero TrainHero(string heroClass, string heroName)
    {
        switch (heroClass.ToLower())
        {
            case "druid":
                return new Druid(heroName);                
            case "paladin":
                return new Paladin(heroName);
            case "rogue":
                return new Rogue(heroName);
            case "warrior":
                return new Warrior(heroName);
            default:
                return null;
        }
    }
}
