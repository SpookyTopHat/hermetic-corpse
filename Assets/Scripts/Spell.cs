using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{

    public abstract void SpellEffect(GameObject effected);

    public abstract void ClearEffect(GameObject effected);

    async void DoSpell(GameObject effected,GameObject Player, float SpellTime){
        SpellEffect(effected);
        await new WaitForSeconds(SpellTime);
        ClearEffect(effected);
        SpellEffect(Player);
        await new WaitForSeconds(SpellTime);
        ClearEffect(effected);
    }


}
