using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    static public string surviveLevelName = "Autoimune Rampage";
    static public string surviveLevelIntroduction = "There is a Autoimune Rampage! Red Blood Cell need <color=red>stay alive</color>!";
    static public string surviveLevelTarget = "Survive {0} Seconds";

    static public string collectLevelName = "Collect Oxygen";
    static public string collectLevelIntroduction = "Red Blood Cell can <color=red>collect oxygen</color>. Hurry, other cells are counting on you!";
    static public string collectLevelTarget = "Collect {0} Oxygen";

    static public string deliverLevelName = "Deliver Oxygen";
    static public string deliverLevelIntroduction = "Cells are in need of oxygen! Red Blood Cell can <color=red>deliver oxygen</color> and keep them functional!";
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

    static public List<string> tutorialStrings = new List<string>()
    {
        "Left click to move, try to avoid germ bullets and collect oxygen.",
        "Right click to shoot, try to avoid germ bullets and kill virus.",
        "Move to the mutated cell that emitter germ bullets and devour it.",
        "You need to control both platelets at the same time, don't get any of them get hurt!",

    };

}
