using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmotionDetector
{
    public static class FaceExtensions
    {
        public static string GetStrongestEmotion(this DetectedFace face)
        {
            var emotions = face.FaceAttributes.Emotion;

            var strongest = emotions.GetType()
                .GetProperties()
                .Select(a => new { name = a.Name, value = (double)a.GetValue(emotions) })
                .OrderByDescending(a => a.value)
                .First();

            return strongest.name;
        }

    }
}
