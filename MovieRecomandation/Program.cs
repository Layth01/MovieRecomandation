using System;
using System.IO;
using Microsoft.ML.Trainers;
using Microsoft.ML.Data;
using Microsoft.Data.DataView;
using Microsoft.ML;

namespace MovieRecomandation
{
    class Program
    {
        static void Main(string[] args)
        {
            MLContext mLContext = new MLContext();
            IDataView trainingDataView = LoadData(mLContext).training;
            IDataView testDataView = LoadData(mLContext).test;

        }

        public static(IDataView training,IDataView test) LoadData(MLContext mLContext)
        {
            var trainingDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-train.csv");
            var testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-test.csv");

            IDataView trainingDataView = mLContext.Data.LoadFromTextFile<MovieRating>(trainingDataPath, hasHeader: true, separatorChar: ',');
            IDataView testDataView = mLContext.Data.LoadFromTextFile<MovieRating>(testDataPath, hasHeader: true, separatorChar: ',');

            return (trainingDataView, testDataView);
        }
    }
}
