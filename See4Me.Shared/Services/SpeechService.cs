﻿using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;

namespace See4Me.Services
{
    public class SpeechService : ISpeechService
    {
        private readonly ITextToSpeech synthesizer;

        public SpeechService()
        {
            synthesizer = CrossTextToSpeech.Current;
            synthesizer.Init();
        }

        public Task SpeechAsync(string text, string language = null)
        {
            CrossLocale? locale = null;

            if (language != null)
            {
                locale = synthesizer.GetInstalledLanguages().FirstOrDefault(l => l.Language.StartsWith(language));
                locale = locale.Value.Language != null ? locale : null;
            }

            synthesizer.Speak(text, crossLocale: locale);
            return Task.FromResult<object>(null);
        }
    }
}
