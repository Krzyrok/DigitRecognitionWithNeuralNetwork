using System;
using System.Drawing;
using System.Windows.Forms;

namespace Neural_Networks
{
    /// <summary>
    /// Class for managing the GUI
    /// </summary>
    public class Controller
    {
        private INeuralNetworkGUI _neuralNetworkGUI;
        private IModel _model;
        private TeachableNetwork _network;
        private Teacher _teacherForNetwork;

        private Pen _pen;
        private Graphics _graphics;
        private Point _startPointForDrawing = Point.Empty;

        // WIDTH_FOR_BITMAP * HEIGHTH_FOR_BITMAP = number of neurons in first (input) layer of network
        private const int WIDTH_FOR_BITMAP = 28;
        private const int HEIGHTH_FOR_BITMAP = 28;
        private const int UPPER_MARGIN = 4;
        private const int LEFT_MARGIN = 4;

        private const int NUMBER_OF_RESULTS = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="gui">The GUI.</param>
        /// <param name="model">The model.</param>
        public Controller(INeuralNetworkGUI gui, IModel model)
        {
            _neuralNetworkGUI = gui;
            _model = model;

            _pen = new Pen(Color.Black, 5);
            _graphics = Graphics.FromImage(_neuralNetworkGUI.GiveImageFromDrawingArea());
            _graphics.Clear(Color.White);

            SetEventHandlers();
            PrepareNetwork();
        }

        /// <summary>
        /// Sets the event handlers.
        /// </summary>
        private void SetEventHandlers()
        {
            _neuralNetworkGUI.LeftMouseButtonWasPressedEvent += SetStartPosition;
            _neuralNetworkGUI.LeftMouseButtonWasReleasedEvent += DrawFigure;
            _neuralNetworkGUI.MouseWasMovedEvent += DrawFigure;
            _neuralNetworkGUI.AddNumberOrRecognizeEvent += TeachNetworkOrRecognizeNumber;
            _neuralNetworkGUI.ClearPressedEvent += ClearGraphicsOnWhite;
            _neuralNetworkGUI.TeachByUserOrByMnistPressedEvent += TeachNetworkUsingUserDataOrMnistData;
        }

        /// <summary>
        /// Prepares the network.
        /// </summary>
        private void PrepareNetwork()
        {
            int[] neurons = new int[3];
            neurons[0] = WIDTH_FOR_BITMAP * HEIGHTH_FOR_BITMAP;
            neurons[1] = 88;
            neurons[2] = 10;
            double beta = 2.0;
            double eta = 0.2;
            double momentum = 0.3;

            _network = new TeachableNetwork(neurons, beta, eta, momentum);
            TrainingCollection trainingData = TrainingCollection.LoadUserData(_path);

            double minDelta = 0.001; // 0.005
            int maxAge = 1000;
            int maxIteration = 10000000;
            _teacherForNetwork = new Teacher(trainingData, minDelta, maxAge, maxIteration);        
        }

        /// <summary>
        /// Sets the start position for drawing letter.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="mouseArgs">The mouse arguments.</param>
        private void SetStartPosition(object sender, MouseArgs mouseArgs)
        {
            _startPointForDrawing = mouseArgs.MousePosition;
        }

        /// <summary>
        /// Draws the figure in drawing area. 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="mouseArgs">The mouse arguments.</param>
        private void DrawFigure(object sender, MouseArgs mouseArgs)
        {
            Point endPositionForDrawing = mouseArgs.MousePosition;
            _graphics.DrawLine(_pen, _startPointForDrawing, endPositionForDrawing);
            _startPointForDrawing = endPositionForDrawing;
            _neuralNetworkGUI.RefreshDrawingArea();          
        }

        /// <summary>
        /// Clears the graphics on white.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ClearGraphicsOnWhite(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            _neuralNetworkGUI.RefreshDrawingArea();
        }

        private string _path = "UserData.dat";

