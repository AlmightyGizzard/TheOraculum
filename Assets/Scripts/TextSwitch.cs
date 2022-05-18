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
        ""name"":[""Fayra"", ""Dave"", ""Stephen"", ""Domo"", ""Dolus"", ""Barnaby"", ""Keleven"", ""Cklive"", ""Bartholemew"", ""Susan"", ""Rickets"", ""Zachary"", ""Allura"", ""Ashton""],
        ""age"":[""1"", ""5"", ""10"", ""15"", ""22"", ""34"", ""46"", ""78"", ""124"", ""72"", ""61"", ""420"", ""120""],
        ""aCult"":[""Eighth Dynamic"", ""Fusiliers"", ""Satanic Panic"", ""Belieber"", ""Ivory Hollow""],
        ""anArtifact"":[""the Black Cube"", ""the Yellow Rhombus"", ""the Ebony Blade"", ""the Loom"", ""the Chair of #aDeity#"", ""the Lantern of the #aCult#""],
        ""position"":[""Archivist"", ""Librarian"", ""Lorekeeper"", ""Thaumaturgist"", ""Scholar"", ""Valedictorian""],
        ""aTarget"":[""body"", ""mind"", ""self"", ""soul"", ""being""],
        ""aMeans"":[""magus"", ""medeis"", ""veneficium"", ""praecantatio"", ""devotio""],
        ""aDeity"":[""Ioun"", ""Pelor"", ""Asmodeus"", ""Mephistopheles"", ""Vecna"", ""Odin"", ""Hinch""],
        ""aMethod"":[""#aMeans#"", ""#aDeity#""],
        ""aGoal"":[""subterlabor"", ""evolo"", ""fugio"", ""profugio"", ""defugio"", ""excido"", ""ecfugio"", ""impertus"", ""relinquo"", ""transulto""],
        ""aPlace"":[""domus"", ""nidus"", ""penates"", ""asa"", ""libertas"", ""vacatio"", ""elutheria"", ""aevi"", ""discede"", ""procul""],
        ""aTo"":[""usque"", ""usquead"", ""indu"", ""erga"", ""contra"", ""versum"", ""directio"", ""vorsum"", ""propius"", ""homius""],
        ""aVia"":[""via"", ""limes"", ""usura"", ""fructus"", ""usus"", ""usurpatio"", ""ec"", ""per"", ""gratia"", ""propter""],
        ""aGive"":[""tribuo"", ""indo"", ""sufficio"", ""subficio"", ""commodo"", ""affero"", ""porrigo"", ""praesto"", ""cedo"", ""fateor""],

        ""setPronouns"":[
            ""[heroThey:they][heroThem:them][heroTheir:their][heroTheirs:theirs]"",
            ""[heroThey:she][heroThem:her][heroTheir:her][heroTheirs:hers]"",
            ""[heroThey:he][heroThem:him][heroTheir:his][heroTheirs:his]""
        ],
        
        ""setSchool"":[
            ""[school:Abjuration][specialty:protection, enhancement, planes][schoolPronoun:abjuror]"",
            ""[school:Conjuration][specialty:elementals, summoning, teleportation][schoolPronoun:conjurer, summoner, planeswalker]"",
            ""[school:Divination][specialty:analysis, communion][schoolPronoun:diviner, seer, soothsayer]"",
            ""[school:Enchantment][specialty:preservation, coercion-magic, artifice][schoolPronoun:artificer, enchanter, spellbinder]"",
            ""[school:Evocation][specialty:medicine, sculpting, metamagic][schoolPronoun:healer, elementalist, evoker]"",
            ""[school:Illusion][specialty:projection][schoolPronoun:illusionist, magician]"",
            ""[school:Necromancy][specialty:reanimation, Myconids, corpse-magic][schoolPronoun:necromancer, reanimator, occultist]"",
            ""[school:Transmutation][specialty:communication, bodily-adaption, dunamancy, alchemy][schoolPronoun:alchemist, transmuter]"",
        ],

        ""sequence"":[
            ""#archivist.capitalise# was a powerful #schoolPronoun# specialising in #specialty#. #heroThey# went for a walk to see the head of #school# where #heroTheir# results were being released."",
            ""The powerful #schoolPronoun# known as #archivist.capitalise# was preparing to take on the day."",
            ""#archivist# the #position# discovered an ancient spell - #heroThey# named it the #aVia# #aMethod# and dedicated it to the god #aDeity#"",
            ""An artifact named the #anArtifact# was recovered by #archivist#, it contained a key to unlocking the secrets of the #aTarget#"",
            ""The cult of #aDeity# known only as the #aCult# was founded by #archivist# at the age of #age#"",
            ""Archivist #archivist# gained the title of Chief #position# after aiding #name.capitalise# and #name.capitalise# in the banishing of #aDeity# from the mortal plane."",
            ""A new wing of the Oraculum was opened by #archivist# the #position#, dedicated to studying the arcane tome #aVia# #aPlace#""
        ], 
        

        ""origin"":[""#setPronouns# #setSchool#[archivist:#name#] #sequence#""]
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
        text = testa.events[0];
        //Debug.Log(grammar.Parse(text));

        Debug.Log(testa.schoolPronoun);
        Debug.Log(testa.school);
        Debug.Log(testa.specialty);
        

        for (int i = 0; i < testa.events.Count; i++)
        {
            Debug.Log(testa.events[i]);
        }

    }

    public void FixedUpdate()
    {
        UI_Panel.SetActive(reading);
        reading = false;
    }
}
