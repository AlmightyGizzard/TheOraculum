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

    static string eventString = @"
    {
        ""name"":[""Rickets"", ""Zachary"", ""Fayra"", ""Allura"", ""Ashton""],
        ""setPronouns"":[""[heroThey:they][heroThem:them][heroTheir:their][heroTheirs:theirs]"",""[heroThey:she][heroThem:her][heroTheir:her][heroTheirs:hers]"",""[heroThey:he][heroThem:him][heroTheir:his][heroTheirs:his]""]
        ""setSchool"":[
        ""[school:Abjuration][specialty:shield magic, enhancement spells, planar magic][schoolPronoun:abjuror]"",
        ""[school:Conjuration][specialty:elemental manipulation, summoning, teleportation][schoolPronoun:conjurer, summoner, planeswalker]"",
        ""[school:Divination][specialty:analysis, communion][schoolPronoun:diviner, seer, soothsayer]"",
        ""[school:Enchantment][specialty:control spells, coercion magic, artifice][schoolPronoun:artificer, enchanter, spellbinder]"",
        ""[school:Evocation][specialty:medicine, spell sculpting, metamagic][schoolPronoun:healer, elementalist, evoker]"",
        ""[school:Illusion][specialty:projection][schoolPronoun:illusionist, magician]"",
        ""[school:Necromancer][specialty:arcane manufacture, advanced necrosis, corpse magic][schoolPronoun:necromancer, reanimator, occultist]"",
        ""[school:Transmutation][specialty:communication, bodily adaption, dunamancy, alchemy][schoolPronoun:alchemist, transmuter]""],
        
        ""sequence"":[""#arcanist.capitalise# was a powerful #schoolPronoun#""], 
        ""origin"":[""#[#setPronouns#][#setSchool#][arcanist:#name#]sequence#""]
    }";
    TraceryGrammar grammar = new TraceryGrammar(eventString);
    public GameObject UI_Panel;
    private TopDownController player;
    public string text;
    public bool reading = false;
    public override string GetDescription(){
        return "Hold [E] to read the passage.";
    }

    public override void Interact(bool alt = false){
        Debug.Log("Reading!");
        UI_Panel.GetComponentInChildren<TextMeshProUGUI>().text = text;
        player.reading = true;
    }

    // On awake, use tracery to generate a text string.
    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownController>();
        text = grammar.Generate();
    }

    public void FixedUpdate()
    {
        UI_Panel.SetActive(reading);
        reading = false;
    }
}
