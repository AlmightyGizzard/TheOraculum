using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityTracery;


public class TextSwitch : Interactable
{

    static string grammarString = @"
    {
        ""origin"":[""#sequence#""],

        ""aTarget"":[""body"", ""mind"", ""self"", ""soul"", ""being""],
        ""aMeans"":[""magus"", ""medeis"", ""veneficum"", ""praecantatio"", ""devotio""],
        ""aDeity"":[""Ioun"", ""Pelor"", ""Asmodeus"", ""Mephistopheles"", ""Vecna"", ""Odin"", ""Hinch""],
        ""aMethod"":[""#aMeans#"", ""#aDeity#""],
        ""aGoal"":[""subterlabor"", ""evolo"", ""fugio"", ""profugio"", ""defugio"", ""excido"", ""ecfugio"", ""impertus"", ""relinquo"", ""transulto""],
        ""aPlace"":[""domus"", ""nidus"", ""penates"", ""asa"", ""libertas"", ""vacatio"", ""elutheria"", ""aevi"", ""discede"", ""procul""],
        ""aTo"":[""usque"", ""usquead"", ""indu"", ""erga"", ""contra"", ""versum"", ""directio"", ""vorsum"", ""propius"", ""homius""],
        ""aVia"":[""via"", ""limes"", ""usura"", ""fructus"", ""usus"", ""usurpatio"", ""ec"", ""per"", ""gratia"", ""propter""],
        ""aGive"":[""tribuo"", ""indo"", ""sufficio"", ""subficio"", ""commodo"", ""affero"", ""porrigo"", ""praesto"", ""cedo"", ""fateor""],

        ""sequence"":[
        ""#aVia# - #aMethod# - #aGoal# - #aTo# - #aPlace#"",
        ""#aGoal# - #aTo# - #aPlace# - #aVia# - #aMethod#"",
        ""#aVia# - #aDeity# - #aMeans# - #aGive# - #aGoal#"",
        ""#aGive# - #aPlace# - #aVia# - #aGoal# -  #aMeans#"",
        ""#aGive# - #aGoal# - #aTo# - #aMeans# - #aPlace#"",
        ""#aDeity# - #aGive# - #aMeans# - #aTo# - #aGoal#""]
    }";

    public GameObject UI_Panel;
    private TopDownController player;
    public string text;
    public bool reading = false;

    public override string GetDescription(){
        return "Hold [E] to read the passage.";
    }

    public override void Interact(bool alt = false){ 
        //Debug.Log("Reading!");
        UI_Panel.GetComponentInChildren<TextMeshProUGUI>().text = text;
        player.reading = true;
    }

    // On awake, use tracery to generate a text string.
    public void Awake()
    {        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownController>();
        UI_Panel = player.read_Panel;
    }

    public void FixedUpdate()
    {
        UI_Panel.SetActive(reading);
        reading = false;
    }
}
