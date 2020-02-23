using System;

namespace Cards
{
	class Hand                                                          /*implements a hand of cards(that is, all cards dealt to one player).*/
	{
        public const int HandSize = 13;
        private PlayingCard[] cards = new PlayingCard[HandSize];
        private int playingCardCount = 0;

		public void AddCardToHand(PlayingCard cardDealt)                /*The purpose of this method is to add the playing card specifi ed as the parameter to the hand. */
		{
            if (this.playingCardCount >= HandSize)                      /*Used by your code to keep track of how many cards the hand currently contains as it is being populated.*/
		{
                throw new ArgumentException("Too many cards");          /*This code fi rst checks to ensure that the hand is not already full. If the hand is full, it throws an 
																		ArgumentException exception (this should never occur, but it is good practice to be safe). Otherwise, the 
																		card is added to the cards array at the index specifi ed by the playingCardCount variable, and this variable 
																		is then incremented. */
            }
            this.cards[this.playingCardCount] = cardDealt;
            this.playingCardCount++;
		}

		public override string ToString()                               /*The ToString method generates a string representation of the cards in the hand. 
																		It uses a foreach loop to iterate through the items in the cards array and calls the 
																		ToString method on each PlayingCard object it fi nds. These strings are concatenated 
																		with a newline character in between (using the Environment.NewLine constant to specify 
																		the newline character) for formatting purposes. */
				{
			string result = "";
			foreach (PlayingCard card in this.cards)
			{
				result += $"{card.ToString()}\n";
			}

			return result;
		}
	}
}