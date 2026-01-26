using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace KSunyo
{
    [System.Serializable] // This makes the class show up in the Inspector
    public class CarouselSlide
    {
        public Sprite image;
        public string description;
    }
    
    public class Carousel : MonoBehaviour
    {
        [SerializeField] private List<CarouselSlide> slides;
        
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [SerializeField] private Image image;

        [SerializeField] private TextMeshProUGUI text;
        
        private int currentSlideIndex = 0;
        void Start()
        {
            ChangeSlideContent(slides[0]);
            currentSlideIndex = 0;
            leftButton.onClick.AddListener(BackClicked);
            rightButton.onClick.AddListener(ForwardClicked);  
        }

        void BackClicked()
        {
            if (currentSlideIndex > 0)
            {
                ChangeSlideContent(slides[currentSlideIndex - 1]);
                currentSlideIndex--;
            }
            else if (currentSlideIndex == 0)
            {
                ChangeSlideContent(slides[slides.Count - 1]);
                currentSlideIndex = slides.Count - 1; 
            }
        }

        void ForwardClicked()
        {
            if (currentSlideIndex < slides.Count - 1)
            {
                ChangeSlideContent(slides[currentSlideIndex + 1]);
                currentSlideIndex++; 
            }
            else if  (currentSlideIndex == slides.Count - 1)
            {
                ChangeSlideContent(slides[0]);
                currentSlideIndex = 0; 
            }
        }

        void ChangeSlideContent(CarouselSlide data)
        {
            image.sprite = data.image;
            text.text = data.description;
        }
    }

}
