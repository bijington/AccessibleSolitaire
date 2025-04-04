
using Microsoft.Maui.Graphics.Converters;

namespace Sa11ytaire4All.Views;

public partial class SettingsPage : ContentPage
{

    public SettingsPage()
	{
		InitializeComponent();

#if IOS
        SoundsSettingsGrid.IsVisible = true;
#endif

        //for (int i = 100; i <= 400; i += 25)
        //{
        //    ZoomPicker.Items.Add(i.ToString() + "%");
        //}

        //var currentZoomLevel = (int)Preferences.Get("ZoomLevel", 100);
        //ZoomPicker.SelectedItem = currentZoomLevel.ToString() + "%";

        var pickers = new Picker[]{ 
            SuitColoursClubsPicker,
            SuitColoursDiamondsPicker,
            SuitColoursHeartsPicker,
            SuitColoursSpadesPicker};

        foreach (var picker in pickers)
        {
            foreach (var colourName in MainPage.suitColours.Keys)
            {
                picker.Items.Add(colourName);
            }
        }

        for (int i = 0; i < 6; ++i)
        {
            LongPressOnCardPicker.Items.Add(i == 0 ? "Never" : i.ToString());
        }

        var longPressZoomDuration = (int)Preferences.Get("LongPressZoomDuration", 2000);
        LongPressOnCardPicker.SelectedIndex = longPressZoomDuration / 1000;

        var currentColour = (string)Preferences.Get("SuitColoursClubs", "Black");
        SuitColoursClubsPicker.SelectedItem = currentColour;

        currentColour = (string)Preferences.Get("SuitColoursDiamonds", "Red");
        SuitColoursDiamondsPicker.SelectedItem = currentColour;

        currentColour = (string)Preferences.Get("SuitColoursHearts", "Red");
        SuitColoursHeartsPicker.SelectedItem = currentColour;

        currentColour = (string)Preferences.Get("SuitColoursSpades", "Black");
        SuitColoursSpadesPicker.SelectedItem = currentColour;

        var showRankSuitLarge = (bool)Preferences.Get("ShowRankSuitLarge", true);
        ShowRankSuitLargeSwitch.IsToggled = showRankSuitLarge;

        //var showZoomCardButton = (bool)Preferences.Get("ShowZoomCardButton", false);
        //ShowZoomCardButtonSwitch.IsToggled = showZoomCardButton;

        //var cardBrightness = (int)Preferences.Get("CardBrightness", 100);
        //CardBrightnessSlider.Value = cardBrightness;

        var showAnnouncementButton = (bool)Preferences.Get("ShowStateAnnouncementButton", false);
        ShowStateAnnouncementButtonCheckbox.IsToggled = showAnnouncementButton;

        var ExtendDealtCardHitTarget = (bool)Preferences.Get("ExtendDealtCardHitTarget", false);
        ExtendDealtCardHitTargetCheckbox.IsToggled = ExtendDealtCardHitTarget;

        var allowSelectionByFaceDownCard = (bool)Preferences.Get("AllowSelectionByFaceDownCard", true);
        AllowSelectionByFaceDownCardCheckbox.IsToggled = allowSelectionByFaceDownCard;

        var highlightSelectedCardSet = (bool)Preferences.Get("HighlightSelectedCardSet", true);
        HighlightSelectedCardSetSwitch.IsToggled = highlightSelectedCardSet;

        var mergeFaceDownCards = (bool)Preferences.Get("MergeFaceDownCards", true);
        MergeFaceDownCardsSwitch.IsToggled = mergeFaceDownCards;

        var flipGameLayoutHorizontally = (bool)Preferences.Get("FlipGameLayoutHorizontally", false);
        FlipGameLayoutHorizontallySwitch.IsToggled = flipGameLayoutHorizontally;

#if IOS
        var playSoundSuccessfulMove = (bool)Preferences.Get("PlaySoundSuccessfulMove", false);
        PlaySoundSuccessfulMoveSwitch.IsToggled = playSoundSuccessfulMove;

        var playSoundUnsuccessfulMove = (bool)Preferences.Get("PlaySoundUnsuccessfulMove", false);
        PlaySoundUnsuccessfulMoveSwitch.IsToggled = playSoundUnsuccessfulMove;

        var playSoundOther = (bool)Preferences.Get("PlaySoundOther", false);
        PlaySoundOtherSwitch.IsToggled = playSoundOther;
#endif

        // Game playing options.

        for (int i = 1; i <= 3; ++i)
        {
            CardTurnCountPicker.Items.Add(i.ToString());
        }

        var cardTurnCount = (int)Preferences.Get("CardTurnCount", 1);
        CardTurnCountPicker.SelectedItem = cardTurnCount.ToString();

        var kingsOnlyToEmptyPile = (bool)Preferences.Get("KingsOnlyToEmptyPile", false);
        KingsOnlyToEmptyPileSwitch.IsToggled = kingsOnlyToEmptyPile;
    }

