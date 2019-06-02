﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFolder : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.PaperFolder;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return TypesOfReaction.None;

        TypesOfReaction reaction = TypesOfReaction.None;
        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == PersonalityTrait.Otaku)
        {
            affectee.IncreaseProductivityBy(10f);
            reaction = TypesOfReaction.HeartfulFigures;
            Debug.LogError(gameObject.name + " relaxed " + affectee.gameObject.name + " with the paper figurines");
        }
        return reaction;
    }

    public override TypesOfReaction BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        return TypesOfReaction.None;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckFront(theirPosition) || CheckSides(theirPosition);
    }
}
