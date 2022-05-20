using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityTracery;



public class HistoryManager : MonoBehaviour
{
    // TODO - ensure all names are of the same length - 5 letters perhaps?
    // Prevent duplicates
    // Connect an integer value to age and create a date tracking system
    // Event logic - we need a separate sequence section for the first event, and a for the last event. DONE
    static string eventString = @"
    {
        ""name"":[""Fayra"", ""Dave"", ""Stephen"", ""Domo"", ""Dolus"", ""Barnaby"", ""Keleven"", ""Cklive"", ""Bartholemew"", ""Susan"", ""Rickets"", ""Zachary"", ""Allura"", ""Ashton""],
        ""aCult"":[""Eighth Dynamic"", ""Fusiliers"", ""Satanic Panic"", ""Belieber"", ""Ivory Hollow""],
        ""anArtifact"":[""the Black Cube"", ""the Yellow Rhombus"", ""the Ebony Blade"", ""the Loom"", ""the Chair of #aDeity#"", ""the Lantern of the #aCult#""],
        ""position"":[""Archivist"", ""Librarian"", ""Lorekeeper"", ""Thaumaturgist"", ""Scholar"", ""Valedictorian""],
        
        ""worldState"":[""hostile"", ""verdant"", ""unforgiving"", ""rewarding"", ""encouraging"", ""luscious"", ""inspiring""],
        ""ended"":[""poorly"", ""miserably"", ""fantastically"", ""well"", ""great"", ""uninterestingly"", ""anticlimactically"", ""climactically"", ""abysmally""],
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

        ""birthSequence"":[
            ""#archivist.capitalise# was born in a #worldState# land. In the span of only a year, #heroThey# had become a powerful #schoolPronoun#, and went on to work at the Oraculum."",
            ""In a strange, #worldState# dimension, the powerful #schoolPronoun# #name# gave birth to a child, named #archivist.capitalise#. Things ended #ended#, and the Oraculum took #heroThem# in, furthering #heroTheir# powers of #school#.""
        ],

        ""sequence"":[
            ""#archivist.capitalise# was a powerful #schoolPronoun# specialising in #specialty#. #heroThey# went for a walk to see the head of #school# where #heroTheir# results were being released."",
            ""The powerful #schoolPronoun# known as #archivist.capitalise# was preparing to take on the day."",
            ""#archivist.capitalise# the #position# discovered an ancient spell - #heroThey# named it the '#aVia# #aMethod#' and dedicated it to the god #aDeity#"",
            ""An artifact named the #anArtifact# was recovered by #archivist#, it contained a key to unlocking the secrets of the #aTarget#"",
            ""The cult of #aDeity# known only as the #aCult# was founded by #archivist# at the age of #age#"",
            ""Archivist #archivist.capitalise# gained the title of Chief #position# after aiding #name.capitalise# and #name.capitalise# in the banishing of #aDeity# from the mortal plane."",
            ""A new wing of the Oraculum was opened by #archivist.capitalise# the #position#, dedicated to studying the arcane tome '#aVia# #aPlace#'""
        ],

        ""deathSequence"":[
            ""#archivist.capitalise# is still with us, though records of #heroTheir# location and current goals are unknown. It is said they came across the #anArtifact#, and have gone into hiding to study its secrets."",
            ""After being the head #position# for a number of years, #archivist.capitalise# sadly passed away during a #school# experiment that went frightfully wrong. Many Divination majors can still hear #heroTheir# cries echoing through the halls of the Library."",
            ""In a move that surprised noone, #archivist.capitalise# left the Oraculum and was promptly recruited by the #aCult#, and has likely been sacrificed.""
        ],
        

        ""origin"":[""#setPronouns# #setSchool#[archivist:#name#] #sequence#""]
    }";

    TraceryGrammar grammar = new TraceryGrammar(eventString);
    public GameObject page;

    [SerializeField]
    private List<Arcanist> wizards;
    //[SerializeField]
    public List<Vector3> positions;
    public List<string> allEvents;
    public List<TextSwitch> pages;
    public int currentYear;


    public void Shuffle(List<string> input)
    {
        // Fisher-Yates shuffle algorithm, effectively draws items at random  and assigns them positions,
        // removing both the items available to draw and available positions as it progresses. O(n) 
        string temp;
        int n = input.Count;
        for (int i = 0; i < n; i++)
        {
            int rPos = Random.Range(0, i);
            temp = input[rPos];
            input[rPos] = input[i];
            input[i] = temp;
        }
    }

    // On awake, use tracery to generate a text string.
    public void Awake()
    {
        wizards = new List<Arcanist>();
        for(int i = 0; i < 5; i++)
        {
            Arcanist wizard = new Arcanist(i, grammar, 4);
            wizards.Add(wizard);
            wizard.PullHistory(allEvents);

            // Keeping the debugLogs, but we dont want one for every archivist.
            //if(i == 0)
            //{
            //    //Debug.Log(wizard.schoolPronoun);
            //    //Debug.Log(wizard.school);
            //    //Debug.Log(wizard.specialty);
            //}
        }

        Shuffle(allEvents);


        Vector3 testPoint = new Vector3(-6f, 0f, 0f);
        foreach(string e in allEvents)
        {
            // Create a new instance of the page prefab.
            Instantiate(page, GameObject.Find("Pages").transform);
            
            // Pick a random point from the list of appropriate positions,
            // place the page at the chosen position, then remove that position
            // from the list. 
            int randomIndex = Random.Range(0, positions.Count);
            page.transform.position = positions[randomIndex];
            positions.RemoveAt(randomIndex);
            
            // Set the text of the page to the current event.
            page.GetComponent<TextSwitch>().text = e;
        }
        
        

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
