using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    static public string surviveLevelName = "Autoimmune Rampage";
    static public string surviveLevelIntroduction = "The immune system has gone rogue and is attacking the blood cells! You, the red blood cell, has to <color=red>stay alive</color>!";
    static public string surviveLevelTarget = "Survive {0} Seconds";

    static public string collectLevelName = "Collect Oxygen";
    static public string collectLevelIntroduction = "You are a Red blood cell, and your job is to <color=blue>collect oxygen</color>. Hurry, the other cells are counting on you!";
    static public string collectLevelTarget = "Collect {0} Oxygen";

    static public string deliverLevelName = "Deliver Oxygen";
    static public string deliverLevelIntroduction = "You are a Red blood cell, and your job is to <color=blue>deliver oxygen</color> to the other cells in the body!";
    static public string deliverLevelTarget = "Deliver {0} Oxygen";

    static public string shootLevelName = "Virus Invasion";
    static public string shootLevelIntroduction = "You are a B-cell, a type of white blood cell. Using right click, <color=red>shoot antibodies</color> at a virus to kill it!";
    static public string shootLevelTarget = "Kill {0} Virus";

    static public string devourLevelName = "Cell Mutation";
    static public string devourLevelIntroduction = "You are a Macrophage, a type of white blood cell. Macrophages can touch mutated cells to <color=red>destroy them</color>.";
    static public string devourLevelTarget = "Destroy {0} Cell";

    static public string fixLevelName = "Wounded";
    static public string fixLevelIntroduction = "You are a Platelet. Multiple platelets combine into a blood clot to <color=red>seal a wound</color>";
    static public string fixLevelTarget = "Seal the wound";


    //level finish
    static public string difficultyIncrease = "<color=red>Difficulty increased!</color>";
    static public string remainHP = "You have <color=red>{0}</color> health remaining.";
    static public string succeed = "Victory!";
    static public string failed = "Failure!";


    static public List<string> tutorialStrings = new List<string>()
    {
        "<color=yellow>Left click</color> to move. Your goal here is to collect oxygen while avoiding the virus' bullets. Each type of level has a different goal. You only have <color=yellow>10 seconds</color> to complete each level - but time is slowed when you stand still!",
        "<color=yellow>Right click</color> to shoot. Your goal is to kill the virus while avoiding the virus' bullets.",
        "<color=yellow>Move</color> to the mutated cell to destroy it. Avoid the bullets it will shoot at you!",
        "You need to <color=yellow>control both platelets</color> at the same time, to guide them both toward the wound. Don't let any of them get shot!",

    };


    static public List<string> obstacleIntroduce = new List<string>()
    {
        "",
        "<color=red>Watch out for the Tissue blobs!\n</color> They will fly around and might obstruct your movement!",
        "<color=red>Watch out for the Cholesterol!\n</color> If you touch it, it will slow you down!",
        "<color=red>Watch out for the Alcohol!\n</color> If you touch it, it will reverse your movement controls!",
    };

}
