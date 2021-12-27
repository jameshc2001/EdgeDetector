using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Picture_Manipulator
{
    class ImageProcessor
    {
        public ImageProcessor() { }

        public static Bitmap Canny(Bitmap source, int low, int high, bool customThresholds)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            result = ConvertToGrayscale(source); //convert to grayscale
            int[,] gaussian = new int[,]
            {
                { 2, 4, 5, 4, 2},
                { 4, 9, 12, 9, 4},
                { 5, 12, 15, 12, 5},
                { 4, 9, 12, 9, 4},
                { 2, 4, 5, 4, 2}
            };
            result = Convolution5x5(result, gaussian, 159); //apply gaussian blur
            int[,] sobelx = new int[,]
            {
                { 1, 0, -1},
                { 2, 0, -2},
                { 1, 0, -1}
            };
            int[,] sobely = new int[,]
            {
                { 1, 2, 1},
                { 0, 0, 0},
                { -1, -2, -1}
            };
            int[,] sobelxImage = Convolution3x3Accurate(result, sobelx, 1);
            int[,] sobelyImage = Convolution3x3Accurate(result, sobely, 1);
            int[,] gradients = new int[source.Width, source.Height];
            int[,] directions = new int[source.Width, source.Height];
            for (int x = 0; x < source.Width; x++) //perform sobel
            {
                for (int y = 0; y < source.Height; y++)
                {
                    double magnitude = Convert.ToInt32(Math.Sqrt(Math.Pow(sobelxImage[x,y], 2) + Math.Pow(sobelyImage[x, y], 2)));
                    gradients[x, y] = (int)magnitude;

                    double direction = Math.Atan2(sobelyImage[x, y], sobelxImage[x, y]);
                    direction *= (180 / Math.PI);
                    if (direction < 0) direction += 180;
                    if (direction <= 22.5) direction = 0;
                    else if (direction <= 67.5) direction = 45;
                    else if (direction <= 112.5) direction = 90;
                    else if (direction <= 157.5) direction = 135;
                    else direction = 0;
                    directions[x, y] = (int)direction;
                }
            }
            int[,] newGradients = new int[source.Width, source.Height];
            for (int x = 0; x < source.Width; x++) //perform non-maximum suppression
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (x == 0 || y == 0 || x == source.Width - 1 || y == source.Height - 1) newGradients[x, y] = gradients[x, y];
                    else
                    {
                        if (directions[x,y] == 0)
                        {
                            if (gradients[x, y] < gradients[x + 1, y] || gradients[x, y] < gradients[x - 1, y]) newGradients[x, y] = 0;
                            else newGradients[x, y] = gradients[x, y];
                        }
                        else if (directions[x,y] == 90)
                        {
                            if (gradients[x, y] < gradients[x, y + 1] || gradients[x, y] < gradients[x, y - 1]) newGradients[x, y] = 0;
                            else newGradients[x, y] = gradients[x, y];
                        }
                        else if (directions[x,y] == 135)
                        {
                            if (gradients[x, y] < gradients[x - 1, y - 1] || gradients[x, y] < gradients[x + 1, y + 1]) newGradients[x, y] = 0;
                            else newGradients[x, y] = gradients[x, y];
                        }
                        else
                        {
                            if (gradients[x, y] < gradients[x + 1, y - 1] || gradients[x, y] < gradients[x - 1, y + 1]) newGradients[x, y] = 0;
                            else newGradients[x, y] = gradients[x, y];
                        }
                    }
                }
            }
            int max = 0;
            for (int x = 0; x < source.Width; x++) //find max value
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (newGradients[x, y] > max) max = newGradients[x, y];
                }
            }
            //now set the high and low thresholds
            if (!customThresholds)
            {
                double highAccurate = max * 0.2; //0.2 and 0.15 and just values grabbed from someone's github. They are ratios!
                double lowAccurate = highAccurate * 0.15;
                high = Convert.ToInt32(highAccurate);
                low = Convert.ToInt32(lowAccurate);
            }
            int[,] strengths = new int[source.Width, source.Height]; //2 = strong. 1 = weak. 0 = suppress
            for (int x = 0; x < source.Width; x++) //double threshold
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (x == 0 || y == 0 || x == source.Width - 1 || y == source.Height - 1) strengths[x, y] = 0;
                    else
                    {
                        if (newGradients[x, y] > high) strengths[x, y] = 2;
                        else if (newGradients[x, y] > low) strengths[x, y] = 1;
                        else strengths[x, y] = 0;
                    }
                }
            }
            for (int x = 0; x < source.Width; x++) //edge tracking by hysteresis
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (x == 0 || y == 0 || x == source.Width - 1 || y == source.Height - 1) continue; //do nothing
                    else
                    {
                        if (strengths[x, y] == 2) continue; //this pixel is strong so keep it
                        else if (strengths[x, y] == 1)
                        {
                            //check if it is connected to a strong pixel
                            bool connectedToStrong = false;
                            int[,] surroundingStrengths = new int[,]
                            {
                                { strengths[x-1,y-1], strengths[x,y-1], strengths[x+1, y-1]},
                                { strengths[x-1,y], strengths[x,y], strengths[x+1,y] },
                                { strengths[x-1,y+1], strengths[x,y+1], strengths[x+1,y+1] }
                            };
                            foreach (int i in surroundingStrengths)
                            {
                                if (i == 2)
                                {
                                    connectedToStrong = true;
                                }
                            }
                            if (!connectedToStrong) newGradients[x, y] = 0;
                        }
                        else newGradients[x, y] = 0;
                    }
                }
            }
            for (int x = 0; x < source.Width; x++) //convert array to image
            {
                for (int y = 0; y < source.Height; y++)
                {
                    int value = newGradients[x, y];
                    if (value > 0) value = 255;
                    result.SetPixel(x, y, Color.FromArgb(255, value, value, value));
                }
            }
            return result;
        }

        public static Bitmap ConvertToGrayscale(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    double pixel = (0.3 * source.GetPixel(x, y).R) + (0.59 * source.GetPixel(x, y).G) + (0.11 * source.GetPixel(x, y).B);
                    int intPixel = (int)pixel;
                    result.SetPixel(x, y, Color.FromArgb(255, intPixel, intPixel, intPixel));
                }
            }
            return result;
        }

        public static Bitmap Convolution5x5(Bitmap source, int[,] kernel, int normalizationValue)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            int[,] pixels;
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (x <= 1 || y <= 1 || x >= source.Width - 2 || y >= source.Height - 2) result.SetPixel(x, y, source.GetPixel(x, y));
                    else
                    {
                        pixels = new int[,]
                        {
                            { source.GetPixel(x-2, y-2).R, source.GetPixel(x-1, y-2).R, source.GetPixel(x  , y-2).R, source.GetPixel(x+1, y-2).R, source.GetPixel(x+2, y-2).R },
                            { source.GetPixel(x-2, y-1).R, source.GetPixel(x-1, y-1).R, source.GetPixel(x  , y-1).R, source.GetPixel(x+1, y-1).R, source.GetPixel(x+2, y-1).R },
                            { source.GetPixel(x-2, y  ).R, source.GetPixel(x-1, y  ).R, source.GetPixel(x  , y  ).R, source.GetPixel(x+1, y  ).R, source.GetPixel(x+2, y  ).R },
                            { source.GetPixel(x-2, y+1).R, source.GetPixel(x-1, y+1).R, source.GetPixel(x  , y+1).R, source.GetPixel(x+1, y+1).R, source.GetPixel(x+2, y+1).R },
                            { source.GetPixel(x-2, y+2).R, source.GetPixel(x-1, y+2).R, source.GetPixel(x  , y+2).R, source.GetPixel(x+1, y+2).R, source.GetPixel(x+2, y+2).R }
                        };
                        int sum = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                sum += kernel[i, j] * pixels[i, j];
                            }
                        }
                        double finalSum = sum / (double)normalizationValue;
                        if (finalSum > 255) finalSum = 255;
                        else if (finalSum < 0) finalSum = 0;
                        result.SetPixel(x, y, Color.FromArgb(255, (int)finalSum, (int)finalSum, (int)finalSum));
                    }
                }
            }
            return result;
        }

        public static int[,] Convolution3x3Accurate(Bitmap source, int[,] kernel, int normalizationValue)
        {
            int[,] result = new int[source.Width, source.Height];
            int[,] pixels;
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (x == 0 || y == 0 || x == source.Width - 1 || y == source.Height - 1) result[x, y] = source.GetPixel(x, y).R;
                    else
                    {
                        pixels = new int[,]
                        {
                            { source.GetPixel(x-1, y-1).R, source.GetPixel(x  , y-1).R, source.GetPixel(x+1, y-1).R },
                            { source.GetPixel(x-1, y  ).R, source.GetPixel(x  , y  ).R, source.GetPixel(x+1, y  ).R },
                            { source.GetPixel(x-1, y+1).R, source.GetPixel(x  , y+1).R, source.GetPixel(x+1, y+1).R }
                        };
                        int sum = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                sum += kernel[i, j] * pixels[i, j];
                            }
                        }
                        double finalSum = sum / (double)normalizationValue;
                        result[x, y] = (int)finalSum;
                    }
                }
            }
            return result;
        }



        #region real
        public static Bitmap ConvolutionBad3x3(Bitmap source, double[,] inputKernel)
        {
            double[,] kernel = new double[,]
            {
                //flip the rows then flip the columns. All in one go it looks like this
                { inputKernel[2,2], inputKernel[1,2], inputKernel[0,2] },
                { inputKernel[2,1], inputKernel[1,1], inputKernel[0,1] },
                { inputKernel[2,0], inputKernel[1,0], inputKernel[0,0] }
            };

            Bitmap result = new Bitmap(source.Width, source.Height);
            double[] sums;
            Color[,] pixels;
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (x == 0 || y == 0 || x == source.Width - 1 || y == source.Height - 1) //if the pixel is on the edge dont bother
                    {
                        result.SetPixel(x, y, result.GetPixel(x, y));
                    }
                    else
                    {
                        pixels = new Color[3, 3] //get surrounding pixels
                        {
                            { source.GetPixel(x-1, y-1), source.GetPixel(x, y-1), source.GetPixel(x+1, y-1) },
                            { source.GetPixel(x-1, y), source.GetPixel(x, y), source.GetPixel(x+1, y) },
                            { source.GetPixel(x-1, y+1), source.GetPixel(x, y+1), source.GetPixel(x+1, y+1) }
                        };

                        //now perform the multiplication of similar elements then sum them together
                        sums = new double[3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                sums[0] += pixels[i, j].R * kernel[i, j];
                                sums[1] += pixels[i, j].G * kernel[i, j];
                                sums[2] += pixels[i, j].B * kernel[i, j];
                            }
                        }
                        result.SetPixel(x, y, Color.FromArgb(255, (int)sums[0], (int)sums[1], (int)sums[2]));
                    }
                }
            }

            return result;
        }
        #endregion

        #region NotSoGood
        public static int PixelValue(Color color)
        {
            return color.R + color.G + color.B;
        }

        public static Bitmap Threshold(Bitmap source, int threshold, bool white)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    //Debug.WriteLine(PixelValue(source.GetPixel(x,y)) + " vs " + threshold);
                    if (PixelValue(source.GetPixel(x, y)) > threshold)
                    {
                        if (white)
                        {
                            float strength = PixelValue(source.GetPixel(x, y)) / 765;
                            strength = strength * 255;
                            int value = Convert.ToInt32(strength);
                            result.SetPixel(x, y, Color.FromArgb(255, value, value, value));
                        }
                        else result.SetPixel(x, y, source.GetPixel(x, y));
                    }
                    else result.SetPixel(x, y, Color.Black);
                }
            }
            return result;
        }

        public static Color PassFilter(int[,] filter, Color[,] values)
        {
            int[] sums = new int[3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    sums[0] += (filter[x, y] * values[x, y].R);
                    sums[1] += (filter[x, y] * values[x, y].G);
                    sums[2] += (filter[x, y] * values[x, y].B);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (sums[i] > 255) sums[i] = 255;
                if (sums[i] < 0) sums[i] = 0;
            }
            return Color.FromArgb(255, sums[0], sums[1], sums[2]);
        }

        public static Bitmap Sobel(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            Bitmap image1 = new Bitmap(source.Width, source.Height);
            Bitmap image2 = new Bitmap(source.Width, source.Height);

            int[,] filter1 = new int[,]
            {
                { 1, 2, 1},
                { 0, 0, 0},
                { -1, -2, -1}
            };
            int[,] filter2 = new int[,]
            {
                { 1, 0, -1},
                { 2, 0, -2},
                { 1, 0, -1}
            };

            image1 = Filter(source, filter1);
            image2 = Filter(source, filter2);

            int[] values = new int[3];
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    values[0] = Convert.ToInt32(Math.Sqrt(Math.Pow(image1.GetPixel(x,y).R, 2) + Math.Pow(image2.GetPixel(x, y).R, 2)));
                    values[1] = Convert.ToInt32(Math.Sqrt(Math.Pow(image1.GetPixel(x, y).G, 2) + Math.Pow(image2.GetPixel(x, y).G, 2)));
                    values[2] = Convert.ToInt32(Math.Sqrt(Math.Pow(image1.GetPixel(x, y).B, 2) + Math.Pow(image2.GetPixel(x, y).B, 2)));
                    for (int i = 0; i < 3; i++)
                    {
                        if (values[i] > 255) values[i] = 255;
                        if (values[i] < 0) values[i] = 0;
                    }
                    result.SetPixel(x, y, Color.FromArgb(255, values[0], values[1], values[2]));
                }
            }

            result = result.Clone(new Rectangle(1, 1, source.Width - 2, source.Height - 2), result.PixelFormat);
            return result;
        }

        public static Bitmap Filter(Bitmap source, int[,] filter)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (x == 0 || x == source.Width - 1 || y == 0 || y == source.Height - 1)
                    {
                        result.SetPixel(x, y, source.GetPixel(x, y));
                    }
                    else
                    {
                        Color[,] values = new Color[,]
                        {
                            { source.GetPixel(x-1, y-1), source.GetPixel(x, y-1), source.GetPixel(x+1, y-1) },
                            { source.GetPixel(x-1, y), source.GetPixel(x, y), source.GetPixel(x+1, y) },
                            { source.GetPixel(x-1, y+1), source.GetPixel(x, y+1), source.GetPixel(x+1, y+1) }
                        };
                        result.SetPixel(x, y, PassFilter(filter, values));
                    }
                }
            }

            return result;
        }

        public static Bitmap Sharpen(Bitmap source)
        {
            int[,] sharpenFilter = new int[,]
            {
                { -1, -1, -1},
                { -1, 9, -1},
                { -1, -1, -1}
            };

            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (x == 0 || x == source.Width - 1 || y == 0 || y == source.Height - 1)
                    {
                        result.SetPixel(x, y, source.GetPixel(x, y));
                    }
                    else
                    {
                        Color[,] values = new Color[,]
                        {
                            { source.GetPixel(x-1, y-1), source.GetPixel(x, y-1), source.GetPixel(x+1, y-1) },
                            { source.GetPixel(x-1, y), source.GetPixel(x, y), source.GetPixel(x+1, y) },
                            { source.GetPixel(x-1, y+1), source.GetPixel(x, y+1), source.GetPixel(x+1, y+1) }
                        };
                        result.SetPixel(x, y, PassFilter(sharpenFilter, values));
                    }
                }
            }

            return result;
        }

        public static Bitmap Brightness(Bitmap source, int brightness)
        {
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    Color newBrightness = source.GetPixel(x, y);
                    int[] values = new int[3];
                    values[0] = newBrightness.R;
                    values[1] = newBrightness.G;
                    values[2] = newBrightness.B;
                    for (int i = 0; i < values.Length; i++) values[i] += brightness;
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (values[i] > 255) values[i] = 255;
                        if (values[i] < 0) values[i] = 0;
                    }
                    newBrightness = Color.FromArgb(newBrightness.A, values[0], values[1], values[2]);
                    source.SetPixel(x, y, newBrightness);
                }
            }
            return source;
        }

        public static Bitmap Laplace(Bitmap source, int tolerance)
        {
            Color[,] raw = new Color[source.Width, source.Height];
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    raw[x, y] = source.GetPixel(x, y);
                }
            }

            Color[,] edges = new Color[source.Width, source.Height];
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    if (x == 0 || x == source.Width - 1 || y == 0 || y == source.Height - 1)
                    {
                        edges[x, y] = Color.Black;
                    }
                    else
                    {
                        int pixel = 4 * PixelValue(raw[x, y]);
                        pixel -= PixelValue(raw[x, y + 1]);
                        pixel -= PixelValue(raw[x, y - 1]);
                        pixel -= PixelValue(raw[x + 1, y]);
                        pixel -= PixelValue(raw[x - 1, y]);

                        if (pixel > -tolerance)
                        {
                            edges[x, y] = Color.Black;
                        }
                        else
                        {
                            edges[x, y] = Color.White;
                        }
                    }
                }
            }

            Bitmap result = new Bitmap(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    result.SetPixel(x, y, edges[x, y]);
                }
            }
            return result;
        }

        #endregion
    }
}
