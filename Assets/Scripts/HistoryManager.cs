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

    static string handcraftString = @"
    {
        ""sequence"":[""test does this work haha""],
        ""origin"":[""#sequence#""]

    }";
    static string eventString = @"
    {
        ""name"":[""Fayra"", ""Ethan"", ""Davey"", ""Steve"", ""Domos"", ""Dolus"", ""Gloin"", ""Thonk"", ""Klive"", ""Berta"", ""Susan"", ""Ricky"", ""Zerko"", ""Allur"", ""Ashad"", ""Tyrio""],
        ""alternateName"":[""Fayra"", ""Ethan"", ""Davey"", ""Steve"", ""Domos"", ""Dolus"", ""Gloin"", ""Thonk"", ""Klive"", ""Berta"", ""Susan"", ""Ricky"", ""Zerko"", ""Allur"", ""Ashad"", ""Tyrio"", ""Rickets"", ""Bartholemew"", ""Gareth"", ""Harrison"", ""Kacper"", ""Jasmine"", ""Rukshana"", ""Garibaldi"", ""Seven"", ""Selina"", ""Seraphine""],
        ""aCult"":[""Eighth Dynamic"", ""Fusiliers"", ""Satanic Panic"", ""Belieber"", ""Ivory Hollow""],
        ""anArtifact"":[""the Black Cube"", ""the Yellow Rhombus"", ""the Ebony Blade"", ""the Loom"", ""the Chair of #aDeity#"", ""the Lantern of the #aCult#""],
        ""position"":[""Archivist"", ""Librarian"", ""Lorekeeper"", ""Thaumaturgist"", ""Scholar"", ""Valedictorian""],
        
        ""worldState"":[""hostile"", ""verdant"", ""unforgiving"", ""rewarding"", ""encouraging"", ""luscious"", ""inspiring""],
        ""ended"":[""poorly"", ""miserably"", ""fantastically"", ""well"", ""great"", ""uninterestingly"", ""anticlimactically"", ""climactically"", ""abysmally""],
        ""aTarget"":[""body"", ""mind"", ""self"", ""soul"", ""being""],
        ""aMeans"":[""magus"", ""medeis"", ""veneficium"", ""praecantatio"", ""devotio""],
        ""aDeity"":[""Ioun"", ""Pelor"", ""Asmodeus"", ""Mephistopheles"", ""Vecna"", ""Odin"", ""Hinch""],
        ""aMethod"":[""#aMeans#"", ""#aDeity#""],

        ""direction"":[North, South, East, West],
        
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
            ""#archivist.capitalise# was born in a #worldState# land. In the span of only a year, #heroThey# had become a powerful practicioner of #school#, and went on to work at the Oraculum."",
            ""In a strange, #worldState# dimension, the powerful #school#-master #alternateName# gave birth to a child, named #archivist.capitalise#. Things ended #ended#, and the Oraculum took #heroThem# in, furthering #heroTheir# powers of #school#.""
            ""It is unclear where #archivist.capitalise# came from, though #heroThey# were vouched for by #name# when #heroThey# were just #age#, and #heroTheir# ability intrigued the other students of #school#."",
            ""An orphan taken in by followers of #aDeity#, #archivist.capitalise# was a staunch believer in #heroTheir# god. Such that when the #anArtifact# came to #heroThem#,  #heroThey# joined the Oraculum to plunder its secrets.""
        ],

        ""sequence"":[
            ""#archivist# practiced #school#, specialising in #specialty#. #heroThey# went for a walk to see the head of #school# where #heroTheir# results were being released."",
            ""The powerful student of #school#, #archivist#, was commended for advances in the field. They were assigned the role of #position# as thanks."",
            ""#archivist# the #position# discovered an ancient spell - #heroThey# named it the '#aVia# #aMethod#' and dedicated it to the god #aDeity#"",
            ""An artifact named the #anArtifact# was recovered by #archivist#, it contained a key to unlocking the secrets of the #aTarget#"",
            ""The cult of #aDeity# known only as the #aCult# was founded by #archivist# at the age of #age#"",
            ""Archivist #archivist# gained the title of Chief #position# after aiding #alternateName# and #alternateName# in the banishing of #aDeity# from the mortal plane."",
            ""A new wing of the Oraculum was opened by #archivist.capitalise# the #position#, dedicated to studying the arcane tome '#aVia# #aPlace#'"",
            ""After laying siege to a church of #aDeity# several miles to the #direction#, #archivist.capitalise# returned to the Oraculum with the #anArtifact#."" 
        ],

        ""deathSequence"":[
            ""#archivist.capitalise# is still with us, though records of #heroTheir# location and current goals are unknown. It is said they came across the #anArtifact#, and have gone into hiding to study its secrets."",
            ""After being the head #position# for a number of years, #archivist.capitalise# sadly passed away during a #school# experiment that went frightfully wrong. Many Divination majors can still hear #heroTheir# cries echoing through the halls of the Library."",
            ""In a move that surprised noone, #archivist.capitalise# left the Oraculum and was promptly recruited by the #aCult#, and has likely been sacrificed."",
            ""At the age of only #age#, #archivist.capitalise# suffered from a horrid disease, and died despite the efforts of #alternateName# and #alternateName#.""
            ""The few windows the Oraculum has are often considered dangerous. #archivist.capitalise# forgot this."",
            ""Archivist #archivist.capitalise# fell through the floor of the #school# section, and was lost in the void beneath. It was concluded that a breakout of damp had occured in the wooden flooring, weakening the boards beneath #heroTheir# feet. #heroThey# will be missed."",
            ""#archivist.capitalise# got into a fight with [opponent:#name#]#opponent# over the nature of #school# magic. As such, they were expelled from the Oraculum, since #opponent# is considered the leading authority.""
        ],
        

        ""origin"":[""#setPronouns# #setSchool#[archivist:#name#] #sequence#""]
    }";

    TraceryGrammar grammar;
    public bool pcg;
    public GameObject page;

    public int numWizards;
    //public List<string> names;
    //public List<int> ids; 
    public List<Arcanist> wizards;
    public List<Vector3> positions;
    public List<string> allEvents;
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

    public void GenerateWizards(List<Arcanist> wizards, int n)
    {
        for (int i = 0; i < n; i++)
        {
            // Magic number above is the number of archivists - this needs to be switched to a variable at some point.
            // Create a new Archivist, add them to the list and upload their life story to the allevents list.

            Arcanist wizard = new Arcanist(wizards.Count, grammar, 4, pcg);
            wizards.Add(wizard);

            // Names+ids for debugging, since the Arcanist class cannot fit on the Unity Editor.
            //names.Add(wizard.name);
            //ids.Add(wizard.id);
        }
    }

    public void CheckDuplicates(List<Arcanist> wizards)
    {
        int duplicates = 0; 
        for(int i = 0; i < wizards.Count; i++)
        {
            // Check every archivist against EVERY OTHER archivist. 
            for (int j = 0; j < wizards.Count; j++)
            {
                // If their names don't match, then move on to save time. 
                if (wizards[i].name != wizards[j].name)
                {
                    continue;
                }
                // If their ids don't match, then it's a duplicate - delete it. 
                else if (wizards[i].id != wizards[j].id)
                {
                    Debug.Log(wizards[i].name + " is equal to " + wizards[j].name);
                    wizards.RemoveAt(j);
                    duplicates++;

                    // Names+ids for debugging, since the Arcanist class cannot fit on the Unity Editor.
                    //names.RemoveAt(j);
                    //ids.RemoveAt(j);
                }
            }
        }

        if(duplicates != 0)
        {
            Debug.Log(duplicates + " more duplicates to go!");
            GenerateWizards(wizards, duplicates);
            CheckDuplicates(wizards);
        }
    }

    public void Awake()
    {
        if (pcg)
        {
            grammar = new TraceryGrammar(eventString);
        }
        else
        {
            grammar = new TraceryGrammar(handcraftString);
        }

        wizards = new List<Arcanist>();

        // STEP ONE - CREATE THE ARCHIVISTS (YES THE NAME KEEPS CHANGING)
        GenerateWizards(wizards, numWizards);
        // 1.5: Check for duplicates - this function recursively checks for any duplicated names,
        // running the GenerateWizards function for any it finds until it creates a list of unique Archivists.
        CheckDuplicates(wizards);
        
        // STEP TWO - COLLATE ALL EVENTS FROM ALL ARCHIVISTS INTO ONE LIST
        foreach(Arcanist a in wizards)
        {
            a.PullHistory(allEvents);
        }

        // STEP THREE - SHUFFLE THE ALLEVENTS LIST
        Shuffle(allEvents);

        // STEP FOUR - CREATE AND DISTRIBUTE HISTORICAL DOCUMENTS
        foreach(string e in allEvents)
        {
            // 4.1: Create a new instance of the page prefab.
            Instantiate(page, GameObject.Find("Pages").transform);
            
            // 4.2: Pick a random point from the list of appropriate positions,
            // place the page at the chosen position, then remove that position
            // from the list. 
            int randomIndex = Random.Range(0, positions.Count);
            page.transform.position = positions[randomIndex];
            positions.RemoveAt(randomIndex);
            
            // 4.3: Set the text of the page to the current event.
            page.GetComponent<TextSwitch>().text = e;
        }
    }
}
