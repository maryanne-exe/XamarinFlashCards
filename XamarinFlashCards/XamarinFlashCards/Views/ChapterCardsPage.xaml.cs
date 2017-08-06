using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinFlashCards
{
    public partial class ChapterCardsPage : ContentPage
    {
        public ChapterCardsPage(ChapterCardsViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}
