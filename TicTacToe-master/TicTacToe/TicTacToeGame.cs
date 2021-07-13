﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public int[,] board = new int[Ct.BoardSize, Ct.BoardSize];
        int currentPlayer;
        string player1, player2;

        public List<GameResult> gameResults = new List<GameResult>();

        public void Start(string p1, string p2)
        {
            player1 = p1;
            player2 = p2;
            InitBoard();
            currentPlayer = Ct.FirstPlayer;
        }

        public string GetPlayerText(int player)
        {
            if (player == Ct.FirstPlayer) return Ct.FirstPlayerText;
            if (player == Ct.SecondPlayer) return Ct.SecondPlayerText;
            return Ct.FreeCellText;
        }

        internal void LoadResults(string fileName)
        {
             string serialisedResults = File.ReadAllText(fileName);      
            gameResults = JsonConvert.DeserializeObject <List<GameResult>>(serialisedResults);

        }

        public int Play(int x, int y)
        {
            Move(x, y);
            //           ConsoleShow();
            return GetWinner(x, y);
        }

        public bool WeHaveAWinner(int x, int y)
        {

            if (board[x, 0] == board[x, 1] && board[x, 1] == board[x, 2]) return true;
            if (board[0, y] == board[1, y] && board[1, y] == board[2, y]) return true;

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != Ct.FreeCell)
                return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != Ct.FreeCell)
                return true;

            return false;
        }
        private int GetWinner(int x, int y)
        {
            if (WeHaveAWinner(x, y))
            {
                return currentPlayer;
            }
            return Ct.NoWinner;
        }

        public void Move(int x, int y)
        {
            if (board[x, y] == Ct.FreeCell)
            {
                board[x, y] = currentPlayer;
                if (!WeHaveAWinner(x, y))
                {
                    TogglePlayer();
                }

            }
        }

        private void TogglePlayer()
        {
            currentPlayer = (currentPlayer == Ct.FirstPlayer) ? Ct.SecondPlayer : Ct.FirstPlayer;
        }

        internal void SaveGame()
        {
            
            gameResults.Add(
                new GameResult
                {
                    Player1 = player1,
                    Player2 = player2,
                    Result = currentPlayer
                }    
            );
        }

        internal string GetWinnerName()
        {
            return GetPlayerName(currentPlayer);
        }

        private string GetPlayerName(int currentPlayer)
        {
            if (currentPlayer == 1) return player1;
            if (currentPlayer == 2) return player2;
            return "No Winner";
        }

        internal bool FullBoard()
        {
            for (int i = 0; i < Ct.BoardSize; i++)
            {
                for (int j = 0; j < Ct.BoardSize; j++)
                {
                    if (board[i, j] == 0) return false;
                }
            }
            return true;
        }

        internal void SaveDrawGame()
        {
            gameResults.Add(
             new GameResult
             {
                 Player1 = player1,
                 Player2 = player2,
                 Result = Ct.NoWinner
             }
         );
        }

        private void InitBoard()
        {
            for (int i = 0; i < Ct.BoardSize; i++)
            {
                for (int j = 0; j < Ct.BoardSize; j++)
                {
                    board[i, j] = Ct.FreeCell;
                }
            }
        }

        internal void Reset()
        {
            throw new NotImplementedException();
        }

        internal void SaveResults(string fileName)
        {
            string serialisedResults = JsonConvert.SerializeObject(gameResults);
            File.WriteAllText(fileName,serialisedResults);
        }
    }
}

