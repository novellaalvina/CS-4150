package com.PS6_6;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.PriorityQueue;
import java.util.Scanner;
import java.text.DecimalFormat;

public class Main {

    public static double dijkstra(HashMap<Integer, Node> cities, Node s, Node si)
    {
        PriorityQueue<Node> pq = new PriorityQueue<Node>();

        HashMap<Node, Double> alg = new HashMap<>();

        for(Node n: cities.values())
        {
            alg.put(n, 0.0);
        }

        // set the 1st city distance to 0
        alg.put(s, 1.0);

        // put the source inside the queue
        pq.add(s);

        while (pq.size() != 0)
        {
            Node u = pq.poll();
            for(double v : u.next_vertex){
                double u_dist = alg.get(u);
                double v_dist = alg.get(cities.get(v));
//                double w = u.next_vertex.get(v);

//                if (v_dist < u_dist * w)
//                {
//                    v_dist = u_dist * w;
////                    alg.get(v.prev).prev = u;
//                    alg.put(cities.get(v), v_dist);
//                    pq.add(cities.get(v));
//                }
            }
        }
        return alg.get(si);
    }
    public static void main(String[] args) {

        // vertex and edges
        Scanner s = new Scanner(System.in);
        int nm[] = new int[2];

        int n = -1; // # vertex
        int m = -1; // # edges

        DecimalFormat df = new DecimalFormat("#.####"); // to format the decimal to 4 digits after .

        while(true) {

            HashMap<Integer, Node> vertex_info = new HashMap<Integer, Node>();
            n = s.nextInt();
            m = s.nextInt();
            if(n == 0 && m == 0){
                System.exit(0);
                return;
            }

            // vertex
            for (int i = 0; i < n; i++) {
                vertex_info.put(i, new Node(i,0));
            }

            // edges
            for (int i = 0; i < m; i++) {
                int u = s.nextInt();
                int v = s.nextInt();
                double f = s.nextDouble();

                Node u_tmp = vertex_info.get(u);
                Node v_tmp = vertex_info.get(v);
                u_tmp.next_vertex.add(v, f);
                v_tmp.next_vertex.add(u, f);
            }

            // dijkstra
            double shortest_path = -1;
            shortest_path = dijkstra(vertex_info, vertex_info.get(0), vertex_info.get(n - 1));
            System.out.printf("%.4f\n",shortest_path);
        }

    }

}

class Node implements Comparable<Node>
{
    public int v;
//    public ArrayList<Node> next_vertex;
    public ArrayList<Double> next_vertex;
//    public double factor;
    public double dist;

    public Node(int v, double factor)
    {
        this.v = v;
        this.next_vertex = new ArrayList<Double>();
        this.dist = 0;
    }

    public int compareTo(Node n) {
        if(this.dist < n.dist) {
            return -1;
        }
        return 1;
    }
}


