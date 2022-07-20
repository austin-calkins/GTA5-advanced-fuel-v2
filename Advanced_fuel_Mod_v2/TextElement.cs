using System;

namespace Advanced_Fuel_Mod_v2
{
    public class TextElement
    {
        public string text;

        public float xPos;

        public float yPos;

        public float fontSize;

        public TextElement(string newText, float newX, float newY, float newFontSize)
        {
            this.text = newText;
            this.xPos = newX;
            this.yPos = newY;
            this.fontSize = newFontSize;
        }
    }
}