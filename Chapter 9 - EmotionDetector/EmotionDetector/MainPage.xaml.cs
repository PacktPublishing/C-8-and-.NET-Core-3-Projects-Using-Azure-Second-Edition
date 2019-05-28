using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

/// <summary>
/// Based on the following MSDN article:
/// https://docs.microsoft.com/en-us/azure/cognitive-services/face/quickstarts/csharp
/// 
/// See this article for details on the Absolute Layout:
/// https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/absolute-layout
/// </summary>
namespace EmotionDetector
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private int _originalWidth;
        private int _originalHeight;

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var image = await TakePicture();

            DisplayedImage.Source = ImageSource.FromStream(() => image.GetStream());

            var emotionData = await GetEmotionAnalysis(image.GetStream());

            DisplayData(emotionData);

        }

        private void DisplayData(IList<DetectedFace> faces)
        {
            // Remove and existing labels
            var labels = Layout.Children
                .Where(a => (a.AutomationId?.Contains("emotion-label") ?? false)
                || (a.AutomationId?.Contains("error") ?? false))
                .ToList();
            foreach (var label in labels)
            {
                Layout.Children.Remove(label);
            }

            if (faces == null)
            {
                CreateLabel("Unable to get data", "error");
                return;
            }

            if (faces.Count() > 1)
            {
                CreateLabel("Multiple faces not supported in this version", "error");
                return;
            }

            var face = faces.SingleOrDefault();
            if (face == null)
            {
                CreateLabel("No face found", "error");
                return;
            }

            CreateLabel(face.GetStrongestEmotion(), face.FaceId.ToString());
        }

        private async Task<IList<DetectedFace>> GetEmotionAnalysis(Stream imageStream)
        {
            var byteData = GetImageAsByteArray(imageStream);

            return await MakeAnalysisRequest(byteData,
                "https://uksouth.api.cognitive.microsoft.com/face/v1.0/detect",
                "4a9c2b7404fd45ed9aff787f158e24c7");

        }
        
        private async Task<MediaFile> TakePicture()
        {
            string fileName = $"FaceImg_{DateTime.Now.Ticks}";

            MediaFile photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = fileName
            });

            if (photo != null)
            {
                return photo;
            }

            return null;
        }

        public async Task<List<DetectedFace>> MakeAnalysisRequest(Byte[] byteData, string uriBase, string subscriptionKey)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                "&returnFaceAttributes=emotion&recognitionModel=recognition_01&returnRecognitionModel=false";

            string uri = $"{uriBase}?{requestParameters}";
            HttpResponseMessage response;

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                response = await client.PostAsync(uri, content);
                string contentString = await response.Content.ReadAsStringAsync();

                List<DetectedFace> faceDetails = JsonConvert.DeserializeObject<List<DetectedFace>>(contentString);
                if (faceDetails.Count != 0)
                {
                    return faceDetails;
                }
            }
            return null;
        }

        private byte[] GetImageAsByteArray(Stream stream)
        {
            BinaryReader binaryReader = new BinaryReader(stream);
            return binaryReader.ReadBytes((int)stream.Length);

        }

        private void CreateLabel(string displayText, string id)
        {
            var newLabel = new Label()
            {
                Text = displayText,
                AutomationId = $"emotion-label-{id}",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center
            };

            AbsoluteLayout.SetLayoutBounds(newLabel, new Rectangle(.5, 1, .5, .1));
            AbsoluteLayout.SetLayoutFlags(newLabel, AbsoluteLayoutFlags.All);

            Layout.Children.Add(newLabel);
        }
    }
}
