using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGCompressionRealization.Service
{
    public class JPEGCompressor : ICompressor
    {
        public Bitmap Compress(string path)
        {
            var bitmapImage = new Bitmap(path, true);
            
            // stage 1: convert image from RGB to YCrCb:
            YCbCrStruct[,] YCrCbImage = ConvertToYCrCb(bitmapImage);

            // stage 2: get discrete cosine transform matrixes:
            double[,] dctMatrix = CreatedctMatrix();
            double[,] dcttMatrix = CreatedcttMatrix();

            DiscreteCosineTransform(ref YCrCbImage, dctMatrix, dcttMatrix);

            // stage 3: quantization:
            double[,] quantizationMatrix = CreateQuantizationMatrix(3);

            Quantization(ref YCrCbImage, quantizationMatrix);

            // stage 4: dequantization:
            DeQuantization(ref YCrCbImage, quantizationMatrix);

            // stage 5: de DCT:
            DiscreteCosineTransform(ref YCrCbImage, dcttMatrix, dctMatrix);

            // for the future:
            // stage 4: convert to vector.
            //YCbCrStruct[,] YCbCrVector = ConvertToVector(YCrCbImage);

            // stage 5: RLE.
            //ZerosValues[,] RLEVector = RLE(YCbCrVector);

            return EncodeToRGB(YCrCbImage);

        }

        #region Matrix Create

        private double[,] CreatedcttMatrix()
        {
            double[,] matrix = new double[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 0)
                    {
                        matrix[j, i] = 1 / Math.Sqrt(8);
                    }
                    else
                    {
                        matrix[j, i] = 0.5 * Math.Cos((2 * j + 1) * i * Math.PI / 16);
                    }
                }
            }

            return matrix;
        }

        private double[,] CreatedctMatrix()
        {
            double[,] matrix = new double[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 0)
                    {
                        matrix[i, j] = 1 / Math.Sqrt(8);
                    }
                    else
                    {
                        matrix[i, j] = 0.5 * Math.Cos((2 * j + 1) * i * Math.PI / 16);
                    }
                }
            }

            return matrix;
        }

        private double[,] CreateQuantizationMatrix(int comprcoeff)
        {
            double[,] matrix = new double[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matrix[i,j] = 1 + ((1 + i + j) * comprcoeff);
                }
            }

            return matrix;
        }

        #endregion

        #region RGB - YCrCb Transform

        private YCbCrStruct[,] ConvertToYCrCb(Bitmap bitmapImage)
        {
            int x, y;
            Color pixelColor;
            YCbCrStruct[,] newImage = new YCbCrStruct[bitmapImage.Height,bitmapImage.Width];

            for (x = 0; x < bitmapImage.Width; x++)
            {
                for (y = 0; y < bitmapImage.Height; y++)
                {
                    pixelColor = bitmapImage.GetPixel(x, y);
                    newImage[y, x].Y  = 0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B;
                    newImage[y, x].Cb = 0.5 * pixelColor.R - 0.4187 * pixelColor.G - 0.0813 * pixelColor.B + 128;
                    newImage[y, x].Cr = 0.1687 * pixelColor.R - 0.3313 * pixelColor.G + 0.5 * pixelColor.B + 128;
                }
            }

            return newImage;
        }

        private Bitmap EncodeToRGB(YCbCrStruct[,] YCrCbImage)
        {
            Bitmap Image = new Bitmap(YCrCbImage.GetLength(1),YCrCbImage.GetLength(0));

            int x, y;

            for (x = 0; x < YCrCbImage.GetLength(1); x++)
            {
                for (y = 0; y < YCrCbImage.GetLength(0); y++)
                {                    
                    var red = YCrCbImage[y, x].Y + 1.402 * (YCrCbImage[y, x].Cr - 128);
                    var green = YCrCbImage[y, x].Y - 0.34414 * (YCrCbImage[y, x].Cb - 128) - 0.71414 * (YCrCbImage[y, x].Cr - 128);
                    var blue = YCrCbImage[y, x].Y + 1.772 * (YCrCbImage[y, x].Cb - 128);

                    if (red < 0) red = 0;
                    if (red > 255) red = 255;

                    if (green < 0) green = 0;
                    if (green > 255) green = 255;

                    if (blue < 0) blue = 0;
                    if (blue > 255) blue = 255;

                    Color newColor = Color.FromArgb((int)red, (int)green, (int)blue);
                    Image.SetPixel(x, y, newColor);
                }
            }

            return Image;
        }

        #endregion
        
        #region Code

        private void DiscreteCosineTransform(ref YCbCrStruct[,] YCrCbImage, double[,] dctMatrix, double[,] dcttMatrix)
        {
            int i, j, u, v, n, q, m, w;
            double sumY, sumCb, sumCr;

            var height = YCrCbImage.GetLength(0);
            var width = YCrCbImage.GetLength(1);

            for (u = 0; u < height; u = u + 8)
            {
                for (v = 0; v < width; v = v + 8)
                {
                    for (i = 0; i < 8; i++)
                    {
                        for (n = 0; n < 8; n++)
                        {
                            sumY = 0; sumCb = 0; sumCr = 0;
                            for (j = 0; j < 8; j++)
                            {
                                if ((u+j > height - 1) || (v+n > width - 1)) continue;
                                sumY += dctMatrix[i, j] * YCrCbImage[u + j, v + n].Y;
                                sumCb += dctMatrix[i, j] * YCrCbImage[u + j, v + n].Cb;
                                sumCr += dctMatrix[i, j] * YCrCbImage[u + j, v + n].Cr;
                            }
                            if ((u + i > height - 1) || (v + n > width - 1)) continue;
                            YCrCbImage[u + i, v + n].Y = sumY;
                            YCrCbImage[u + i, v + n].Cb = sumCb;
                            YCrCbImage[u + i, v + n].Cr = sumCr;
                        }
                    }

                    for (q = 0; q < 8; q++)
                    {
                        for (m = 0; m < 8; m++)
                        {
                            sumY = 0; sumCb = 0; sumCr = 0;
                            for (w = 0; w < 8; w++)
                            {
                                if ((u + q > height - 1) || (v + w > width - 1)) continue;
                                sumY += YCrCbImage[u + q, v + w].Y * dcttMatrix[w, m];
                                sumCr += YCrCbImage[u + q, v + w].Cr * dcttMatrix[w, m];
                                sumCb += YCrCbImage[u + q, v + w].Cb * dcttMatrix[w, m];
                            }
                            if ((u + q > height - 1) || (v + m > width - 1)) continue;
                            YCrCbImage[u + q, v + m].Y = sumY;
                            YCrCbImage[u + q, v + m].Cb = (q % 2 == 0 && m % 2 == 0 ? sumCb : 0);
                            YCrCbImage[u + q, v + m].Cr = (q % 2 == 0 && m % 2 == 0 ? sumCr : 0);
                        }
                    }
                }
            }                 
        }

        private void Quantization(ref YCbCrStruct[,] YCrCbImage, double[,] quantizationMatrix)
        {
            int i, j, u, v;
            var height = YCrCbImage.GetLength(0);
            var width = YCrCbImage.GetLength(1);

            for (u = 0; u < width; u = u + quantizationMatrix.GetLength(0))
            {
                for (v = 0; v < height; v = v + quantizationMatrix.GetLength(1))
                {
                    for (i = 0; i < 8; i++)
                    {
                        for (j = 0; j < 8; j++)
                        {
                            if ((v + j > height - 1) || (u + i > width - 1)) continue;
                            YCrCbImage[v + j, u + i].Y = Math.Round(YCrCbImage[v + j, u + i].Y / quantizationMatrix[i, j]);
                            YCrCbImage[v + j, u + i].Cr = Math.Round(YCrCbImage[v + j, u + i].Cr / quantizationMatrix[i, j]);
                            YCrCbImage[v + j, u + i].Cb = Math.Round(YCrCbImage[v + j, u + i].Cb / quantizationMatrix[i, j]);
                        }
                    }                    
                }
            }
        }

        #endregion

        #region Encode

        private void DeQuantization(ref YCbCrStruct[,] YCrCbImage, double[,] quantizationMatrix)
        {
            int i, j, u, v;
            var height = YCrCbImage.GetLength(0);
            var width = YCrCbImage.GetLength(1);

            for (u = 0; u < width; u = u + quantizationMatrix.GetLength(0))
            {
                for (v = 0; v < height; v = v + quantizationMatrix.GetLength(1))
                {
                    for (i = 0; i < 8; i++)
                    {
                        for (j = 0; j < 8; j++)
                        {
                            if ((v + j > height - 1) || (u + i > width - 1)) continue;
                            YCrCbImage[v + j, u + i].Y = YCrCbImage[v + j, u + i].Y * quantizationMatrix[i, j];
                            YCrCbImage[v + j, u + i].Cr = YCrCbImage[v + j, u + i].Cr * quantizationMatrix[i, j];
                            YCrCbImage[v + j, u + i].Cb = YCrCbImage[v + j, u + i].Cb * quantizationMatrix[i, j];
                        }
                    }
                }
            }
        }

        #endregion

        #region For the future

        private YCbCrStruct[,] ConvertToVector(YCbCrStruct[,] YCrCbImage)
        {
            int u, v, j = 0;

            YCbCrStruct[,] vector = new YCbCrStruct[YCrCbImage.GetLength(0) * YCrCbImage.GetLength(1) / 64, 64];

            for (u = 0; u < YCrCbImage.GetLength(0); u = u + 8)
            {
                for (v = 0; v < YCrCbImage.GetLength(1); v = v + 8)
                {
                    vector[j, 0] = YCrCbImage[u, v];
                    vector[j, 1] = YCrCbImage[u, v + 1];
                    vector[j, 2] = YCrCbImage[u + 1, v];
                    vector[j, 3] = YCrCbImage[u + 2, v];
                    vector[j, 4] = YCrCbImage[u + 1, v + 1];
                    vector[j, 5] = YCrCbImage[u, v + 2];
                    vector[j, 6] = YCrCbImage[u, v + 3];
                    vector[j, 7] = YCrCbImage[u + 1, v + 2];
                    vector[j, 8] = YCrCbImage[u + 2, v + 1];
                    vector[j, 9] = YCrCbImage[u + 3, v];
                    vector[j, 10] = YCrCbImage[u + 4, v];
                    vector[j, 11] = YCrCbImage[u + 3, v + 1];
                    vector[j, 12] = YCrCbImage[u + 2, v + 2];
                    vector[j, 13] = YCrCbImage[u + 1, v + 3];
                    vector[j, 14] = YCrCbImage[u, v + 4];
                    vector[j, 15] = YCrCbImage[u, v + 5];
                    vector[j, 16] = YCrCbImage[u + 1, v + 4];
                    vector[j, 17] = YCrCbImage[u + 2, v + 3];
                    vector[j, 18] = YCrCbImage[u + 3, v + 2];
                    vector[j, 19] = YCrCbImage[u + 4, v + 1];
                    vector[j, 20] = YCrCbImage[u + 5, v];
                    vector[j, 21] = YCrCbImage[u + 6, v];
                    vector[j, 22] = YCrCbImage[u + 5, v + 1];
                    vector[j, 23] = YCrCbImage[u + 4, v + 2];
                    vector[j, 24] = YCrCbImage[u + 3, v + 3];
                    vector[j, 25] = YCrCbImage[u + 2, v + 4];
                    vector[j, 26] = YCrCbImage[u + 1, v + 5];
                    vector[j, 27] = YCrCbImage[u, v + 6];
                    vector[j, 28] = YCrCbImage[u, v + 7];
                    vector[j, 29] = YCrCbImage[u + 1, v + 6];
                    vector[j, 30] = YCrCbImage[u + 2, v + 5];
                    vector[j, 31] = YCrCbImage[u + 3, v + 4];
                    vector[j, 32] = YCrCbImage[u + 4, v + 3];
                    vector[j, 33] = YCrCbImage[u + 5, v + 2];
                    vector[j, 34] = YCrCbImage[u + 6, v + 1];
                    vector[j, 35] = YCrCbImage[u + 7, v + 0];
                    vector[j, 36] = YCrCbImage[u + 7, v + 1];
                    vector[j, 37] = YCrCbImage[u + 6, v + 2];
                    vector[j, 38] = YCrCbImage[u + 5, v + 3];
                    vector[j, 39] = YCrCbImage[u + 4, v + 4];
                    vector[j, 40] = YCrCbImage[u + 3, v + 5];
                    vector[j, 41] = YCrCbImage[u + 2, v + 6];
                    vector[j, 42] = YCrCbImage[u + 1, v + 7];
                    vector[j, 43] = YCrCbImage[u + 2, v + 7];
                    vector[j, 44] = YCrCbImage[u + 3, v + 6];
                    vector[j, 45] = YCrCbImage[u + 4, v + 5];
                    vector[j, 46] = YCrCbImage[u + 5, v + 4];
                    vector[j, 47] = YCrCbImage[u + 6, v + 3];
                    vector[j, 48] = YCrCbImage[u + 7, v + 2];
                    vector[j, 49] = YCrCbImage[u + 7, v + 3];
                    vector[j, 50] = YCrCbImage[u + 6, v + 4];
                    vector[j, 51] = YCrCbImage[u + 5, v + 5];
                    vector[j, 52] = YCrCbImage[u + 4, v + 6];
                    vector[j, 53] = YCrCbImage[u + 3, v + 7];
                    vector[j, 54] = YCrCbImage[u + 4, v + 7];
                    vector[j, 55] = YCrCbImage[u + 5, v + 6];
                    vector[j, 56] = YCrCbImage[u + 6, v + 5];
                    vector[j, 57] = YCrCbImage[u + 7, v + 4];
                    vector[j, 58] = YCrCbImage[u + 7, v + 5];
                    vector[j, 59] = YCrCbImage[u + 6, v + 6];
                    vector[j, 60] = YCrCbImage[u + 5, v + 7];
                    vector[j, 61] = YCrCbImage[u + 6, v + 7];
                    vector[j, 62] = YCrCbImage[u + 7, v + 6];
                    vector[j, 63] = YCrCbImage[u + 7, v + 7];
                    j++;
                }
            }

            return vector;
        }

        private ZerosValues[,] RLE(YCbCrStruct[,] YCbCrVector)
        {
            int u, v, zerosY = 0, zerosCb = 0, zerosCr = 0, counterY = 0, counterCb = 0, counterCr = 0;
            
            ZerosValues[,] vector = new ZerosValues[YCbCrVector.GetLength(0) * 3, 64];

            for (u = 0; u < YCbCrVector.GetLength(0); u++)
            {
                zerosY = 0; zerosCb = 0; zerosCr = 0; counterY = 0; counterCb = 0; counterCr = 0;
                for (v = 0; v < YCbCrVector.GetLength(1); v++)
                {
                    if (YCbCrVector[u, v].Y != 0)
                    {
                        vector[u * 3, counterY] = new ZerosValues() { Zeros = zerosY, Values = YCbCrVector[u, v].Y };
                        counterY++;
                        zerosY = 0;
                    }
                    else
                    {
                        zerosY++;
                    }

                    if (YCbCrVector[u, v].Cb != 0)
                    {
                        vector[u * 3 + 1, counterCb] = new ZerosValues() { Zeros = zerosY, Values = YCbCrVector[u, v].Cb };
                        counterCb++;
                        zerosCb = 0;
                    }
                    else
                    {
                        zerosCb++;
                    }

                    if (YCbCrVector[u, v].Cr != 0)
                    {
                        vector[u * 3 + 2, counterCr] = new ZerosValues() { Zeros = zerosY, Values = YCbCrVector[u, v].Cr };
                        counterCr++;
                        zerosCr = 0;
                    }
                    else
                    {
                        zerosCr++;
                    }
                }
            }

            return vector;
        }

        #endregion
    }
}
