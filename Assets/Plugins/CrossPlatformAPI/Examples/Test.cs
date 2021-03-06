using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

namespace litefeel.crossplatformapi
{
    public class Test : MonoBehaviour
    {

        public InputField inputField;

        // Use this for initialization
        void Start()
        {
            print(Application.platform);
            print("streamingAssetsPath:" + Application.streamingAssetsPath);
            print("persistentDataPath:" + Application.persistentDataPath);
            
            if (inputField == null)
            {
                inputField = GameObject.Find("InputField").GetComponent<InputField>();
            }

#if !UNITY_EDITOR
#if !UNITY_2017_1_OR_NEWER
            Application.CaptureScreenshot("screenshot.png");
#else
            ScreenCapture.CaptureScreenshot("screenshot.png");
#endif
#endif
        }
        
        public void SavaToAlbum()
        {
            string filename = Application.persistentDataPath + "/screenshot.png";
            Album.SaveImage(filename);
        }

        public void SetToClipboard()
        {
            Clipboard.SetText(inputField.text);
        }

        public void GetFromClipboard()
        {
            inputField.text = Clipboard.GetText();
        }

        public void ShareText()
        {
            if (string.IsNullOrEmpty(inputField.text))
                inputField.text = "this is shared text!";
            Share.ShareText(inputField.text);
        }

        public void ShareImage()
        {
            print("Application.streamingAssetsPath " + Application.streamingAssetsPath);
            string filename = Application.persistentDataPath + "/screenshot.png";
            print("share image " + filename);
            Share.ShareImage(filename);
        }

        public void ShareImageWithText()
        {
            if (string.IsNullOrEmpty(inputField.text))
                inputField.text = "this is shared text!";
            print("Application.streamingAssetsPath " + Application.streamingAssetsPath);
            string filename = Application.persistentDataPath + "/screenshot.png";
            print("share image " + filename);
            Share.ShareImage(filename, inputField.text);
        }

        public void ShowAlert()
        {
            if (string.IsNullOrEmpty(inputField.text))
                inputField.text = "this is alert text!";
            AlertParams param = new AlertParams()
            {
                title = "this is title",
                message = inputField.text,
                yesButton = "Yes",
                noButton = "No",
                neutralButton = "Neutral"
            };
            param.onButtonPress = (AlertButton button) =>
            {
                print("the alert button press " + button.ToString());
            };
            UI.ShowAlert(param);
        }

        public void ShowToast()
        {
            if (string.IsNullOrEmpty(inputField.text))
                inputField.text = "this is toast text!";
            UI.ShowToast(inputField.text, false);
        }
    }
}