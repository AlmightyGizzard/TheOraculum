using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTracery;

public abstract class Person : MonoBehaviour
{
    int id; 
    public string name, they, them, their, theirs;
    public List<string> coreProperties;

    public Person(int id, TraceryGrammar tg){
        this.id = id;
        name = tg.ResolveSymbol("#name#");

        // For future Dom - the fact that pronouns are in a nested Tracery unit
        // screws up the assignment of each of the 4 variants. 
        // I THINK .PushAction can solve this by resolving setPronouns and assigning
        // the results of each to a different property, like a multiples version of
        // resolveSymbol. No docs on it though, so who knows.
        string[3] = tg.PushAction("#setPronouns#");
        they = tg.ResolveSymbol("#setPronouns#");    
        them = tg.ResolveSymbol("#heroThem#");
        their = tg.ResolveSymbol("#heroTheir#");
        theirs = tg.ResolveSymbol("#heroTheirs#");
        

    }
}

public class Arcanist : Person
{
    public string school, specialty, schoolPronoun;

    public Arcanist(int id, TraceryGrammar tg):base(id, tg)
    {
        school = tg.ResolveSymbol("#school#");
        specialty = tg.ResolveSymbol("#specialty#");
        schoolPronoun = tg.ResolveSymbol("#schoolPronoun#");
    }
}
