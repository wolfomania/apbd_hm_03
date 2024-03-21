namespace HM_03.Containers;

public class RefrigeratedContainer : Container
{
    
    public double Temperature { get; set; }
    
    public Product Product { get; set; }
    
    private static readonly Dictionary<Product, double> Products = new()
    {
        {Product.Banana, 13.3},
        {Product.Chocolate, 18.0},
        {Product.Fish, 2.0},
        {Product.Meat, -15.0},
        {Product.IceCream, -18.0},
        {Product.FrozenPizza, -30.0},
        {Product.Cheese, 7.2},
        {Product.Sausages, 5.0},
        {Product.Butter, 20.5},
        {Product.Eggs, 19}
    };

    public RefrigeratedContainer(double mass, double height, double tareWeight, double depth, double maxPayload, double temperature, Product product) 
        : base(height, tareWeight, depth, maxPayload)
    {
        Product = product;
        Mass = 0;
        Temperature = temperature;
        Load(mass, product);
    }

    public void Load(double mass, Product product)
    {
        if (Temperature > Products[product])
        {
            Console.WriteLine("Can't load " + product + ".\n" +
                              "Insufficient temperature: " + Temperature + ".\n" +
                              "Required: " + Products[product]);
        } 
        else if (Product == product)
        {
            base.Load(mass);
        }
        else
        {
            if (Mass != 0)
            {
                Console.WriteLine("Can't mix two types of product.\n" +
                                  "Current product: " + Product + ".\n" +
                                  "Trying to load: " + product + ".\n");
            }
            else
            {
                Product = product;
                base.Load(mass);                
            }

        }
    }

    public override string GetContainerType()
    {
        return "R";
    }
}