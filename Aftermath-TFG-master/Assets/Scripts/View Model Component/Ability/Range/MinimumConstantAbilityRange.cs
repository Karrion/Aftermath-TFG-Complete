using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MinimumConstantAbilityRange : AbilityRange
{
    public int minimum = 1;

    public override List<Tile> GetTilesInRange(Board board)
    {
        List<Tile> outer = board.Search(unit.tile, ExpandSearch);
        List<Tile> inner = board.Search(unit.tile, InnerSearch);
        return difference(outer, inner);
    }

    bool ExpandSearch(Tile from, Tile to)
    {
        return (from.distance + 1) <= horizontal && Mathf.Abs(to.height - unit.tile.height) <= vertical;
    }

    bool InnerSearch(Tile from, Tile to)
    {
        return (from.distance + 1) <= minimum && Mathf.Abs(to.height - unit.tile.height) <= vertical;
    }

    List<Tile> difference(List<Tile> minuend, List<Tile> substrahend)
    {
        return minuend.Except(substrahend).ToList();
    }
}