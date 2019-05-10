using System.Collections.Generic;
using System.Linq;

namespace Vojta
{
    public class Vertex<T>
    {
        public Vertex(T value)
        {
            Id = value;
            Edges = new List<(double, Vertex<T>)>();
        }
        public T Id { get; set; }
        public List<(double, Vertex<T>)> Edges { get; set; }
    }

    public class Graph<T>
    {
        public Graph()
        {
            Vertices = new Dictionary<T, Vertex<T>>();
        }

        public IDictionary<T, Vertex<T>> Vertices { get; set; }

        public void AddLinked(Vertex<T> a, Vertex<T> b, double edgeValue)
        {
            if (!Vertices.ContainsKey(a.Id))
                Vertices.Add(a.Id, a);

            if (!Vertices.ContainsKey(b.Id))
                Vertices.Add(b.Id, b);

            a.Edges.Add((edgeValue, b));
        }
    }

    public static class DistanceCalculator
    {
        class Data
        {
            public bool Finished { get; set; }
            public double Price { get; set; }
        }

        public static double MinDistance<T>(Graph<T> graph, Vertex<T> a, Vertex<T> b)
        {
            var distances = graph.Vertices.ToDictionary(kv => kv.Key,
                kv => new Data {Finished = false, Price = double.MaxValue});

            var current = a;
            distances[current.Id].Price = 0;
            distances[current.Id].Finished = true;
            while (!distances[b.Id].Finished)
            {
                var currentPrice = distances[current.Id].Price;
                foreach (var (price, neighbour) in current.Edges)
                {
                    if (distances[neighbour.Id].Price > currentPrice + price)
                    {
                        distances[neighbour.Id].Price = currentPrice + price;
                    }
                }

                var minValue = double.MaxValue;
                var minId = current.Id;
                foreach (var (id, dt) in distances)
                {
                    if (dt.Finished)
                        continue;
                    if (dt.Price < minValue)
                    {
                        minValue = dt.Price;
                        minId = id;
                    }
                }

                distances[minId].Finished = true;
                current = graph.Vertices[minId];
            }

            return distances[b.Id].Price;
        }
    }
}