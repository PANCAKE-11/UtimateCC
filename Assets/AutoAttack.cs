using UnityEngine;
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities;
using Opsive.UltimateCharacterController.Character.Abilities.Items;
using System.Collections;
using Opsive.UltimateCharacterController.Camera;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] AimAssist aimAssist;
    bool aimed;
    /// <summary>
    /// Starts and stops the jump ability.
    /// </summary>
    IEnumerator Start()
    {
        
        aimed=false;



        while (true)
        {
        var characterLocomotion = gameObject.GetComponent<UltimateCharacterLocomotion>();
        var UseAbility = characterLocomotion.GetAbility<Use>();
        var AimAbility = characterLocomotion.GetAbility<Aim>();

        
        if(aimAssist.HasTarget())
        {
            // if(!aimed)
            // {
            //  characterLocomotion.TryStartAbility(AimAbility);
            //  aimed=true;
            // }
            characterLocomotion.TryStartAbility(UseAbility);
        yield return new WaitForSeconds(0.5f);
        if(UseAbility.IsActive)
        {
            characterLocomotion.TryStopAbility(UseAbility);
        }
        yield return new WaitForSeconds(0.5f);
        }else
        {
            //  characterLocomotion.TryStopAbility(AimAbility);
            // aimed=false;
            yield return null;
        }
                
        }

       
    }

    

}