    private async void CloseButton_Clicked(object sender, EventArgs e)
    {
        //if (ZoomPicker != null)
        //{
        //    var selectedItem = ZoomPicker.SelectedItem;
        //    if (selectedItem != null)
        //    {
        //        var selectionString = selectedItem.ToString();
        //        if (selectionString != null)
        //        {
        //            var newZoomLevelString = selectionString.Replace("%", "");
        //            var newZoomLevel = int.Parse(newZoomLevelString);

        //            Preferences.Set("ZoomLevel", newZoomLevel);
        //        }
        //    }
        //}

        if (LongPressOnCardPicker != null)
        {
            var selectedIndex = LongPressOnCardPicker.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Preferences.Set("LongPressZoomDuration", selectedIndex * 1000);
            }
        }

        var selectedColourItem = SuitColoursClubsPicker.SelectedItem as string;
        if (selectedColourItem != null)
        {
            Preferences.Set("SuitColoursClubs", selectedColourItem);
        }

        selectedColourItem = SuitColoursDiamondsPicker.SelectedItem as string;
        if (selectedColourItem != null)
        {
            Preferences.Set("SuitColoursDiamonds", selectedColourItem);
        }

        selectedColourItem = SuitColoursHeartsPicker.SelectedItem as string;
        if (selectedColourItem != null)
        {
            Preferences.Set("SuitColoursHearts", selectedColourItem);
        }

        selectedColourItem = SuitColoursSpadesPicker.SelectedItem as string;
        if (selectedColourItem != null)
        {
            Preferences.Set("SuitColoursSpades", selectedColourItem);
        }

        var showRankSuitLarge = ShowRankSuitLargeSwitch.IsToggled;
        Preferences.Set("ShowRankSuitLarge", showRankSuitLarge);


        //var showZoomCardButton = ShowZoomCardButtonSwitch.IsToggled;
        //Preferences.Set("ShowZoomCardButton", showZoomCardButton);

        //var cardBrightnessValue = (int)CardBrightnessSlider.Value;
        //Preferences.Set("CardBrightness", cardBrightnessValue);

        var showStateAnnouncementButton = ShowStateAnnouncementButtonCheckbox.IsToggled;
        Preferences.Set("ShowStateAnnouncementButton", showStateAnnouncementButton);

        var ExtendDealtCardHitTarget = ExtendDealtCardHitTargetCheckbox.IsToggled;
        Preferences.Set("ExtendDealtCardHitTarget", ExtendDealtCardHitTarget);

        var allowSelectionByFaceDownCard = AllowSelectionByFaceDownCardCheckbox.IsToggled;
        Preferences.Set("AllowSelectionByFaceDownCard", allowSelectionByFaceDownCard);

        var highlightSelectedCardSet = HighlightSelectedCardSetSwitch.IsToggled;
        Preferences.Set("HighlightSelectedCardSet", highlightSelectedCardSet);

        var mergeFaceDownCards = MergeFaceDownCardsSwitch.IsToggled;
        Preferences.Set("MergeFaceDownCards", mergeFaceDownCards);

        var flipGameLayoutHorizontally = FlipGameLayoutHorizontallySwitch.IsToggled;
        Preferences.Set("FlipGameLayoutHorizontally", flipGameLayoutHorizontally);

#if IOS
        var playSoundSuccessfulMove = PlaySoundSuccessfulMoveSwitch.IsToggled;
        Preferences.Set("PlaySoundSuccessfulMove", playSoundSuccessfulMove);

        var playSoundUnsuccessfulMove = PlaySoundUnsuccessfulMoveSwitch.IsToggled;
        Preferences.Set("PlaySoundUnsuccessfulMove", playSoundUnsuccessfulMove);

        var playSoundOther = PlaySoundOtherSwitch.IsToggled;
        Preferences.Set("PlaySoundOther", playSoundOther);
#endif

        // Game playing options.

        var cardTurnCountValue = (int)CardTurnCountPicker.SelectedIndex;
        Preferences.Set("CardTurnCount", cardTurnCountValue + 1);

        var kingsOnlyToEmptyPile = KingsOnlyToEmptyPileSwitch.IsToggled;
        Preferences.Set("KingsOnlyToEmptyPile", kingsOnlyToEmptyPile);

        await Navigation.PopModalAsync();
    }
}