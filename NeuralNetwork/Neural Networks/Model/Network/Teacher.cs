using System;

namespace Neural_Networks
{
    /// <summary>
    /// Classe teaches network
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Gets or sets the maximum iteration count.
        /// </summary>
        /// <value>
        /// The maximum iteration count.
        /// </value>
        int MaxIterationCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum delta.
        /// </summary>
        /// <value>
        /// The minimum delta - the minimum value of error for whole era.
        /// </value>
        double MinDelta
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum era.
        /// </summary>
        /// <value>
        /// The maximum count of eras.
        /// </value>
        int MaxEra
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the training collection.
        /// </summary>
        /// <value>
        /// The training collection.
        /// </value>
        TrainingCollection TrainingCollection
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Teacher" /> class.
        /// </summary>
        /// <param name="traingingCollection">The trainging collection.</param>
        /// <param name="minDelta">The minimum delta.</param>
        /// <param name="maxEra">The maximum era.</param>
        /// <param name="maxIterationCount">The maximum iteration count.</param>
        public Teacher(TrainingCollection traingingCollection, double minDelta, int maxEra, int maxIterationCount)
        {
            TrainingCollection = traingingCollection;
            MinDelta = minDelta;
            MaxEra = maxEra;
            MaxIterationCount = maxIterationCount;
        }

        /// <summary>
        /// Changes the training data.
        /// </summary>
        /// <param name="traingingCollection">The trainging collection.</param>
        public void ChangeTrainingData(TrainingCollection traingingCollection)
        {
            TrainingCollection = traingingCollection;
        }

        /// <summary>
        /// Changes the delta for teaching network.
        /// </summary>
        /// <param name="newDelta">The new delta.</param>
        public void ChangeDelta(double newDelta)
        {
            MinDelta = newDelta;
        }

        /// <summary>
        /// Teaches the network.
        /// </summary>
        /// <param name="network">The network.</param>
        public void TeachNetwork(TeachableNetwork network)
        {
            int era = 0;
            double errorForWholeEra = 0;
            int currentIterationCount = 0;

            do
            {
                era++;
                errorForWholeEra = 0;
                TrainingCollection.Values.Shuffle();
                foreach (var trainingSet in TrainingCollection.Values)
                {                       
                    currentIterationCount++;
                    network.LearnSomething(trainingSet.Input, trainingSet.Response);
                }

                TrainingCollection.Values.Shuffle();
                errorForWholeEra = GiveErrorForWholeEra(network);
            }
            while(!Stop(errorForWholeEra, era, currentIterationCount));
        }

        /// <summary>
        /// Gives error for whole era.
        /// </summary>
        /// <param name="network">The network.</param>
        /// <returns>Error for whole era</returns>
        double GiveErrorForWholeEra(Network network)
        {
            double errorForEra = 0;
            int elementCounter = 0;

            foreach (var trainingSet in TrainingCollection.Values)
            {
                elementCounter++;

                network.ComputeNetworkResponse(trainingSet.Input);
                errorForEra += network.GiveMeanSquaredError(trainingSet.Response);
            }

            return Math.Sqrt(errorForEra / (double)elementCounter);            
        }

        /// <summary>
        /// Gives information if network should stop learning.
        /// </summary>
        /// <param name="currentEraError">The current era error.</param>
        /// <param name="currentEra">The current era.</param>
        /// <param name="currentIterration">The current iterration.</param>
        /// <returns>
        /// True if network shouldn't learn more, false if network needs teaching
        /// </returns>
        public virtual bool Stop(double currentEraError, int currentEra, int currentIterration)
        {
            if (
                currentEraError < MinDelta ||
                currentEra > MaxEra ||
                currentIterration > MaxIterationCount
                )
            {
                Console.WriteLine("Error for era: {0}, how many eras: {1}, how many iterations: {2}", currentEraError, currentEra, currentIterration);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
