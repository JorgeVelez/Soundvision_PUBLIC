using UnityEngine;

namespace cylvester
{
    public class SpectrogramGeneratorPlayMode : SpectrogramGenerator, ISpectrogramGenerator
    {
        private IPdArraySelector arraySelector_;

        private Color32[] resetColorArray;

        public SpectrogramGeneratorPlayMode(int textureWidth, int textureHeight, IPdArraySelector arraySelector)
            :base(textureWidth, textureHeight)
        {
            arraySelector_ = arraySelector;

            //generate empty texture
            Color32 resetColor = new Color32(0, 0, 0, 255); //black
            resetColorArray = Spectrum.GetPixels32();
            for (int i = 0; i < resetColorArray.Length; i++)
            {
                resetColorArray[i] = resetColor;
            }
        }

        public int Update()
        {
            
            var data = arraySelector_.SelectedArray;
            Spectrum.SetPixels32(resetColorArray); // Reset all pixels color
            //Draw Spectrum
            for (int x = 0; x < Spectrum.width; x++) //iterate over sprectrum length
            {
                for (int y=0; y<Spectrum.height; y++) //all pixels below spectrum value at x position
                {
                    Spectrum.SetPixel(x, y, new Color(data[x], 0, 0));
                }
            }

            Spectrum.Apply();
            return 0;
        }
    }
}