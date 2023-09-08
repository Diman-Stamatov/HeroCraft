using HeroCraft.Models.HeroClasses;
using HeroCraft.Models.HeroFactory;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace HeroCraft;

internal class Program
{
    private const string DuplicateHeroMessage = "{0} has already been assigned a class. Please choose someone else.";
    private const string InvalidClassMessage = "{0} is not a valid class. " +
        "The Academy can only train Druids, Paladins, Rogues or Warriors";
    private const string HeroNotFoundMessage = "The hero {0} is not part of the roster! Please {1} someone else.";
    private const string InvalidCommandFormatMessage = "{0} is not a valid command action." +
        "Please choose from either \"+\" or \"-\".";
    private const string InvalidAbilityMessage = "{0} is not a valid ability name." +
        "Please choose from either \"Aura\" or \"Shield\".";

    static void Main(string[] args)
    {
        int numberOfHeroes = int.Parse(Console.ReadLine());
        var heroRoster = new Dictionary<string,Hero>(numberOfHeroes); 
        var appOutput = new StringBuilder();
        for (int i = 0; i < numberOfHeroes; i++)
        {
            string[] trainingRequest = Console.ReadLine().Split(" - ");
            if (trainingRequest[0] == "Automate")
            {
                DemonstrateApp();
                return;
            }            
            string heroClass = trainingRequest[0];
            string heroName = trainingRequest[1];

            var newHero = Academy.TrainHero(heroClass, heroName);
            if (newHero == null)
            {
                appOutput.AppendLine(string.Format(InvalidClassMessage, heroClass));
                continue;
            }

            if (heroRoster.ContainsKey(heroName))
            {
                appOutput.AppendLine(string.Format(DuplicateHeroMessage, heroName));
                continue;
            }

            heroRoster.Add(heroName, newHero);
        }
        
        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] command = Console.ReadLine().Split(' ');
            if (command[0] == "Demonstrate")
            {
                DemonstrateApp();
                return;
            }

            string actorName = command[0];
            if (!heroRoster.ContainsKey(actorName))
            {
                string action = "command";
                appOutput.AppendLine(string.Format(HeroNotFoundMessage, actorName, action));
                continue;
            }
            var actor = heroRoster[actorName];

            string commandAction = command[1];
            string targetName = command[2];
            
            if (commandAction == "-")
            {
                if (!heroRoster.ContainsKey(targetName))
                {
                    string action = "target";
                    appOutput.AppendLine(string.Format(HeroNotFoundMessage, targetName, action));
                    continue;
                }
                var target = heroRoster[targetName];

                string abilityResult = actor.CastAbility(target);
                appOutput.Append(abilityResult);
            }
            else if (commandAction == "+") 
            {
                switch (targetName.ToLower())
                {
                    case "aura":
                        string auraResult = actor.CastAura();
                        appOutput.AppendLine(auraResult);
                        break;
                    case "shield":
                        string shieldResult = actor.CastShield();
                        appOutput.AppendLine(shieldResult);
                        break;
                    default:
                        appOutput.AppendLine(string.Format(InvalidAbilityMessage, targetName));
                        break;
                }
            }
            else
            {
                appOutput.AppendLine(string.Format(InvalidCommandFormatMessage, commandAction));
            }
        }
        Console.WriteLine(appOutput.ToString());
    }

    private static void DemonstrateApp()
    {
        string paladinClassName = "Paladin";
        string warriorClassName = "Warrior";
        string rogueClassName = "Rogue";
        string druidClassName = "Druid";

        var paladin = Academy.TrainHero(paladinClassName, "Loris");
        var warrior = Academy.TrainHero(warriorClassName, "Hyporis");
        var rogue = Academy.TrainHero(rogueClassName, "Koltila");
        var druid = Academy.TrainHero(druidClassName, "Settene");
        

        Console.WriteLine(paladin.SpellPower);
        paladin.CastAura();
        Console.WriteLine(paladin.SpellPower);
        Console.WriteLine();

        Console.WriteLine(rogue.SpellPower);
        rogue.CastAura();
        Console.WriteLine(rogue.SpellPower);
        Console.WriteLine();

        Console.WriteLine(druid.SpellPower);
        druid.CastAura();
        Console.WriteLine(druid.SpellPower);
        Console.WriteLine();

        Console.WriteLine(warrior.SpellPower);
        warrior.CastAura();
        Console.WriteLine(warrior.SpellPower);
        Console.WriteLine();
        rogue.CastAbility(warrior);
        rogue.CastAbility(warrior);
        rogue.CastAbility(warrior);
        rogue.CastAbility(warrior);
        paladin.CastAbility(warrior);
    }
}