﻿using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei_View.Views;
using Shin_Megami_Tensei_View.Views.ConsoleView.OptionMenu;

namespace Shin_Megami_Tensei.Fighters.Actions;

public class SummonablePositionsController: IViewController
{
    private GameState _gameState;
    private int _position = -1;

    public SummonablePositionsController(Table table)
    {
        _gameState = table.GetGameState();
    }

    public int GetPositionFromUser()
    {
        var positions = GetPositions();
        SummonPositionsMenu summonPositionsMenu = new SummonPositionsMenu(positions);
        summonPositionsMenu.SetInput(this);
        summonPositionsMenu.Display();
        return _position;
    }
    
    private IEnumerable<IFighterModel> GetPositions()
    {
        var frontRow = _gameState.CurrentPlayerState.TeamState.FrontRow;
        var swapablePositions = frontRow.Where(fighter => fighter.GetState().CanBeSwapped);
        return swapablePositions;
    }


    public void OnInput(string input)
    {
        _position =  int.Parse(input);
    }
}