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
        ""setPronouns"":[""[heroThey:they][heroThem:them][heroTheir:their][heroTheirs:theirs]"",""[heroThey:she][heroThem:her][heroTheir:her][heroTheirs:hers]"",""[heroThey:he][heroThem:him][heroTheir:his][heroTheirs:his]""],
        ""setSchool"":[""[school:Abjuration][specialty:protection, enhancement, planes][schoolPronoun:abjuror]"",
        ""[school:Conjuration][specialty:elementals, summoning, teleportation][schoolPronoun:conjurer, summoner, planeswalker]"",
        ""[school:Divination][specialty:analysis, communion][schoolPronoun:diviner, seer, soothsayer]"",
        ""[school:Enchantment][specialty:preservation, coercion-magic, artifice][schoolPronoun:artificer, enchanter, spellbinder]"",
        ""[school:Evocation][specialty:medicine, sculpting, metamagic][schoolPronoun:healer, elementalist, evoker]"",
        ""[school:Illusion][specialty:projection][schoolPronoun:illusionist, magician]"",
        ""[school:Necromancy][specialty:reanimation, Myconids, corpse-magic][schoolPronoun:necromancer, reanimator, occultist]"",
        ""[school:Transmutation][specialty:communication, bodily-adaption, dunamancy, alchemy][schoolPronoun:alchemist, transmuter]""],

        ""sequence"":[""#arcanist.capitalise# was a powerful #school# specialising in #school#. #heroThey# went for a walk to see the head of #school# where #heroTheir# results were being released.""], 
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
        //Debug.Log("Reading!");
        UI_Panel.GetComponentInChildren<TextMeshProUGUI>().text = text;
        player.reading = true;
    }

    // On awake, use tracery to generate a text string.
    public void Awake()
    {
        Arcanist testa = new Arcanist(1, grammar);
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownController>();
        //grammar.PushAction("[arcanist:#name#]", testa.they, testa.them, testa.their, testa.theirs);
        text = string.Format("#[arcanist:{0}][heroThey:{1}][heroThem:{2}][heroTheir:{3}][heroTheirs:{4}][school:{5}][specialty:{6}][schoolPronoun:{7}]sequence#", testa.name, testa.they, testa.them, testa.their, testa.theirs, testa.school, testa.specialty, testa.schoolPronoun);
        Debug.Log(grammar.Parse(text));

        Debug.Log(testa.name);
        Debug.Log(testa.they);
        Debug.Log(testa.them);
        Debug.Log(testa.their);
        Debug.Log(testa.theirs);
        Debug.Log(testa.school);
        Debug.Log(testa.specialty);
        Debug.Log(testa.schoolPronoun);
    }

    public void FixedUpdate()
    {
        UI_Panel.SetActive(reading);
        reading = false;
    }
}
