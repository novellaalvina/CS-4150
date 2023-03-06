using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PS5_6
{
    class Program
    {
        public class Node
        {
            public string name;
            public SortedSet<string> friend;

            public Node(string name)
            {
                this.name = name;
                this.friend = new SortedSet<string>();
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

        public static string BFS(Dictionary<string, Node> people, Node s)
        {
            Queue<Node> q = new Queue<Node>();

            Dictionary<Node, Prev_dist> alg = new Dictionary<Node, Prev_dist>(); // prev, dist

            List<string> path = new List<string>();

            SortedSet<string> unvisited = new SortedSet<string>();

            SortedDictionary<int, SortedSet<string>> day_ordered = new SortedDictionary<int, SortedSet<string>>(); // keep vertex ordered based on day lexicogrpahically

            if (people.Count == 0)
            {
                return s.name;
            }

            foreach (KeyValuePair<string, Node> person in people)
            {
                //(Node prev, int dist) info = (null, int.MaxValue);
                alg.Add(person.Value, new Prev_dist(null, int.MaxValue));
            }

            // set the 1st city distance to 0
            alg[s].dist = 0;

            q.Enqueue(s);

            //path.Add(s.name);

            day_ordered.Add(0, new SortedSet<string> { s.name });

            while (q.Count != 0)
            {
                Node u = q.Dequeue();
                //path.Add(u.name);

                foreach(string f in u.friend)
                {
                    int u_dist = alg[u].dist;
                    int v_dist = alg[people[f]].dist;

                    if (alg[people[f]].dist == int.MaxValue)
                    {
                        v_dist = u_dist + 1;
                        alg[people[f]].dist = v_dist;
                        alg[people[f]].prev = u;

                        if (!day_ordered.ContainsKey(v_dist))
                        {
                            SortedSet<string> child_ordered = new SortedSet<string>();
                            child_ordered.Add(f);
                            day_ordered.Add(v_dist, child_ordered);
                        }
                        else
                        {
                            day_ordered[v_dist].Add(f);
                        }

                        if (!q.Contains(people[f]))
                            q.Enqueue(people[f]);
                    }
                }
            }

            HashSet<string> added = new HashSet<string>();

            foreach(KeyValuePair<int, SortedSet<string>> day in day_ordered)
            {
                foreach (string d in day.Value)
                {
                    path.Add(d);
                    added.Add(d);
                }
            }

            foreach(KeyValuePair<string, Node> person in people)
            {
                if (!added.Contains(person.Key))
                    unvisited.Add(person.Key);    
            }

            foreach (string u in unvisited)
                path.Add(u);

            string final_path = string.Join(" ", path);

            return final_path;
        }

        public static void Main(string[] args)
        {

            Dictionary<string, Node> people = new Dictionary<string, Node>();
            List<string> reports = new List<string>();

            // vertex
            int n;
            int.TryParse(Console.ReadLine(), out n);
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                Node newnode = new Node(name);
                people.Add(name, newnode);
            }

            // edges
            int f;
            int.TryParse(Console.ReadLine(), out f);
            for (int i = 0; i < f; i++)
            {
                string person;
                string friend;
                string[] line2 = Console.ReadLine().Split();
                person = line2[0];
                friend = line2[1];
                people[person].friend.Add(friend);
                people[friend].friend.Add(person);
            }

            // maps
            int r;
            int.TryParse(Console.ReadLine(), out r);

            for (int i = 0; i < r; i++)
            {
                string starter = Console.ReadLine();
                reports.Add(starter);
            }

            foreach (string starter in reports)
            {
                string path;
                path = BFS(people, people[starter]);
                Console.WriteLine(path);
            }
        }
    }
}

