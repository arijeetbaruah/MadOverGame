using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MadeOverGame.Question3
{
    public class DownloadImage : MonoBehaviour
    {
        public static DownloadImage singleton;
        
        public int cacheDuration = 7;

        void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public Texture2D Download(string URL)
        {
            if (IsImageCached(URL))
            {
                StartCoroutine(CacheImage(URL));
            }

            Texture2D texture = new Texture2D(4, 4, TextureFormat.DXT1, false);
            texture.LoadImage(System.IO.File.ReadAllBytes(Application.persistentDataPath + "/" + URL.GetHashCode() + ".png"));

            return texture;
        }

        public static bool IsImageCached(string URL)
        {
            bool exist = System.IO.File.Exists(Application.persistentDataPath + "/" + URL.GetHashCode() + ".png");

            if (exist)
            {
                System.DateTime time = System.IO.File.GetCreationTime(Application.persistentDataPath + "/" + URL.GetHashCode() + ".png");
                if ((time - System.DateTime.UtcNow).Days > singleton.cacheDuration)
                {
                    System.IO.File.Delete(Application.persistentDataPath + "/" + URL.GetHashCode() + ".png");
                    exist = false;
                }
            }

            return !exist;
        }

        IEnumerator CacheImage(string URL)
        {

            using (WWW www = new WWW(URL))
            {
                yield return www;

                System.IO.File.WriteAllBytes(Application.persistentDataPath + "/"+ URL.GetHashCode() + ".png", www.bytes);

                www.Dispose();
            }
        }
    }
}
