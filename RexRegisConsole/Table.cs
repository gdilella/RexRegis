using System;
using System.Collections.Generic;

namespace RexRegisConsole
{
	public class Table
	{
		List<Move> moveHistory;
		bool isTableClean;

        public Table()
        {
            moveHistory = new List<Move>();
            isTableClean = true;
        }

        public void AddMove(Move move)
        {
            moveHistory.Add(move);

            if (!move.Passed)
                isTableClean = false;
        }

		public List<Move> MoveHistory
		{
			get
			{
				return moveHistory;
			}
		}
		public bool IsTableClean
		{
			get
			{
				return isTableClean;
			}
		}

		public Move LastMove
		{
			get
			{
                return moveHistory.FindLast(x => x.Passed == false);
			}
		}

        public void CleanTable()
        {
            isTableClean = true;
        }
    }
}