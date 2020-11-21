using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{

    //Need to implement this for the spells, What is being done to the enemies and player.
    public abstract void SpellEffect(GameObject effected);

    //Undos the Spell effect.
    public abstract void ClearEffect(GameObject effected);

    public async void DoSpell(GameObject effected,GameObject Player, float SpellTime){
        SpellEffect(effected);
        //VSCode is claming this is an error, it isn't VSCode is confused.
        await new WaitForSeconds(SpellTime);
        ClearEffect(effected);
        SpellEffect(Player);

        //Claims this is an error also.
        await new WaitForSeconds(SpellTime);
        ClearEffect(effected);
    }


}
