namespace MovieLava.Spaces;

public class Zoo
{
    public void Run()
    {
        var catTrainer = new CatTrainer();
        catTrainer.Train(new());
    }
}

public class Animal
{
}

public class Cat : Animal
{

}

public class AnimalTrainer<TAnimal>
{
    public virtual void Train(TAnimal animal)
    {
        BeNiceWithAnimal();
        GiveSomeWaterToAnimal();
    }

    private void BeNiceWithAnimal() { }
    private void GiveSomeWaterToAnimal() { }
}

public class CatTrainer : AnimalTrainer<Cat>
{
    public override void Train(Cat animal)
    {
        base.Train(animal);
        PlayWithABall();
    }

    private void PlayWithABall() { }
}


public class Fish : Animal
{

}

public class FishTrainer : AnimalTrainer<Fish>
{
    public override void Train(Fish fish)
    {
        base.Train(fish);
        PlayWithLights();
    }

    private void PlayWithLights() { }
}




