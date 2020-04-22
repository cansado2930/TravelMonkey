﻿using System.Collections.Generic;
using TravelMonkey.Models;
using TravelMonkey.Services;
using Xamarin.Forms;

namespace TravelMonkey.ViewModels
{
    public class TranslateResultPageViewModel : BaseViewModel
    {
        private readonly TranslationService _translationService =
            new TranslationService();

        private string _inputText;
        private Dictionary<string, string> _translations;

        public string InputText
        {
            get => _inputText;
            set
            {
                if (_inputText == value)
                    return;

                Set(ref _inputText, value);

                TranslateText();
            }
        }

        public Dictionary<string, string> Translations
        {
            get => _translations;
            set
            {
                Set(ref _translations, value);
            }
        }

        public Command<string> TranslateTextCommand => new Command<string>((inputText) =>
        {
            InputText = inputText;
        });

        private async void TranslateText()
        {
            OldSearchs old = null;
            foreach(var item in DataTranslationsService.Instance.Listado)
            {
                if (item.Phrase.Equals(_inputText))
                {
                    old = item;
                    break;
                }
            }
            if (old == null)
            {
                var result = await _translationService.TranslateText(_inputText);

                if (!result.Succeeded)
                {
                    MessagingCenter.Send(this, Constants.TranslationFailedMessage);
                }
                else
                {
                    DataTranslationsService.Instance.Add(_inputText, result.Translations);
                }
                Translations = result.Translations;
            }
            else
            {
                Translations = old.Resultados;
            }
        }
    }
}