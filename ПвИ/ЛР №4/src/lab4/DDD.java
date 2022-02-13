package lab4;

public class DDD extends CCC {
    public int x;
    private int y;

    public DDD(){
        super();
    }
    public DDD(int x, int y){
        super(x, y);
        this.x = x;
        this.y = y;
    }

    public int sum() {
        return super.sum() + this.x + this.y;
    }

    public int calc(){
        return this.x * this.y + super.sum();
    }
}
