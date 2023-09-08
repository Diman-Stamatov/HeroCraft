using HeroCraft.Models.HeroClasses;
using HeroCraft.Models.HeroFactory;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using static HeroCraft.Automation.AutomatedInput;

namespace HeroCraft;

internal class Program
{
    static void Main(string[] args)
    {
        var defaultInput = Console.In;

        string initialInput = Console.ReadLine(); 
        
        bool automated = false;
        if (initialInput.ToLower() == "demonstrate")
        {
            automated = true;
            DemonstrateApp();
        }
        else if (initialInput.ToLower() == "randomize")
        {
            automated = true;
            RandomizeInput();
        }
        else 
        {
            var reader = new StringReader(initialInput);
            Console.SetIn(reader);
        }

        int numberOfHeroes = int.Parse(Console.ReadLine());
        if (!automated) 
        {
            Console.SetIn(defaultInput);
        }
        
        var heroRoster = new Dictionary<string,Hero>(numberOfHeroes); 
        var appOutput = new StringBuilder();

        for (int i = 0; i < numberOfHeroes; i++)
        {
            string[] trainingRequest = Console.ReadLine().Split(" - ");                    
            string heroClass = trainingRequest[0];
            string heroName = trainingRequest[1];

            var newHero = Academy.TrainHero(heroClass, heroName);
            if (newHero == null)
            {
                string invalidClassMessage = $"{heroClass} is not a valid class. " +
                    "The Academy can only train Druids, Paladins, Rogues or Warriors";
                appOutput.AppendLine(invalidClassMessage);
                continue;
            }

            if (heroRoster.ContainsKey(heroName))
            {
                string duplicateHeroMessage = $"{heroName} has already been assigned a class. Please choose someone else.";
                appOutput.AppendLine(duplicateHeroMessage);
                continue;
            }

            heroRoster.Add(heroName, newHero);
        }
        
        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] command = Console.ReadLine().Split(' ');
            string actorName = command[0];
            string heroNotFoundMessage = "The hero {0} is not part of the roster! Please {1} someone else.";

            if (!heroRoster.ContainsKey(actorName))
            {
                string action = "command";
               
                appOutput.AppendLine(string.Format(heroNotFoundMessage, actorName, action));
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
                    appOutput.AppendLine(string.Format(heroNotFoundMessage, targetName, action));
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
                        string invalidAbilityMessage = $"{targetName} is not a valid ability name. " +
                            "Please specify either \"Aura\" or \"Shield\".";
                        appOutput.AppendLine(invalidAbilityMessage);
                        break;
                }
            }
            else
            {
                string invalidCommandMessage = $"{commandAction} is not a valid command action. " +
                    $"Please specify either \"+\" or \"-\".";
                appOutput.AppendLine(invalidCommandMessage);
            }
        }
        Console.WriteLine(appOutput.ToString());
    }
}