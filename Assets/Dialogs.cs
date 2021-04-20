using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    static public string surviveLevelName = "Autoimmune Rampage";
    static public string surviveLevelIntroduction = "There is a Autoimmune Rampage! Red Blood Cell need <color=red>stay alive</color>!";
    static public string surviveLevelTarget = "Survive {0} Seconds";

    static public string collectLevelName = "Collect Oxygen";
    static public string collectLevelIntroduction = "Red Blood Cell can <color=blue>collect oxygen</color>. Hurry, other cells are counting on you!";
    static public string collectLevelTarget = "Collect {0} Oxygen";

    static public string deliverLevelName = "Deliver Oxygen";
    static public string deliverLevelIntroduction = "Cells are in need of oxygen! Red Blood Cell can <color=blue>deliver oxygen</color> and keep them functional!";
    static public string deliverLevelTarget = "Deliver {0} Oxygen";

    static public string shootLevelName = "Shoot Antibodies";
    static public string shootLevelIntroduction = "Virus invade! B Cell need to <color=red>shoot antibodies</color> and kill virus!";
    static public string shootLevelTarget = "Kill {0} Virus";

    static public string devourLevelName = "Devour Mutated Cell";
    static public string devourLevelIntroduction = "Macrophage can get close to mutated cell and <color=red>devour them</color>.";
    static public string devourLevelTarget = "Devour {0} Cell";

    static public string fixLevelName = "Fix Wound";
    static public string fixLevelIntroduction = "Multiple platelets can work together to <color=red>fix wound</color>";
    static public string fixLevelTarget = "Fix Wound";


    //level finish
    static public string difficultyIncrease = "<color=red>Difficulty increased!</color>";
    static public string remainHP = "You have <color=red>{0}</color> health remaining.";
    static public string succeed = "Succeed!";
    static public string failed = "Failed!";


    static public List<string> tutorialStrings = new List<string>()
    {
        "<color=yellow>Left click</color> to move, try to avoid germ bullets and collect oxygen. You only have <color=yellow>10 seconds</color>!",
        "<color=yellow>Right click</color> to shoot, try to avoid germ bullets and kill virus.",
        "<color=yellow>Move</color> to the mutated cell that emitter germ bullets and devour it.",
        "You need to <color=yellow>control both platelets</color> at the same time, don't get any of them get hurt!",

    };


    static public List<string> obstacleIntroduce = new List<string>()
    {
        "",
        "<color=red>Watch out for the Blood Blobs!\n</color> They will fly around and hit you!",
        "<color=red>Watch out for the Cholesterol!\n</color> It will slow down the cell!",
        "<color=red>Watch out for the Alcohol!\n</color> It will make your move to the opposite!",
    };

}
