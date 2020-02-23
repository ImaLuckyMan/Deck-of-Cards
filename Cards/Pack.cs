using System;

namespace Cards
{	
	class Pack
	{
        public const int NumSuits = 4;                                                  //These two fields specify the number of suits in a pack of cards 
        public const int CardsPerSuit = 13;                                             //The number of cards in each suit.
        private PlayingCard[,] cardPack;                                                //The private cardPack variable is a two-dimensional array of PlayingCard objects
        private Random randomCardSelector = new Random();                               /*The randomCardSelector variable is a random number generated based on the Random 
                                                                                        class. You will use the randomCardSelector variable to help shuffl e the cards 
                                                                                        before they are dealt to each hand. */

        public Pack()
        {
            this.cardPack = new PlayingCard[NumSuits, CardsPerSuit];                    //Instantiates the cardPack array with the appropriate values 
            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)                   /*populates the cardPack array with a full, sorted deck of cards. 
                                                                                        The outer for loop iterates through the list of values in the Suit enumeration, and the inner
                                                                                        loop iterates through the values each card can have in each suit. The inner loop creates a new
                                                                                        PlayingCard object of the specifi ed suit and value and adds it to the appropriate element in the
                                                                                        cardPack array.*/
            {
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    this.cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                }
            }
        }

        public PlayingCard DealCardFromPack()                                           /*Picks a random card from the pack, remove the card from the pack to prevent it from being selected 
                                                                                        again, and then pass it back as the return value from the method. This statement uses the Next method 
                                                                                        of the randomCardSelector random number generator object to return a random number corresponding to a suit. 
                                                                                        The parameter to the Next method specifi es the exclusive upper bound of the range to use; the value 
                                                                                        selected is between 0 and this value minus 1. Note that the value returned is an int, so it has to be 
                                                                                        cast before you can assign it a Suit variable. There is always the possibility that no cards of the selected 
                                                                                        suit are left. You need to handle this situation and pick another suit if necessary.*/
        {
            Suit suit = (Suit)randomCardSelector.Next(NumSuits);
            while (this.IsSuitEmpty(suit))                                              /*This loop calls the IsSuitEmpty method to determine whether any cards of the specifi ed suit are
                                                                                        left in the pack (you will implement the logic for this method shortly). If not, it picks another suit at 
                                                                                        random (it might actually pick the same suit again) and checks again. The loop repeats the process until it 
                                                                                        finds a suit with at least one card left. */
            {
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }
                                                                                        /*You have now selected at random a suit with at least one card left. The next task is to pick a card
                                                                                        at random in this suit. You can use the random number generator to select a card value, but as before, there 
                                                                                        is no guarantee that the card with the chosen value has not already been dealt. However, you can use the same 
                                                                                        idiom as before: call the IsCardAlreadyDealt method (which you will examine and complete later) to determine 
                                                                                        whether the card has already been dealt, and if so, pick another card at random and try again, repeating 
                                                                                        the process until a card is found. */
            Value value = (Value)randomCardSelector.Next(CardsPerSuit);
            while (this.IsCardAlreadyDealt(suit, value))
            {
                value = (Value)randomCardSelector.Next(CardsPerSuit);
            }

            PlayingCard card = this.cardPack[(int)suit, (int)value];                    /*You have now selected a random playing card that has not been dealt previously. This will return this card 
                                                                                        and set the corresponding element in the cardPack array to null: */
            this.cardPack[(int)suit, (int)value] = null;
            return card;
        }

        private bool IsSuitEmpty(Suit suit)                                             /*the purpose of this method is to take a Suit parameter and return a Boolean value indicating whether there 
                                                                                        are any more cards of this suit left in the pack. */
                                                                                        /*This code iterates through the possible card values and uses the IsCardAlreadyDealt method to determine whether 
                                                                                         * there is a card left in the cardPack array that has the specifi ed suit and value. If the loop fi nds a card, 
                                                                                         * the value in the result variable is set to false, and the break statement causes the loop to terminate. If 
                                                                                         * the loop completes without fi nding a card, the result variable remains set to its initial value of true. The
                                                                                         * value of the result variable is passed back as the return value of the method.*/
        {
            bool result = true;
            for (Value value = Value.Two; value <= Value.Ace; value++)
            {
                if (!IsCardAlreadyDealt(suit, value))                                   /*The purpose of this method is to determine whether the card with the specifi ed suit and value has already been 
                                                                                        dealt and removed from the pack. You will see later that when the DealCardFromPack method deals a card, it removes 
                                                                                        the card from the cardPack array and sets the corresponding element to null. This method returns true if the element 
                                                                                        in the cardPack array corresponding to the suit and value is null, and it returns false otherwise. */
                {
                    result = false; break;
                }
            }
            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value) 
            => (this.cardPack[(int)suit, (int)value] == null);
    }
}