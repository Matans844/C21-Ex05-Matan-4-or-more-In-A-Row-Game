﻿namespace Ex05.GameLogic
{
	public class GameSettings
	{
		public const string k_DefaultComputerPlayerName = "Computer";
		public const string k_DefaultHumanPlayer1Name = "Player 1";
		public const string k_DefaultHumanPlayer2Name = "Player 2";
		public const int k_MinimumBoardDimension = 4;
		public const int k_MaximumBoardDimension = 8;
		private string s_Player1Name = k_DefaultHumanPlayer1Name;
		private string s_Player2Name = k_DefaultHumanPlayer2Name;
		private int? s_RowsForGame;
		private int? s_ColumnsForGame;
		private eGameMode? s_GameMode;
		private bool s_ReadyForGame = false;

		public bool ReadyForGame
		{
			get => s_ReadyForGame;
			set => s_ReadyForGame = value;
		}

		public string Player1Name
		{
			get => s_Player1Name;
			set => s_Player1Name = value;
		}

		public string Player2Name
		{
			get => s_Player2Name;
			set => s_Player2Name = value;
		}

		public int? RowsForGame
		{
			get => s_RowsForGame;
			set
			{
				int integerToSet;

				if (value.HasValue)
				{
					integerToSet = (int)value;

					if (NumberOperations.ValueInRange(integerToSet, k_MinimumBoardDimension, k_MaximumBoardDimension))
					{
						this.s_RowsForGame = integerToSet;
					}
				}
			}
		}

		public int? ColumnsForGame
		{
			get => s_ColumnsForGame;
			set
			{
				int integerToSet;

				if (value.HasValue)
				{
					integerToSet = (int)value;

					if (NumberOperations.ValueInRange(integerToSet, k_MinimumBoardDimension, k_MaximumBoardDimension))
					{
						this.s_ColumnsForGame = integerToSet;
					}
				}
			}
		}

		public eGameMode? ModeForGame
		{
			get => s_GameMode;
			set
			{
				if (value.Equals(eGameMode.PlayerVsComputer))
				{
					this.Player2Name = k_DefaultComputerPlayerName;
				}

				this.s_GameMode = value;
			}
		}

		public GameSettings()
		{
		}

		public bool CanGameBegin()
		{
			if (allRequiredSettingsAreSet())
			{
				this.ReadyForGame = true;
			}

			return this.ReadyForGame;
		}

		private bool allRequiredSettingsAreSet()
		{
			bool allNullableValuesSet = this.RowsForGame.HasValue
										&& this.ColumnsForGame.HasValue
										&& this.ModeForGame.HasValue
										&& !string.IsNullOrEmpty(this.Player1Name)
										&& !string.IsNullOrEmpty(this.Player2Name);

			return allNullableValuesSet;
		}
	}
}
