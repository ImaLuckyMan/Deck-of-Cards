using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Cards
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public const int NumHands = 4;
        private Pack pack = null;
        private Hand[] hands = new Hand[NumHands];

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void dealClick(object sender, RoutedEventArgs e)                    /*This statement simply creates a new pack of cards. You saw earlier that this class contains a two-
                                                                                    dimensional array holding the cards in the pack, and the constructor populates this array with
                                                                                    the details of each card. You now need to create four hands of cards from this pack.*/
        {                               
            try
            {                                                                       /*This for loop creates four hands from the pack of cards and stores them in an array called hands.
                                                                                    Each hand is initially empty, so you need to deal the cards from the pack to each hand.*/
                pack = new Pack();
                for (int handNum = 0; handNum < NumHands; handNum++)
                {                                                                   /*The inner for loop populates each hand by using the DealCardFromPack method to retrieve a
                                                                                    card at random from the pack and the AddCardToHand method to add this card to a hand. */
                    hands[handNum] = new Hand();
                    for (int numCards = 0; numCards < Hand.HandSize; numCards++)
                    {
                        PlayingCard cardDealt = pack.DealCardFromPack();
                        hands[handNum].AddCardToHand(cardDealt);
                    }
                }

                north.Text = hands[0].ToString();
                south.Text = hands[1].ToString();
                east.Text = hands[2].ToString();
                west.Text = hands[3].ToString();
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message, "Error");
                msg.ShowAsync();
            }
        }
    }
}
