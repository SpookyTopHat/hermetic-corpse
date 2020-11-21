using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : Spell
{
    // Start is called before the first frame update
    void Start()
    {
        DoSpell(gameObject,gameObject,1);
    }

    public override void SpellEffect(GameObject effected){
        Debug.Log("Effecting");
    }

    public override void ClearEffect(GameObject effected){
        Debug.Log("Clearing");
    }
}
