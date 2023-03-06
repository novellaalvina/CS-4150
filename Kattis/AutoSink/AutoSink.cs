using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PS4_5
{
    class Program
    {
        public class Node
        {
            public string city;
            public List<string> next_city;
            public int cost;

            public Node(string city, int cost)
            {
                this.city = city;
                this.next_city = new List<string>();
                this.cost = cost;
            }
        }

            public class Prev_dist
            {
                public Node prev;
                public int dist;

                public Prev_dist(Node prev, int dist)
                {
                    this.prev = prev;
                    this.dist = dist;
                }
        }

        public static int dijkstra(Dictionary<string, Node> cities, Node s, Node si)
        {
            PriorityQueue<Node, int> pq = new PriorityQueue<Node, int>();

            Dictionary<Node, Prev_dist> alg = new Dictionary<Node, Prev_dist>(); // prev, dist

            if (s == si)
            {
                return 0;
            }

            foreach (KeyValuePair<string, Node> city in cities)
            {
                //(Node prev, int dist) info = (null, int.MaxValue);
                alg.Add(city.Value, new Prev_dist(null, int.MaxValue));
            }

            // set the 1st city distance to 0
            alg[s].dist = 0;

            // put the source inside the queue
            pq.Enqueue(s, alg[s].dist);

            while (pq.Count != 0)
            {
                Node u = pq.Dequeue();
                //pq.TryDequeue(out u, out int w);

                // go through each edge and update the dist
                foreach (string edge_city in u.next_city)
                {
                    int u_dist = alg[u].dist;
                    int v_dist = alg[cities[edge_city]].dist;
                    int w = cities[edge_city].cost;

                    if (v_dist > u_dist + w)
                    {
                        v_dist = u_dist + w;
                        alg[cities[edge_city]].prev = s;
                        alg[cities[edge_city]].dist = v_dist;
                        pq.Enqueue(cities[edge_city], v_dist);
                    }

                }
            }

            return alg[si].dist;
        }

        public static void Main(string[] args)
        {

            Dictionary<string, Node> cities = new Dictionary<string, Node>();
            List<string[]> trips = new List<string[]>();
            List<Tuple<Node[], int>> edges = new List<Tuple<Node[], int>>();

            // vertex
            int n;
            int.TryParse(Console.ReadLine(), out n);
            for(int i = 0; i<n; i++)
            {
                string city;
                int cost;

                string[] line = Console.ReadLine().Split();
                city = line[0];
                int.TryParse(line[1], out cost);

                Node newnode = new Node(city, cost);
                cities.Add(city, newnode);
            }

            // edges
            int h;
            int.TryParse(Console.ReadLine(), out h);
            for (int i = 0; i < h ; i++)
            {
                string next_city;
                string[] line2 = Console.ReadLine().Split();
                next_city = line2[1];
                cities[line2[0]].next_city.Add(next_city);

                Node[] uv = new Node[2];
                uv[0] = cities[line2[0]];
                uv[1] = cities[next_city];
                edges.Add(new Tuple<Node[], int>(uv, uv[1].cost));
            }

            // maps
            int t;
            int.TryParse(Console.ReadLine(), out t);

            for(int i = 0; i < t; i++)
            {
                string[] trip = Console.ReadLine().Split();
                trips.Add(trip);
            }
            //Console.WriteLine(trips.Count);
            foreach(string[] trip in trips)
            {
                int shortest_path = -1;
                shortest_path = dijkstra(cities, cities[trip[0]], cities[trip[1]]);
                if (shortest_path == int.MaxValue)
                {
                    Console.WriteLine("NO");
                    continue;
                }
                Console.WriteLine(shortest_path);
            }
        }

    }
}