        /// <summary>
        /// Teaches the network or recognize number.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The arguments.</param>
        private void TeachNetworkOrRecognizeNumber(object sender, AddNumberOrRecognizeArgs args)
        {
            Rectangle boundsOfLetter = _model.FindBoundsOfPictureOnImageAndReturnRectangle(_neuralNetworkGUI.GiveImageFromDrawingArea(), _pen.Color);

            Bitmap bitmapForFirstLayer = new Bitmap(WIDTH_FOR_BITMAP, HEIGHTH_FOR_BITMAP);
            Graphics g = Graphics.FromImage(bitmapForFirstLayer);
            g.DrawImage(_neuralNetworkGUI.GiveImageFromDrawingArea(), 
                new Rectangle(LEFT_MARGIN, UPPER_MARGIN, WIDTH_FOR_BITMAP - 2 * LEFT_MARGIN, HEIGHTH_FOR_BITMAP - 2 * UPPER_MARGIN), 
                boundsOfLetter, 
                GraphicsUnit.Pixel);

            double[] arrayForFirstLayerOfNetwork = _model.GiveArrayOfIntegersFromImage(bitmapForFirstLayer, _pen.Color);

            Pen newPen = new Pen(Color.Red);
            _graphics.DrawRectangle(newPen, boundsOfLetter);
            _neuralNetworkGUI.RefreshDrawingArea();

            // ------------------------------------------------------------------------
            //TestCuttingImageOfNumberAndTestExchangePixelsForNumber(arrayForFirstLayerOfNetwork);
            // ------------------------------------------------------------------------
            // ------------------------------------------------------------------------
            // TestRecognizingNumbersFromFile();
            // ------------------------------------------------------------------------

            if (args.IsNeededAddingNumber)
            {
                if (args.WhatNumber == -1)
                {
                    MessageBox.Show("Nie zaznaczono liczby do nauki");
                    return;
                }

                double[] expectedResults = new double[NUMBER_OF_RESULTS];
                int whatNumber = 0;
                for (int i = 0; i < NUMBER_OF_RESULTS; i++)
                {
                    if (i != args.WhatNumber)
                    {
                        expectedResults[i] = 0;
                    }
                    else
                    {
                        expectedResults[i] = 1;
                        whatNumber = i;
                    }
                }
                TrainingCollection userTrainingData = TrainingCollection.LoadUserData(_path);
                if (userTrainingData == null)
                    return;

                TrainingSet trainingSet = new TrainingSet();
                trainingSet.Input = arrayForFirstLayerOfNetwork;
                trainingSet.Response = expectedResults;
                trainingSet.Value = whatNumber;
                userTrainingData.Values.Add(trainingSet);
                userTrainingData.SaveUserData(_path);
            }
            else
            {
                // ------------------------------------------------------------------
                TestNetworkUsingTestingDataFromFile();
                // ------------------------------------------------------------------

                _network.ComputeNetworkResponse(arrayForFirstLayerOfNetwork);
                double[] resultFromNetwork = _network.GetResponse();
                double max = -1;
                int index = 0;
                for (int i = 0; i < resultFromNetwork.Length; i++)
                {
                    if (resultFromNetwork[i] > max)
                    {
                        max = resultFromNetwork[i];
                        index = i;
                    }
                }
                _neuralNetworkGUI.SelectNumber(index);
            }
        }

        private void TeachNetworkUsingUserDataOrMnistData(object sender, TeachingArgs args)
        {
            if (args.IsUserData)
            {
                TrainingCollection userTrainingData = TrainingCollection.LoadUserData(_path);
                _teacherForNetwork.ChangeTrainingData(userTrainingData);
                _teacherForNetwork.ChangeDelta(0.001);
                _teacherForNetwork.TeachNetwork(_network);
            }
            else
            {
                TrainingCollection mnistTrainingData = TrainingCollection.LoadStandardData();
                _teacherForNetwork.ChangeTrainingData(mnistTrainingData);
                _teacherForNetwork.ChangeDelta(0.005);
                _teacherForNetwork.TeachNetwork(_network);
            }
        }

        // -----------------------------------------------------------
        // Testing methods
        // -----------------------------------------------------------

        // Test for cutting image and exchange pixels for number
        private void TestCuttingImageOfNumberAndTestExchangePixelsForNumber(double[] arrayForFirstLayerOfNetwork)
        {
            Bitmap bitmap = (Bitmap)_neuralNetworkGUI.GiveImageFromDrawingArea();
            for (int w = 0; w < HEIGHTH_FOR_BITMAP; w++)
            {
                for (int k = 0; k < WIDTH_FOR_BITMAP; k++)
                {
                    if (arrayForFirstLayerOfNetwork[w * WIDTH_FOR_BITMAP + k] == 1)
                        bitmap.SetPixel(k, w, Color.Black);
                }
            }
            _neuralNetworkGUI.RefreshDrawingArea();
        }

        // Test for recognizing digits from ubyte file and recognizing theirs labels
        private void TestRecognizingNumbersFromFile()
        {
            GiveItemsFromFile itemReturner = new GiveItemsFromFile();
            sbyte[,] expectedResultFromFile = itemReturner.GiveArrayOfExpectedResults();
            sbyte[,] trainDataFromFile = itemReturner.GiveArrayOfTrainData();
            const int sizeOfImage = 28 * 28; // heightOfImage * widthOfImage (28 x 28 pixel);

            for (int numberCounter = 0; numberCounter < expectedResultFromFile.GetLength(0); numberCounter++)
            {
                int index = 0;
                double[] expectedResult = new double[NUMBER_OF_RESULTS];
                for (int i = 0; i < NUMBER_OF_RESULTS; i++)
                {
                    expectedResult[i] = expectedResultFromFile[numberCounter, i];
                    if (expectedResult[i] == 1)
                        index = i;
                }

                double[] trainData = new double[sizeOfImage];
                for (int i = 0; i < sizeOfImage; i++)
                {
                    trainData[i] = trainDataFromFile[numberCounter, i];
                }

                _graphics.Clear(Color.White);
                Bitmap bitmap = (Bitmap)_neuralNetworkGUI.GiveImageFromDrawingArea();
                for (int w = 0; w < HEIGHTH_FOR_BITMAP; w++)
                {
                    for (int k = 0; k < WIDTH_FOR_BITMAP; k++)
                    {
                        if (trainData[w * WIDTH_FOR_BITMAP + k] == 1)
                            bitmap.SetPixel(k, w, Color.Black);
                    }
                }
                _neuralNetworkGUI.RefreshDrawingArea();
                _neuralNetworkGUI.SelectNumber(index);
            }
        }

        // Tests network, when test data are from file
        private void TestNetworkUsingTestingDataFromFile()
        {
            TestingCollection testingCollection = TestingCollection.LoadStandardData();
            Tester tester = new Tester(testingCollection);
            tester.TestNetwork(_network);
        }
    }
}
