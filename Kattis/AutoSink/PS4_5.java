package test;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.PriorityQueue;
import java.util.Scanner;

public class PS6_6 {

    public static int dijkstra(HashMap<String, Node> cities, Node s, Node si)
    {
        PriorityQueue<Node> pq = new PriorityQueue<Node>();
        
        HashMap<Node, Prev_dist> alg = new HashMap<>(); 

        if (s == si)
        {
            return 0;
        }

        for(Node n: cities.values())
        {
            alg.put(n, new Prev_dist(null, Integer.MAX_VALUE));
            n.prev = new Prev_dist(null, Integer.MAX_VALUE);
        }

        // set the 1st city distance to 0
        alg.get(s).dist = 0;

        // put the source inside the queue
        pq.add(s);

        while (pq.size() != 0)
        {
            Node u = pq.poll();
            for(String str : u.next_city){
                int u_dist = alg.get(u).dist;
                int v_dist = alg.get(cities.get(str)).dist;
                int w = cities.get(str).cost;

                if (v_dist > u_dist + w)
                {
                    v_dist = u_dist + w;
                    alg.get(cities.get(str)).prev = s;
                    alg.get(cities.get(str)).dist = v_dist;
                    pq.add(cities.get(str));
                }
            }
        }
        return alg.get(si).dist;
    }
	public static void main(String[] args) {
//         ArrayList<String[]> trips = new ArrayList<>();

//         HashSet<Node> vertex = new HashSet<Node>();


         // vertex and edges
         Scanner s = new Scanner(System.in);
         int nm[] = new int[2]
         for(int i = 0; i<2; i++)
         {
             nm[i] = s.nextInt();
         }
         int n = nm[0]; // # vertex
         int m = nm[1]; // # edges

         while n!=0 && m!=0 {

            HashMap<int, Node> vertex_info = new HashMap<int, Node>();
//            ArrayList<Pair> edges = new ArrayList<>();
            // vertex
            for (int i = 0; i < n; i++) {
                Node u = new Node(i);
                vertex_info.put(i, u, 0);
            }

            // edges
            for (int i = 0; i < m; i++) {
                int u = s.nextInt();
                int v = s.nextInt();
                double f = to;
                vertex_info.get(u).cost.replace(f);
                vertex_info.get(v).cost.replace(f);
                vertex_info.get(u).next_vertex.add(v);
                vertex_info.get(v).next_vertex.add(u);

//                int[] uv = new int[2];
//                uv[0] = u;
//                uv[1] = v;
//                edges.add(new Pair(uv, f));
            }

            // dijkstra
            if (n != 0 && m != 0) {
                if (m == 1){
                    System.out.println(vertex_info.get(0).cost);
                }
                else{
                int shortest_path = -1;
                shortest_path = dijkstra(vertex_info, vertex_info.get(0), vertex_info.get(n - 1), edges);
//                if (shortest_path == Integer.MAX_VALUE) {
//                    System.out.println("NO");
//                    continue;
//                }
                System.out.println(shortest_path);
                }
            }
        }
	}

}

class Node implements Comparable<Node>
{
    public int v;
    public ArrayList<String> next_vertex;
    public Prev_dist prev;
    public double cost;

    public Node(int v, double cost)
    {
        this.v = v;
        this.next_vertex = new ArrayList<String>();
        this.cost = cost;
    }
    
    public int compareTo(Node n) {
    	if(this.prev.dist < n.prev.dist) {
    		return -1;
    	}
    	return 1;
    }
    
    public String toString() {
    	return "current city: " + city + " cost: " + cost;
    }

}

class Prev_dist
{
    public Node prev;
    public double dist;

    public Prev_dist(Node prev, double dist)
    {
        this.prev = prev;
        this.dist = dist;
    }
}

class Pair{
	int[] nArr;
	double value;
	
	public Pair(int[] nArr, double value){
		this.nArr = nArr;
		this.value = value;
	}
}
