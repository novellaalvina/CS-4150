package com.PS6_6;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.PriorityQueue;
import java.util.Scanner;
import java.text.DecimalFormat;

public class NewPS6 {
    public static double dijkstra(HashMap<Integer, ArrayList<Connection>> graph, int s, int d)
    {
        PriorityQueue<Connection> pq = new PriorityQueue<Connection>();

        double[] alg = new double[d+1];

        alg[s] = 1;

        pq.add(new Connection(s,1));

        while (pq.size() != 0){
            Connection u = pq.poll();
            for (Connection v: graph.get(u.v)) {
                double u_dist = alg[u.v];
                double v_dist = alg[v.v];
                double w = v.factor;

                if (v_dist < u_dist * w) {
                    v_dist = u_dist * w;
                    alg[v.v]= v_dist;
                    pq.add(v);
                }
            }
        }
        return alg[d];
    }

    public static void main(String[] args) throws IOException {

        // vertex and edges

        BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));

        int n = -1; // # vertex
        int m = -1; // # edges

        DecimalFormat df = new DecimalFormat("#.####"); // to format the decimal to 4 digits after .

        while(true) {

            HashMap<Integer, ArrayList<Connection>> graph = new HashMap<>();
            String[] s = bf.readLine().split(" ");
            n = Integer.parseInt(s[0]);
            m = Integer.parseInt(s[1]);
            if(n == 0 && m == 0){
                System.exit(0);
                return;
            }

            // vertex
            for (int i = 0; i < n; i++) {
                ArrayList<Connection> neighbours = new ArrayList<>();
                graph.put(i, neighbours);
            }

            // edges
            for (int i = 0; i < m; i++) {
                String[] s2 = bf.readLine().split(" ");
                int u = Integer.parseInt(s2[0]);
                int v = Integer.parseInt(s2[1]);
                double f = Double.parseDouble(s2[2]);

                graph.get(u).add(new Connection(v,f));
                graph.get(v).add(new Connection(u,f));

            }

            // dijkstra
            double shortest_path = -1;
            shortest_path = dijkstra(graph, 0, n-1);
            System.out.printf("%.4f\n",shortest_path);
        }

    }

}

class Connection implements Comparable<Connection>{
    public int v;
    public double factor;

    public Connection(int v, double f){
        this.v = v;
        this.factor = f;
    }

    public int compareTo(Connection n) {
        if(this.factor < n.factor) {
            return -1;
        }
        return 1;
    }
}
