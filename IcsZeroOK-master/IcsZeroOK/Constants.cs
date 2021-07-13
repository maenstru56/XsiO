using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcsZeroOK
{
    static class Constants
    {
        public static  int firstPlayer = 1;
        public static  string firstPlayerText = "X(";
        public static  int secondPlayer = 2;
        public static  string secondPlayerText = ":)";
        public static  string firstPlayerName = "Toni";
        public static  string secondPlayerName = "Popescu";
        public static  int boardSize = 3;
        public static Color boardColor = Color.Lime;
        public static Color hoverColor = Color.White;

        public static int CellSize = 100;

        public static int CellPadding = 5;

        public static int LeftBoardPosition = 20;
        public static int TopBoardPosition = 20;
    }
}
