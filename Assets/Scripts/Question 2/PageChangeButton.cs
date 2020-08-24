using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace MadeOverGame.Question2
{
    public class PageChangeButton : MonoBehaviour
    {
        public HorizontalScrollSnap horizontalScroll;

        public void OnClick(int page)
        {
            int pageDiff = page - horizontalScroll.CurrentPage;

            if (pageDiff > 0)
            {
                for (int i = 0; i < pageDiff; i++)
                    horizontalScroll.NextScreen();
            }
            else if (pageDiff < 0)
            {
                for (int i = 0; i > pageDiff; i--)
                    horizontalScroll.PreviousScreen();
            }
        }
    }
}
