using System;
using System.Threading.Tasks;


namespace Neural_Networks
{
    /// <summary>
    /// Neural network.
    /// </summary>
    public class Network
    {
        /// <summary>
        /// The Outputs.
        /// First dimension is layer.
        /// Second dimension is neuron (his output).
        /// </summary>
        protected double[][] _outputs;

        /// <summary>
        /// Sizes of layers.
        /// </summary>
        protected int[] _layers;

        /// <summary>
        /// The beta ratio.
        /// </summary>
        protected double _beta;

        /// <summary>
        /// The weights of neurons in network
        /// First dimension is layer.
        /// Second dimension is neuron.
        /// Third dimension is neuron's input (wight).
        /// </summary>
        protected double[][][] _weights;

        /// <summary>
        /// Initializes a new instance of the <see cref="Network"/> class.
        /// </summary>
        protected Network()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Network"/> class.
        /// </summary>
        /// <param name="layers">The layers.</param>
        /// <param name="beta">The beta.</param>
        public Network(int[] layers, double beta)
        {
            Random random = new Random();
            _layers = layers;
            _beta = beta;

            _outputs = new double[layers.Length][];
            _weights = new double[layers.Length][][];

            for (int i = 0; i < layers.Length; i++)
                _outputs[i] = new double[layers[i]];

            for (int i = 1; i < layers.Length; i++)
            {
                _weights[i] = new double[layers[i]][];
                for (int j = 0; j < layers[i]; j++)
                {
                    _weights[i][j] = new double[layers[i - 1] + 1];
                    for (int k = 0; k < _weights[i][j].Length; k++)
                    {
                        _weights[i][j][k] = random.Next(-30, 30) / 100.0;
                    }
                }
            }
        }

        /// <summary>
        /// Function of activation for neuron.
        /// </summary>
        /// <param name="signal">The signal.</param>
        /// <returns></returns>
        private double Sigmoid(double signal)
        {
            return (1 / (1 + Math.Exp(-_beta * signal)));
        }

        /// <summary>
        /// Computes the network response.
        /// </summary>
        /// <param name="inputVector">The input vector.</param>
        public void ComputeNetworkResponse(double[] inputVector)
        {
            Array.Copy(inputVector, _outputs[0], inputVector.Length);

            for (int i = 1; i < _outputs.Length; i++)
            {
                //for (int j = 0; j < _outputs[i].Length; j++)
                Parallel.For(0, _outputs[i].Length, j =>
                {
                    double neuronOutput = 0.0;
                    int numberOfNeuronsInPreviousLayer = _outputs[i - 1].Length;
                    for (int k = 0; k < numberOfNeuronsInPreviousLayer; k++)
                        neuronOutput += _outputs[i - 1][k] * _weights[i][j][k];

                    _outputs[i][j] = Sigmoid(neuronOutput);
                });
            }
        }

        /// <summary>
        /// Gets the response which was saved in network.
        /// </summary>
        /// <returns>Response of network</returns>
        public double[] GetResponse()
        {
            return _outputs[_outputs.Length - 1];
        }

        /// <summary>
        /// Compute mean squared error
        /// </summary>
        /// <param name="expectedOutputs">The expected outputs.</param>
        /// <returns>Mean squared error</returns>
        public double GiveMeanSquaredError(double[] expectedOutputs)
        {
            double mse = 0.0;
            int lastLayer = _outputs.Length - 1;

            for (int i = 0; i < expectedOutputs.Length; i++)
            {
                mse += (expectedOutputs[i] - _outputs[lastLayer][i]) * (expectedOutputs[i] - _outputs[lastLayer][i]);
            }

            return mse / expectedOutputs.Length;
        }
    }
} 

