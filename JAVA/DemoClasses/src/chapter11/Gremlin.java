package chapter11;

public class Gremlin {
    static int gremlinCount = 0;

    public Gremlin() {
        gremlinCount++;
    }

    static int getGremlinCount() {
        return gremlinCount;
    }
}
