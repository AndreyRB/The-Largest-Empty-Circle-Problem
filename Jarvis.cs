using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;


namespace VG_kr_dz
{
    internal class Jarvis
    {
        internal static List<PointF> GetSolution(List<PointF> points)
        {
            var n = points.Count;
            //список индексов множества точек list
            var indexArray = Range(n);

            //делаем первый элемент списка индексом самой левой вершины из list
            FindLeft(points, indexArray);
            //результирующий список индексов множества точек list
            var resultIndex = new List<int>();
            //добавляем первый элемент списка индексов в результирующий
            resultIndex.Add(indexArray[0]);
            //удаляем его из indexArray
            indexArray.RemoveAt(0);
            //добавляем в конец
            indexArray.Add(resultIndex[0]);

            //заполняем результирующий массив самыми правыми точками (по часовой стрелке) относительно текущей
            MostRightPoints(points, indexArray, resultIndex);

            return FromIntToPoint(resultIndex, points);
        }
        static double Rotation(PointF A, PointF B, PointF C)
        => (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);

        public static void MostRightPoints(List<PointF> points, List<int> indexArray, List<int> resultIndex)
        {
            while (true)
            {
                var right = 0;
                for (var i = 1; i < indexArray.Count; i++)
                {
                    if (Rotation(points[resultIndex.Last()], points[indexArray[right]], points[indexArray[i]]) < 0)
                        right = i;
                }
                //прерывается, когда текущей снова оказывается стартовая вершина
                if (indexArray[right] == resultIndex[0])
                    break;
                else
                {
                    //добавляем индекс в конечный список индексов
                    resultIndex.Add(indexArray[right]);
                    //удаляем его из исходного
                    indexArray.RemoveAt(right);
                }
            }
        }

        //нахождение самое левой вершины в списке
        public static void FindLeft(List<PointF> list, List<int> indexArray)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[indexArray[i]].X < list[indexArray[0]].X)
                    Swap(i, 0, indexArray);
            }
        }

        //список точек из списка индексов массива точек
        public static List<PointF> FromIntToPoint(List<int> indexes, List<PointF> points)
        {
            var res = new List<PointF>();
            foreach (var elem in indexes)
                res.Add(points[elem]);
            return res;
        }

        //создание списка порядковых номер размеров n
        public static List<int> Range(int n)
        {
            var array = new List<int>();
            for (var i = 0; i < n; i++)
                array.Add(i);
            return array;
        }
        public static void Swap(int left, int right, List<int> array)
        {
            var temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }
    }

}
