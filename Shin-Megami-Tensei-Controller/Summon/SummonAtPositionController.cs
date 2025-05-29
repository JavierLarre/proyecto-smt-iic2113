using Shin_Megami_Tensei_Model;
using Shin_Megami_Tensei.Fighters.Actions;

namespace Shin_Megami_Tensei;

public class SummonAtPositionController
{
    private SummonablePositionsController _positions;
    private SummonController _controller;

    public SummonAtPositionController(Table table)
    {
        _positions = new SummonablePositionsController(table);
        _controller = new SummonController(table);
    }

    public void Summon()
    {
        int choosenPosition = _positions.GetPositionFromUser();
        _controller.SummonAt(choosenPosition);
    }
}