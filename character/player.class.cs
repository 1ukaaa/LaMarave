public class Player {
    private string name;
    private int level;

    public Player(string name, int level) {
        this.name = name;
        this.level = level;
    }

    public string Name {
        get { return name; }
        set { name = value; }
    }

    public int Level {
        get { return level; }
        set { level = value; }
    }

    public override string ToString() {
        return "Name: " + name + " Level: " + level;
    }
}