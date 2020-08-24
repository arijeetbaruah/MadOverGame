using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace MadeOverGame.Question3
{
    public class WebImage : MonoBehaviour
    {
        public string URL;

        public RawImage image;

        private void Awake()
        {
            SetImage(URL);
        }

        public void SetImage(string url)
        {
            Texture2D texture = DownloadImage.singleton.Download(url);

            image.texture = texture;
        }
    }
}
