namespace Cards
{
	class PlayingCard
	{
        private readonly Suit suit;                             // Read Only Fields that you do not want changed
        private readonly Value value;                            // Read Only Fields that you do not want changed

        public PlayingCard(Suit s, Value v)
		{
			this.suit = s;                                      // Once the readonly field is called in the constructor it can't be changed
			this.value = v;                                     // Once the readonly field is called in the constructor it can't be changed
        }

        public override string ToString()
		{
            string result = $"{this.value} of {this.suit}";
            return result;
		}

        public Suit CardSuit()
        {
            return this.suit;
        }

        public Value CardValue()
        {
            return this.value;
        }
	}
}