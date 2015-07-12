using System;
using System.Threading.Tasks;


namespace Neural_Networks
{
    /// <summary>
    /// Neural network wich will learn
    /// </summary>
    public class TeachableNetwork : Network
    {
        private double[][] _errors;
        private double[][][] _previousWeights;
        private double _eta;
        private double _momentum;

        private TeachableNetwork()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeachableNetwork"/> class.
        /// </summary>
        /// <param name="layers">The layers.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="eta">The eta.</param>
        /// <param name="momentum">The momentum.</param>
        public TeachableNetwork(int[] layers, double beta, double eta, double momentum)
            : base(layers, beta)
        {
            _eta = eta;
            _momentum = momentum;

            _errors = new double[layers.Length][];
            _previousWeights = new double[layers.Length][][];

            for (int i = 1; i < layers.Length; i++)
            {
                _errors[i] = new double[layers[i]];
                _previousWeights[i] = new double[layers[i]][];
            }

            for (int i = 1; i < layers.Length; i++)
            {
                for (int j = 0; j < layers[i]; j++)
                {
                    _previousWeights[i][j] = new double[layers[i - 1] + 1];

                    for (int k = 0; k < _previousWeights[i][j].Length; k++)
                    {
                        _previousWeights[i][j][k] = 0.0;
                    }
                }
            }
        }

        /// <summary>
        /// Learns network.
        /// </summary>
        /// <param name="inputVector">The input vector.</param>
        /// <param name="expectedResponse">The expected response.</param>
        public void LearnSomething(double[] inputVector, double[] expectedResponse)
        {
            ComputeNetworkResponse(inputVector);

            // Compute errors

            // output layer
            int layer = _outputs.Length - 1;

            for (int i = 0; i < _outputs[layer].Length; i++)
                _errors[layer][i] = (expectedResponse[i] - _outputs[layer][i]) * (1.0 - _outputs[layer][i]);

            // hidden layers
            for (int i = _outputs.Length - 2; i > 0; i--)
            {
                for (int j = 0; j < _outputs[i].Length; j++)
                {
                    double error = 0.0;
                    for (int k = 0; k < _outputs[i + 1].Length; k++)
                        error += _outputs[i][j] * (1.0 - _outputs[i][j]) * _errors[i + 1][k] * _weights[i + 1][k][j];

                    _errors[i][j] = error;
                }
            }

            // --------------------------------------------------
            // New weights
            // --------------------------------------------------
            for (int i = 1; i < _outputs.Length; i++)
                //for (int j = 0; j < _outputs[i].Length; j++)
                Parallel.For(0, _outputs[i].Length, j =>
                {
                    double tmpWeight = 0;
                    for (int k = 0; k < _outputs[i - 1].Length; k++)
                    {
                        tmpWeight = _weights[i][j][k];
                        _weights[i][j][k] += _eta * _errors[i][j] * _outputs[i - 1][k] + _momentum * (_weights[i][j][k] - _previousWeights[i][j][k]);
                        _previousWeights[i][j][k] = tmpWeight;
                    } 
                });
            // --------------------------------------------------
        }
    }
}
