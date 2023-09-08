using HeroCraft.Models.HeroClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HeroCraft.Automation;

public class AutomatedInput
{
    private static List<string> HeroClasses = new () {"Druid", "Paladin", "Rogue", "Warrior", "Warlock"};
    private static List<string> HeroNames = new() { "Settene", "Loris", "Koltila", "Hyporis", "Gavinrad", "Gavinrad",
        "Maraad", "Yrel", "Maxwell", "Tethys", "Vanessa", "Mathias", "Lilian", "Karlain", "Ansirem"};
    private static List<string> BuffCommands = new() { "Aura", "Shield", "Haste" };

    private static string CastAbilitySeperator = " - ";
    private static string CastBuffSeperator = " + ";    
    private static string NewHeroSeperator = " - ";

    public static void DemonstrateApp()
    {
        var autoInput = new StringBuilder();        
        autoInput.AppendLine($"{HeroClasses.Count + 1}");

        string druidClass = HeroClasses[0];
        string nameOne = HeroNames[0];
        autoInput.AppendLine(druidClass + NewHeroSeperator + nameOne);

        string paladinClass = HeroClasses[1];
        string nameTwo = HeroNames[1];
        autoInput.AppendLine(paladinClass + NewHeroSeperator + nameTwo);

        string invalidClass = HeroClasses[4]; 
        string nameThree = HeroNames[2];
        autoInput.AppendLine(invalidClass + NewHeroSeperator + nameThree);

        string RogueClass = HeroClasses[2];
        autoInput.AppendLine(RogueClass + NewHeroSeperator + nameThree);

        string warriorClass = HeroClasses[3];
        string nameFour = HeroNames[3];
        autoInput.AppendLine(warriorClass + NewHeroSeperator + nameFour);

        autoInput.AppendLine(druidClass + NewHeroSeperator + nameFour);

        autoInput.AppendLine("17");

        string castAuraCommand = BuffCommands[0];
        string castShieldCommand = BuffCommands[1];
        string wrongBuffCommand = BuffCommands[2];

        autoInput.AppendLine(nameOne + CastBuffSeperator + castAuraCommand);
        autoInput.AppendLine(nameTwo + CastBuffSeperator + castShieldCommand);
        autoInput.AppendLine(nameFour + CastBuffSeperator + wrongBuffCommand);

        autoInput.AppendLine(nameTwo + CastAbilitySeperator + nameThree);
        autoInput.AppendLine(nameThree + CastAbilitySeperator + nameThree);

        string wrongName = HeroNames.Last();
        autoInput.AppendLine(wrongName + CastAbilitySeperator + nameThree);
        autoInput.AppendLine(nameTwo + CastAbilitySeperator + wrongName);

        string wrongSeperator = " * ";
        autoInput.AppendLine(nameTwo + wrongSeperator + nameThree);

        autoInput.AppendLine(nameOne + CastBuffSeperator + castShieldCommand);
        autoInput.AppendLine(nameFour + CastAbilitySeperator + nameOne);

        autoInput.AppendLine(nameFour + CastBuffSeperator + castAuraCommand);
        autoInput.AppendLine(nameFour + CastAbilitySeperator + nameTwo);
        autoInput.AppendLine(nameThree + CastAbilitySeperator + nameTwo);
        autoInput.AppendLine(nameFour + CastAbilitySeperator + nameTwo);

        autoInput.AppendLine(nameThree + CastAbilitySeperator + nameTwo);
        autoInput.AppendLine(nameOne + CastAbilitySeperator + nameTwo);
        autoInput.AppendLine(nameTwo + CastAbilitySeperator + nameThree);

        var reader = new StringReader(autoInput.ToString());
        Console.SetIn(reader);
    }

    public static void RandomizeInput()
    {
        var random = new Random();
        var randomInput = new StringBuilder();
        int numberOfHeroes = random.Next(5, 15);
        randomInput.AppendLine(numberOfHeroes.ToString());
        var recruitedHeroes = new List<string>();

        for ( int i = 0; i < numberOfHeroes; i++ )
        {
            int classIndex = random.Next(HeroClasses.Count);
            string classType = HeroClasses[classIndex];
            int nameIndex = random.Next(HeroNames.Count);
            string name = HeroNames[nameIndex];
            if (!recruitedHeroes.Contains(name) && classType != HeroClasses.Last())
            {
                recruitedHeroes.Add(name);
            }
            randomInput.AppendLine(classType + NewHeroSeperator + name);
        }

        int numberOfCommands = random.Next(15, 35);
        randomInput.AppendLine(numberOfCommands.ToString());

        for (int i = 0; i < numberOfCommands; i++)
        {
            int commandType = random.Next(2);
            if (commandType == 0)
            {
                string name = recruitedHeroes[random.Next(recruitedHeroes.Count)];
                string buff = BuffCommands[0];
                int buffType = random.Next(10);
                if (buffType == 0)
                {
                    buff = BuffCommands.Last();
                }
                else if (buffType % 2 == 1)
                {
                    buff = BuffCommands[1];
                }

                randomInput.AppendLine(name + CastBuffSeperator + buff);
            }
            else
            {
                string actorName = recruitedHeroes[random.Next(recruitedHeroes.Count)];
                string targetName = recruitedHeroes[random.Next(recruitedHeroes.Count)];
                randomInput.AppendLine(actorName + CastAbilitySeperator + targetName);
            }
        }
        var reader = new StringReader(randomInput.ToString());
        Console.SetIn(reader);
    }
}
