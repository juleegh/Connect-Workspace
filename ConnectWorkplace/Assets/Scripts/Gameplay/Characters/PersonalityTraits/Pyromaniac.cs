﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyromaniac : PersonalTrait
{
    private void Start()
    {
        traitType = TypeOfPersonality.Pyromaniac;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        TypesOfReaction reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return TypesOfReaction.None;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.PaperFolder)
        {
            affectee.ReduceProductivityBy(6f);
            reaction = TypesOfReaction.BurntOrigami;
            Debug.LogError(gameObject.name + " almost burned the figurines of " + affectee.gameObject.name);
        }
        else if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.Smoker)
        {
            affectee.IncreaseProductivityBy(3f);
            reaction = TypesOfReaction.LitCigarrette;
            Debug.LogError(gameObject.name + " lit the cigarretes of " + affectee.gameObject.name);
        }

        return reaction;
    }
    
    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
