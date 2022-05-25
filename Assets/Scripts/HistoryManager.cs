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
        ""Fayra1"":[""Born in 1307, Fayra was an unwanted child, given up for adoption soon into her life. Found wandering the ceaseless bookshelves of the Oraculum as a young child, she was taken in by an Oraculum archmage""],
        ""Fayra2"":[""In 1329, Fayra joined an adventuring party as a part-timer to root out corruption within the City. After having a close call with death after a myconid haymaker, she vowed never to be that close to death again and resigned to her studies.""],
        ""Fayra3"":[""In 1334, Fayra stumbled upon a cryptic leathery tome, adorned with a serpentine tongue. This tome albeit garish was occult and at midnight, would cover its bare pages in strange messages written in blood. The entity and Fayra formed a close bond, assisting on her desire for immortality.""],
        ""Fayra4"":[""In 1365, Fayra was wisened, older, and had committed an unthinkable number of heinous deeds for the entity. Her practices were 'cruel' or 'barbaric' in the eyes of those who could not see the truth. Fayra was expelled from the Oraculum for her actions, but some say she still roams the world to this day.""],
        
        ""Thonk1"":[""Born in 1309, Thonk was a young happy chap. He wasn't adventurous and never left his home village. He fell in love with a girl called Meve, who he was due to marry. Unfortunately however she developed a strange curse breaking apart her mind.  Thonk decided to leave his village and travel to find a cure for this curse. He joined the Oraculum hoping they would have an answer.""],
        ""Thonk2"":[""In 1336, Thonk was recruited by a necromancer, who was a fellow member of the Oraculum. This master promised much, including an understanding of the mind which he would teach Thonk. But the fates had other ideas. His master was killed by a mercenary. This mercenary was then killed in turn by an adventuring group, who Thonk then joined.""],
        ""Thonk3"":[""By 1337, Thonk had grown in much power. Adventuring gave him many opportunities to learn about lots of different forms of magic. Though he obsessed over mind magic the most. With this though came small parts of insanity as the stresses of adventuring took their toll. One day Thonk messed up while on an adventure, hurting his friends and fellow adventures in the process. He tried to fix the situation by altering their memories with his new power. He was unsuccessful and expelled from the party for doing such an awful thing.""],
        ""Thonk4"":[""In 1380, word of his mind altering antics reached the Oraculum and he was expelled. Thonk however did not care, he only cared about his friends and Meve. Not long after the incident he decided to go on a journey of repentance in hope to make up with his friends. On this journey he does dream that he will, in his wanderings, find a cure for his beloved Meve. He is yet to do so.""],

        ""Felix1"":[""Born in 1307, Felix was not a happy man. Already a gambler by his teenage years, soon he took to other vices, eventually falling into such a pit of personal problems that he swindled his own family to further his distractions from life. This would not end well, and landed him in the debt of a cosmic entity known as the Red Wyrm.""],
        ""Felix2"":[""Eventually, this debt became overbearing. Despite accruing many strange powers from the Wyrm, designed to aid in paying back this debt, Felix needed help, and in 1334 turned to the Oraculum to become a subject of study, acting as an assistant to many of the Archmages where he could.""],
        ""Felix3"":[""Year 1336: Felix was held in the lower dungeons of the Oraculum for attempts to sell access to restricted books to students whilst collecting coin from book returnals as 'late fees'. A full evaluation of his usefulness to the Oraculum will be conducted to decide whether or not he is worth the administrative troubles of keeping him on site.""],
        ""Felix4"":[""Year 1402: After the corridor providing access to his cell was lost, Felix was assumed to have been consumed by the building in early 1337. However, recently students embarking on a study of the Oraculums lower bowels have encountered a broken window to the outside on the same level as the cell. Hemomancers concluded that the blood contained sufficient divine energy to conclude that it belongs to Felix. His whereabouts and condition remain unknown.""],

        ""Ciffy1"":[""In late 1354, a group of holy folk from Averia arrived at the Oraculum. They were carrying a child which they believed to have been blessed by their God, however had little actual experience in the raising of a child with actual provable divine ability. Provided that study and recording of the child could be done in tandem, the Oraculum agreed to aid the villagers in ensuring the child was brought up safely.""],
        ""Ciffy2"":[""Year 1369: The child is able to demonstrate considerable abilities, such that their use to the Oraculum has become a major priority. Tensions are rising between the Averian contacts and the archivists assigned to Ciffy, to the point where she herself has become irritated with the Averians for inconveniencing her learning of both divine and arcane ways.""],
        ""Ciffy3"":[""Year 1377: With aid from Archmage Dolus, the child has begun the process of cutting off her ancestral home, to the extent where measures were taken to fake her death should the Averians prove too zealous in their beliefs. ""],
        ""Ciffy4"":[""Year 1391: After hearing of the Averian massacre by an unknown vampiric incursion, Ciffy became bent on leaving the Oraculum to retake her homeland. The Oraculum at large were upset by this, but ultimately allowed her to leave - although a group of students will have to be given resources to track and observe her in the coming years in order to finish their paper on the effects of combining arcane and divine energy within single individuals.""],

        ""Vince1"":[""Year 1009: a 22 year old student named Vince arrived at the Oraculum, claiming to be a student of a sister college that wished to transfer - as 'this building has more resources for my area of study'. Naturally this was met with heavy skepticism, as there is no known 'sister college' in any of the Oraculums archives. But after Divination specialists examined the individual they found all the student claimed to be true. This was deemed strange enough to warrant accepting the boy into the Oraculum on the notion that he be heavily observed.""],
        ""Vince2"":[""Year 1093: After a relatively uneventful time at the Oraculum, Vince left to pursue his own goals - many of which were deemed deeply unethical by the current leading Necromancers. It is expected many of these works will end with his death, but an obseration team will be assembled in case any of his experimentations prove... fruitful.""],
        ""Vince3"":[""It has been over 100 years since Vince was last considered by the Oraculum. Shortly after his leaving, a single half-elven skull was found at the door of one of the Divination Archmages. It was later determined by forensics to be the skull of one of the observation team dispatched to keep an eye on Vince. No reports were ever recieved from said team, nor any updates on their whereabouts. A day after the skull had been identified, many members of the Divination school began to suffer from intense headaches, and since then have been unable to locate Vince or divine any mention of him in both astral and material spaces.""],
        ""Vince4"":[""Year 1264: A figure known as 'Vincent' has been identified as entering into a previously abandoned dungeon several miles due west of Averia, near the northern coast of the Mainland. It has been hypothesised by multiple senior members of staff that this figure could be the missing Vince, particularly as a plague of headaches have returned to those with divination capability. An eye will be kept on the figure for the time being, although so long as no harm comes to the Oraculum, it may be safer to leave them alone.""],

        ""setArchivist"":[
            ""[name:Fayra][event1:#Fayra1#][event2:#Fayra2#][event3:#Fayra3#][event4:#Fayra4#]"",
            ""[name:Thonk][event1:#Thonk1#][event2:#Thonk2#][event3:#Thonk3#][event4:#Thonk4#]"",
            ""[name:Ciffy][event1:#Ciffy1#][event2:#Ciffy2#][event3:#Ciffy3#][event4:#Ciffy4#]"",
            ""[name:Felix][event1:#Felix1#][event2:#Felix2#][event3:#Felix3#][event4:#Felix4#]"",
            ""[name:Vince][event1:#Vince1#][event2:#Vince2#][event3:#Vince3#][event4:#Vince4#]""
        ],
        ""sequence"":[""#event1#""],
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
    public GameObject page;

    private bool pcg;
    public int numWizards;
    public List<string> names;
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
            names.Add(wizard.name);
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
                else if (i != j)
                {
                    Debug.Log(wizards[i].name + " is equal to " + wizards[j].name);
                    wizards.Remove(wizards[j]);
                    names.Remove(names[j]);
                    j--;
                    duplicates++;

                    // Names+ids for debugging, since the Arcanist class cannot fit on the Unity Editor.
                    
                    //ids.Remove(ids[j]);
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
        for(int x = 0; x < 5; x++)
        {
            pcg = Random.Range(0, 2) != 0;
        }

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
        
        foreach (Arcanist a in wizards)
        {
            Debug.Log(a.name);
        }

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
