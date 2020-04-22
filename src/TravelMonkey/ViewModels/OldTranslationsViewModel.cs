using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Windows.Input;
using TravelMonkey.Models;
using TravelMonkey.Services;
using TravelMonkey.Views;
using Xamarin.Forms;

namespace TravelMonkey.ViewModels
{
    public class OldTranslationsViewModel : BaseViewModel
    {
        private string _inputText;
        private List<OldSearchs> _searchs;

        public List<OldSearchs> Searchs
        {
            get => _searchs;
            set
            {
                Set(ref _searchs, value);
            }
        }
        public ICommand BTGo { get; }
        public OldTranslationsViewModel()
        {
            BTGo = new Command(dat => Goto(dat));
        }
        internal void Refresh()
        {
            Searchs = DataTranslationsService.Instance.Listado;
        }

        internal async void Goto(object dat)
        {
            OldSearchs item = dat as OldSearchs;
            if (item == null) return;
            await App.Current.MainPage.Navigation.PushModalAsync(new TranslationResultPage(item.Phrase));
        }
    }
}