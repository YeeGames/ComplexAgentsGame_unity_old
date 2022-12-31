using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
// using NumSharp;

namespace CAG2D_05
{
    public static class YeeInteraction
    {
        internal static void CreateAdjecancyMatrix(int totalAgent)
        {
            //TODO 构建矩阵描述粒子之间之距离
            // double[,] distanceMatrix = new double[gameSettings.numAgent * yeeType.NumElement, gameSettings.numAgent * yeeType.NumElement];
            Matrix<double> distanceMatrix = Matrix<double>.Build.Dense(totalAgent, totalAgent, 0.0);


            //TODO 构建矩阵描述粒子间是否有交互
            Matrix<int> isInteractionMatrix = Matrix<int>.Build.Dense(totalAgent, totalAgent, 0);

            //TODO 构建矩阵描述粒子间之力大小与方向
            Vector2 point = new Vector2(2, 3);
            Matrix<double> forceStrengthMatrix = Matrix<double>.Build.Dense(totalAgent, totalAgent, 0.0);
            Matrix<Vector2> forceDirectionMatrix = Matrix<Vector2>.Build.Dense(totalAgent, totalAgent, point);

        }

    }
}